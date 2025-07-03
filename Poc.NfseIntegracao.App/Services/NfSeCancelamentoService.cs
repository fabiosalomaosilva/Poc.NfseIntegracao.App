using System.IO.Compression;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;

namespace Poc.NfseIntegracao.App.Services
{
    /// <summary>
    /// Enumeração dos motivos de cancelamento permitidos
    /// </summary>
    public enum MotivoCancelamento
    {
        ErroNaEmissao = 1,
        ServicoNaoPrestado = 2,
        Outros = 9
    }

    /// <summary>
    /// Classe para gerar e enviar cancelamento de NFS-e baseada no manual oficial ADN
    /// </summary>
    public class NfSeCancelamentoService
    {
        private const string NAMESPACE_NFSE = "http://www.sped.fazenda.gov.br/nfse";

        #region Classes de apoio

        /// <summary>
        /// Dados extraídos da NFS-e original
        /// </summary>
        private class DadosNFSe
        {
            public string ChaveAcesso { get; set; }
            public string CNPJ { get; set; }
            public int TipoAmbiente { get; set; }
            public int AmbienteGerador { get; set; }
        }

        /// <summary>
        /// Informações do endpoint para envio
        /// </summary>
        public class EndpointInfo
        {
            public string BaseUrl { get; set; }
            public string Endpoint { get; set; }
            public string UrlCompleta { get; set; }
            public int AmbienteGerador { get; set; }
        }

        /// <summary>
        /// Estrutura para envio via API
        /// </summary>
        public class LoteEnvio
        {
            public string[] LoteXmlGZipB64 { get; set; }
        }

        /// <summary>
        /// Resultado do processamento de cancelamento
        /// </summary>
        public class ResultadoCancelamento
        {
            public bool Sucesso { get; set; }
            public string XmlEventoCompleto { get; set; }
            public string XmlPedidoRegistro { get; set; }
            public EndpointInfo EndpointInfo { get; set; }
            public string MensagemRetorno { get; set; }
            public int HttpStatusCode { get; set; }
            public string DetalhesErro { get; set; }
        }

        #endregion

        #region Métodos principais

        /// <summary>
        /// Método principal para cancelar NFS-e municipal
        /// Determina automaticamente o endpoint correto baseado no ambGer da NFS-e
        /// </summary>
        /// <param name="xmlNfSe">XML da NFS-e original a ser cancelada</param>
        /// <param name="motivoCancelamento">Motivo do cancelamento</param>
        /// <param name="descricaoMotivo">Descrição detalhada (mínimo 15 caracteres)</param>
        /// <param name="forcarHomologacao">Se true, força ambiente de homologação independente da NFS-e</param>
        /// <returns>Resultado do cancelamento</returns>
        public static async Task<ResultadoCancelamento> CancelarNFSe(
            string xmlNfSe,
            MotivoCancelamento motivoCancelamento = MotivoCancelamento.ErroNaEmissao,
            string descricaoMotivo = "Solicitação de cancelamento via integração",
            bool forcarHomologacao = true)
        {
            try
            {
                // 1. Validações básicas
                ValidarParametros(xmlNfSe, descricaoMotivo);

                // 2. Extrai dados da NFS-e
                var dados = ExtrairDadosNFSe(xmlNfSe);

                // 3. Ajusta ambiente se necessário
                var ambienteFinal = forcarHomologacao ? 2 : dados.TipoAmbiente;

                // 4. Gera estrutura do evento baseada no manual ADN
                string xmlEventoCompleto;
                if (dados.AmbienteGerador == 1) // NFS-e gerada pela prefeitura
                {
                    xmlEventoCompleto = GerarEventoCompletoParaADN(dados, motivoCancelamento, descricaoMotivo, ambienteFinal);
                }
                else // NFS-e gerada pelo Sistema Nacional
                {
                    xmlEventoCompleto = GerarPedidoRegistroParaSefinNacional(dados, motivoCancelamento, descricaoMotivo, ambienteFinal);
                }

                // 5. Assina o evento
                xmlEventoCompleto = AssinarEvento(xmlEventoCompleto, dados.AmbienteGerador);

                // 6. Determina endpoint correto
                var endpointInfo = DeterminarEndpointCorreto(dados.AmbienteGerador, ambienteFinal);

                // 7. Envia para a API
                var resultado = await EnviarEventoParaAPI(xmlEventoCompleto, endpointInfo);

                return new ResultadoCancelamento
                {
                    Sucesso = resultado.Sucesso,
                    XmlEventoCompleto = xmlEventoCompleto,
                    EndpointInfo = endpointInfo,
                    MensagemRetorno = resultado.Mensagem,
                    HttpStatusCode = resultado.StatusCode,
                    DetalhesErro = resultado.Erro
                };
            }
            catch (Exception ex)
            {
                return new ResultadoCancelamento
                {
                    Sucesso = false,
                    DetalhesErro = $"Erro interno: {ex.Message}",
                    HttpStatusCode = 500
                };
            }
        }

        #endregion

        #region Extração de dados da NFS-e

        /// <summary>
        /// Extrai dados necessários da NFS-e original
        /// </summary>
        private static DadosNFSe ExtrairDadosNFSe(string xmlNfSe)
        {
            var xmlDoc = XDocument.Parse(xmlNfSe);

            // Extrai chave de acesso
            var infNFSe = xmlDoc.Root?.Element(XName.Get("infNFSe", NAMESPACE_NFSE));
            if (infNFSe == null)
                throw new ArgumentException("Elemento infNFSe não encontrado no XML");

            var idAttr = infNFSe.Attribute("Id");
            if (idAttr == null || string.IsNullOrWhiteSpace(idAttr.Value))
                throw new ArgumentException("Atributo Id da infNFSe não encontrado");

            var chaveCompleta = idAttr.Value;
            var chaveAcesso = chaveCompleta.StartsWith("NFS") && chaveCompleta.Length == 53
                ? chaveCompleta.Substring(3)
                : chaveCompleta;

            if (chaveAcesso.Length != 50)
                throw new ArgumentException($"Chave de acesso deve ter 50 dígitos. Encontrado: {chaveAcesso.Length}");

            // Extrai CNPJ do emitente
            var cnpjElement = infNFSe?.Element(XName.Get("emit", NAMESPACE_NFSE))
                                     ?.Element(XName.Get("CNPJ", NAMESPACE_NFSE))
                              ?? infNFSe?.Element(XName.Get("DPS", NAMESPACE_NFSE))
                                        ?.Element(XName.Get("infDPS", NAMESPACE_NFSE))
                                        ?.Element(XName.Get("prest", NAMESPACE_NFSE))
                                        ?.Element(XName.Get("CNPJ", NAMESPACE_NFSE));

            var cnpj = cnpjElement?.Value?.Trim();
            if (string.IsNullOrWhiteSpace(cnpj))
                throw new ArgumentException("CNPJ do emitente não encontrado no XML");

            // Extrai ambGer da NFS-e
            var ambGerElement = infNFSe?.Element(XName.Get("ambGer", NAMESPACE_NFSE));
            var ambienteGerador = 1; // Default para prefeitura
            if (ambGerElement != null && int.TryParse(ambGerElement.Value, out var ambGer))
            {
                ambienteGerador = ambGer;
            }

            // Extrai tpAmb da DPS
            var tpAmbElement = infNFSe?.Element(XName.Get("DPS", NAMESPACE_NFSE))
                                      ?.Element(XName.Get("infDPS", NAMESPACE_NFSE))
                                      ?.Element(XName.Get("tpAmb", NAMESPACE_NFSE));

            var tipoAmbiente = 2; // Default para homologação
            if (tpAmbElement != null && int.TryParse(tpAmbElement.Value, out var amb))
            {
                tipoAmbiente = amb;
            }

            return new DadosNFSe
            {
                ChaveAcesso = chaveAcesso,
                CNPJ = cnpj,
                TipoAmbiente = tipoAmbiente,
                AmbienteGerador = ambienteGerador
            };
        }

        #endregion

        #region Geração de XML do evento

        /// <summary>
        /// Gera evento completo para ADN conforme manual
        /// (para NFS-e com ambGer=1 - gerada pela prefeitura)
        /// </summary>
        private static string GerarEventoCompletoParaADN(
            DadosNFSe dados,
            MotivoCancelamento motivoCancelamento,
            string descricaoMotivo,
            int tipoAmbiente)
        {
            var idPedReg = $"PRE{dados.ChaveAcesso}101101001";
            var idEvento = $"EVT{dados.ChaveAcesso}101101001";

            // nDFe deve ter 1-13 dígitos conforme XSD TSNumDFe
            // Usar horário de Brasília para evitar problemas de fuso horário
            var brasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            var agora = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brasilia);

            var nDFe = agora.ToString("yyyyMMddHHmm"); // 12 dígitos

            // Formato para NFS-e: AAAA-MM-DDThh:mm:ssTZD onde TZD pode ser -03:00 (Brasília)
            var dhProc = agora.ToString("yyyy-MM-ddTHH:mm:ss-03:00");
            var dhEvento = agora.AddHours(-1).ToString("yyyy-MM-ddTHH:mm:ss-03:00");

            // Estrutura completa do evento para ADN baseada no manual
            var eventoXml = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<evento xmlns=""{NAMESPACE_NFSE}"" versao=""1.00"">
  <infEvento Id=""{idEvento}"">
    <verAplic>1.00</verAplic>
    <ambGer>1</ambGer>
    <nSeqEvento>1</nSeqEvento>
    <dhProc>{dhProc}</dhProc>
    <nDFe>{nDFe}</nDFe>
    <pedRegEvento versao=""1.00"">
      <infPedReg Id=""{idPedReg}"">
        <tpAmb>{tipoAmbiente}</tpAmb>
        <verAplic>1.00</verAplic>
        <dhEvento>{dhEvento}</dhEvento>
        <CNPJAutor>{dados.CNPJ}</CNPJAutor>
        <chNFSe>{dados.ChaveAcesso}</chNFSe>
        <nPedRegEvento>1</nPedRegEvento>
        <e101101>
          <xDesc>Cancelamento de NFS-e</xDesc>
          <cMotivo>{(int)motivoCancelamento}</cMotivo>
          <xMotivo>{SecurityElement.Escape(descricaoMotivo)}</xMotivo>
        </e101101>
      </infPedReg>
    </pedRegEvento>
  </infEvento>
</evento>";

            return eventoXml;
        }

        /// <summary>
        /// Gera pedido de registro simples para Sefin Nacional
        /// (para NFS-e com ambGer=2 - gerada pelo Sistema Nacional)
        /// </summary>
        private static string GerarPedidoRegistroParaSefinNacional(
            DadosNFSe dados,
            MotivoCancelamento motivoCancelamento,
            string descricaoMotivo,
            int tipoAmbiente)
        {
            var idPedReg = $"PRE{dados.ChaveAcesso}101101001";

            // Usar horário de Brasília para evitar problemas de fuso horário
            var brasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            var agora = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brasilia).AddHours(-1);
            var dhEvento = agora.ToString("yyyy-MM-ddTHH:mm:ss-03:00");

            var pedidoXml = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<pedRegEvento xmlns=""{NAMESPACE_NFSE}"" versao=""1.00"">
  <infPedReg Id=""{idPedReg}"">
    <tpAmb>{tipoAmbiente}</tpAmb>
    <verAplic>1.00</verAplic>
    <dhEvento>{dhEvento}</dhEvento>
    <CNPJAutor>{dados.CNPJ}</CNPJAutor>
    <chNFSe>{dados.ChaveAcesso}</chNFSe>
    <nPedRegEvento>1</nPedRegEvento>
    <e101101>
      <xDesc>Cancelamento de NFS-e</xDesc>
      <cMotivo>{(int)motivoCancelamento}</cMotivo>
      <xMotivo>{SecurityElement.Escape(descricaoMotivo)}</xMotivo>
    </e101101>
  </infPedReg>
</pedRegEvento>";

            return pedidoXml;
        }

        #endregion

        #region Assinatura digital

        /// <summary>
        /// Assina o evento digitalmente usando certificado das variáveis de ambiente
        /// </summary>
        private static string AssinarEvento(string xmlEvento, int ambienteGerador)
        {
            try
            {
                var certificado = ObterCertificadoDigital();
                if (certificado == null)
                {
                    Console.WriteLine("AVISO: Certificado não encontrado. XML não será assinado.");
                    return xmlEvento;
                }

                var xmlDoc = new XmlDocument { PreserveWhitespace = true };
                xmlDoc.LoadXml(xmlEvento);

                XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
                nsManager.AddNamespace("nfse", NAMESPACE_NFSE);

                if (ambienteGerador == 1) // ADN - assina o evento completo
                {
                    // Para ADN, assina o infEvento e a assinatura vai no final do evento
                    var infEvento = xmlDoc.SelectSingleNode("//nfse:infEvento", nsManager) as XmlElement;
                    if (infEvento == null)
                        throw new ArgumentException("Elemento infEvento não encontrado");

                    var evento = xmlDoc.SelectSingleNode("//nfse:evento", nsManager) as XmlElement;
                    if (evento == null)
                        throw new ArgumentException("Elemento evento não encontrado");

                    var signedXml = new SignedXml(xmlDoc);

                    // Configurar algoritmos específicos do NFS-e conforme XSD
                    var reference = new Reference
                    {
                        Uri = $"#{infEvento.GetAttribute("Id")}",
                        DigestMethod = "http://www.w3.org/2000/09/xmldsig#sha1"
                    };

                    // Transforms conforme XSD - ordem específica
                    reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                    reference.AddTransform(new XmlDsigC14NTransform());

                    signedXml.AddReference(reference);

                    // Configurar método de assinatura específico
                    signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
                    signedXml.SignedInfo.CanonicalizationMethod = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315";

                    // Configurar chave
                    signedXml.SigningKey = certificado.PrivateKey;

                    var keyInfo = new KeyInfo();
                    keyInfo.AddClause(new KeyInfoX509Data(certificado));
                    signedXml.KeyInfo = keyInfo;

                    signedXml.ComputeSignature();

                    var signature = signedXml.GetXml();
                    evento.AppendChild(xmlDoc.ImportNode(signature, true));
                }
                else // Sefin Nacional - assina o pedRegEvento
                {
                    // Para Sefin Nacional, assina o infPedReg e a assinatura vai no final do pedRegEvento
                    var infPedReg = xmlDoc.SelectSingleNode("//nfse:infPedReg", nsManager) as XmlElement;
                    if (infPedReg == null)
                        throw new ArgumentException("Elemento infPedReg não encontrado");

                    var pedRegEvento = xmlDoc.SelectSingleNode("//nfse:pedRegEvento", nsManager) as XmlElement;
                    if (pedRegEvento == null)
                        throw new ArgumentException("Elemento pedRegEvento não encontrado");

                    var signedXml = new SignedXml(xmlDoc);

                    // Configurar algoritmos específicos do NFS-e conforme XSD
                    var reference = new Reference
                    {
                        Uri = $"#{infPedReg.GetAttribute("Id")}",
                        DigestMethod = "http://www.w3.org/2000/09/xmldsig#sha1"
                    };

                    // Transforms conforme XSD - ordem específica
                    reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                    reference.AddTransform(new XmlDsigC14NTransform());

                    signedXml.AddReference(reference);

                    // Configurar método de assinatura específico
                    signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
                    signedXml.SignedInfo.CanonicalizationMethod = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315";

                    // Configurar chave
                    signedXml.SigningKey = certificado.PrivateKey;

                    var keyInfo = new KeyInfo();
                    keyInfo.AddClause(new KeyInfoX509Data(certificado));
                    signedXml.KeyInfo = keyInfo;

                    signedXml.ComputeSignature();

                    var signature = signedXml.GetXml();
                    pedRegEvento.AppendChild(xmlDoc.ImportNode(signature, true));
                }

                return xmlDoc.OuterXml;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AVISO: Erro ao assinar XML: {ex.Message}");
                return xmlEvento; // Retorna XML sem assinatura em caso de erro
            }
        }

        /// <summary>
        /// Obtém certificado digital das variáveis de ambiente
        /// </summary>
        private static X509Certificate2 ObterCertificadoDigital()
        {
            try
            {
                var pathCert = "C:/CertificadoClientes/cert.pfx";
                var pfxExiste = File.Exists("C:/CertificadoClientes/cert.pfx");
                if (!pfxExiste)
                {
                    pathCert = "C:/CertificadoClientes/cert.p12";
                }
                return new X509Certificate2(pathCert, "123456");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar certificado: {ex.Message}");
                return null;
            }
        }

        #endregion

        #region Determinação de endpoint

        /// <summary>
        /// Determina o endpoint correto baseado no ambGer da NFS-e
        /// </summary>
        private static EndpointInfo DeterminarEndpointCorreto(int ambienteGerador, int tipoAmbiente)
        {
            string baseUrl;
            string endpoint;
            switch (ambienteGerador)
            {
                case 1: // Prefeitura -> ADN
                    baseUrl = tipoAmbiente == 1
                        ? "https://adn.nfse.gov.br"
                        : "https://adn.producaorestrita.nfse.gov.br";
                    endpoint = "/dfe";
                    break;
                case 2: // Sistema Nacional -> Sefin Nacional
                    baseUrl = "https://sefin.producaorestrita.nfse.gov.br/sefinnacional";
                    endpoint = "/dfe"; // ou endpoint específico se existir
                    break;
                default:
                    throw new ArgumentException($"Ambiente gerador inválido: {ambienteGerador}");
            }
            return new EndpointInfo
            {
                BaseUrl = baseUrl,
                Endpoint = endpoint,
                UrlCompleta = baseUrl + endpoint,
                AmbienteGerador = ambienteGerador
            };
        }

        #endregion

        #region Envio para API

        /// <summary>
        /// Envia evento para a API correspondente
        /// </summary>
        private static async Task<(bool Sucesso, string Mensagem, int StatusCode, string Erro)> EnviarEventoParaAPI(
            string xmlEvento,
            EndpointInfo endpointInfo)
        {
            try
            {
                var loteEnvio = PrepararLoteParaEnvio(xmlEvento);
                var certificado = ObterCertificadoDigital();

                using var handler = new HttpClientHandler();
                if (certificado != null)
                {
                    handler.ClientCertificates.Add(certificado);
                }

                using var client = new HttpClient(handler);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "NFSeCancelamento/1.0");

                var json = JsonSerializer.Serialize(loteEnvio, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                Console.WriteLine($"Enviando para: {endpointInfo.UrlCompleta}");

                var response = await client.PostAsync(endpointInfo.UrlCompleta, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                var sucesso = response.IsSuccessStatusCode && !responseContent.Contains("\"erro\"");

                return (sucesso, responseContent, (int)response.StatusCode, sucesso ? null : responseContent);
            }
            catch (Exception ex)
            {
                return (false, null, 500, ex.Message);
            }
        }

        /// <summary>
        /// Prepara o lote para envio (compressão GZip + Base64)
        /// </summary>
        private static LoteEnvio PrepararLoteParaEnvio(string xmlEvento)
        {
            var xmlBytes = Encoding.UTF8.GetBytes(xmlEvento);

            using var memoryStream = new MemoryStream();
            using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
            {
                gzipStream.Write(xmlBytes, 0, xmlBytes.Length);
            }

            var xmlComprimidoBase64 = Convert.ToBase64String(memoryStream.ToArray());

            return new LoteEnvio
            {
                LoteXmlGZipB64 = new[] { xmlComprimidoBase64 }
            };
        }

        #endregion

        #region Validações

        /// <summary>
        /// Valida parâmetros de entrada
        /// </summary>
        private static void ValidarParametros(string xmlNfSe, string descricaoMotivo)
        {
            if (string.IsNullOrWhiteSpace(xmlNfSe))
                throw new ArgumentException("XML da NFS-e não pode ser nulo ou vazio", nameof(xmlNfSe));

            if (string.IsNullOrWhiteSpace(descricaoMotivo) || descricaoMotivo.Trim().Length < 15)
                throw new ArgumentException("Descrição do motivo deve ter pelo menos 15 caracteres", nameof(descricaoMotivo));

            try
            {
                XDocument.Parse(xmlNfSe);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"XML da NFS-e inválido: {ex.Message}", nameof(xmlNfSe));
            }
        }

        #endregion

        #region Métodos de conveniência

        /// <summary>
        /// Método simplificado para cancelamento em homologação
        /// </summary>
        public static async Task<ResultadoCancelamento> CancelarNFSeHomologacao(
            string xmlNfSe,
            string descricaoMotivo = "Solicitação de cancelamento via integração")
        {
            return await CancelarNFSe(xmlNfSe, MotivoCancelamento.ErroNaEmissao, descricaoMotivo, forcarHomologacao: true);
        }

        /// <summary>
        /// Método simplificado para cancelamento em produção
        /// </summary>
        public static async Task<ResultadoCancelamento> CancelarNFSeProducao(
            string xmlNfSe,
            string descricaoMotivo = "Solicitação de cancelamento via integração")
        {
            return await CancelarNFSe(xmlNfSe, MotivoCancelamento.ErroNaEmissao, descricaoMotivo, forcarHomologacao: false);
        }

        #endregion
    }
}