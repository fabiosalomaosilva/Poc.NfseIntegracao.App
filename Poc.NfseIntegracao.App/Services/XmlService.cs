using Poc.NfseIntegracao.App.Models;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Services
{
    public class XmlService
    {
        private readonly Random _random = new();

        public async Task<string> SerializarDpsParaXmlAsync(DPS dps)
        {
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "http://www.sped.fazenda.gov.br/nfse");
            namespaces.Add("ds", "http://www.w3.org/2000/09/xmldsig#");

            var serializer = new XmlSerializer(typeof(DPS));
            var settings = new XmlWriterSettings
            {
                Indent = false,
                OmitXmlDeclaration = false,
                Encoding = Encoding.UTF8
            };

            await using var stringWriter = new StringWriter();
            await using var xmlWriter = XmlWriter.Create(stringWriter, settings);

            serializer.Serialize(xmlWriter, dps, namespaces);

            var xml = stringWriter.ToString();

            return xml;
        }

        public async Task<string> DescompactarXmlAsync(string xmlCompactado)
        {
            try
            {
                var compressedBytes = Convert.FromBase64String(xmlCompactado);

                await using var memoryStream = new MemoryStream(compressedBytes);
                await using var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
                using var reader = new StreamReader(gzipStream, Encoding.UTF8);

                var xml = await reader.ReadToEndAsync();


                return xml;
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException("Formato Base64 inválido", ex);
            }
        }

        public async Task<string> CompactarXmlAsync(string xml)
        {
            var bytes = Encoding.UTF8.GetBytes(xml);

            using var memoryStream = new MemoryStream();
            await using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
            {
                await gzipStream.WriteAsync(bytes, 0, bytes.Length);
            }

            var compressedBytes = memoryStream.ToArray();
            var base64Result = Convert.ToBase64String(compressedBytes);

            return base64Result;
        }

        public string AssinarXml(string xmlInput)
        {
            var certificado = new X509Certificate2("c:/CertificadoClientes/cert.pfx", "123456",
                X509KeyStorageFlags.MachineKeySet);

            var xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.LoadXml(xmlInput);

            var ns = new XmlNamespaceManager(xmlDoc.NameTable);
            ns.AddNamespace("ns", "http://www.sped.fazenda.gov.br/nfse");

            var temNodeSignature = (XmlElement)xmlDoc.SelectSingleNode($"//ns:Signature ", ns);
            if (temNodeSignature != null) return xmlInput;

            var elementoAssinatura = (XmlElement)xmlDoc.SelectSingleNode($"//ns:infDPS", ns)!;
            if (elementoAssinatura == null)
                throw new Exception($"Nó 'infDPS' com atributo Id não encontrado.");

            var id = elementoAssinatura.GetAttribute("Id");
            if (string.IsNullOrEmpty(id))
                throw new Exception("O atributo 'Id' é obrigatório no elemento a ser assinado.");

            var signedXml = new SignedXml(xmlDoc)
            {
                SigningKey = certificado.GetRSAPrivateKey()
            };

            var reference = new Reference
            {
                Uri = "#" + id
            };

            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            reference.AddTransform(new XmlDsigC14NTransform());

            reference.DigestMethod = SignedXml.XmlDsigSHA1Url;

            signedXml.AddReference(reference);

            signedXml.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;

            var keyInfo = new System.Security.Cryptography.Xml.KeyInfo();
            keyInfo.AddClause(new KeyInfoX509Data(certificado));
            signedXml.KeyInfo = keyInfo;

            signedXml.ComputeSignature();

            var xmlSignature = signedXml.GetXml();

            XmlNode nodeNFSE = (XmlElement)xmlDoc.SelectSingleNode($"//ns:NFSe", ns);
            nodeNFSE.AppendChild(xmlDoc.ImportNode(xmlSignature, true));

            return xmlDoc.InnerXml;
        }

        public string GerarChaveAcessoAsync(string xml)
        {
            var doc = XDocument.Parse(xml);
            XNamespace ns = "http://www.sped.fazenda.gov.br/nfse";

            var cnpj = doc.Descendants(ns + "CNPJ").FirstOrDefault()?.Value;
            var cpf = doc.Descendants(ns + "CPF").FirstOrDefault()?.Value;
            var tipoInscricaoFederal = !string.IsNullOrEmpty(cnpj) ? "2" : "1";
            var documento = !string.IsNullOrEmpty(cnpj) ? cnpj.PadLeft(14, '0') : cpf.PadLeft(11, '0');

            var ambienteGerador = doc.Descendants(ns + "ambGer").FirstOrDefault()?.Value ?? "2"; // Default para homologação
            var codigoMunicipio = doc.Descendants(ns + "cLocIncid").FirstOrDefault()?.Value?.PadLeft(7, '0');
            var numeroNfse = doc.Descendants(ns + "nNFSe").FirstOrDefault()?.Value?.PadLeft(13, '0');

            if (string.IsNullOrEmpty(documento) || string.IsNullOrEmpty(codigoMunicipio) || string.IsNullOrEmpty(numeroNfse))
                throw new Exception("Erro ao extrair dados obrigatórios do XML.");

            var anoMes = Convert.ToDateTime(doc.Descendants(ns + "dhProc").FirstOrDefault()?.Value).ToString("yyMM");

            var codigoNumerico = _random.Next(0, 999999999).ToString("D9");

            var chaveBase = codigoMunicipio
                            + ambienteGerador
                            + tipoInscricaoFederal
                            + documento
                            + numeroNfse
                            + anoMes
                            + codigoNumerico;

            var dv = CalcularDv(chaveBase).ToString();

            var chaveCompleta = "NFS" + chaveBase + dv;

            return chaveCompleta;
        }

        public string GerarChaveDpsAsync(string xml)
        {
            var doc = XDocument.Parse(xml);
            XNamespace ns = "http://www.sped.fazenda.gov.br/nfse";

            var cnpj = doc.Descendants(ns + "CNPJ").FirstOrDefault()?.Value;
            var cpf = doc.Descendants(ns + "CPF").FirstOrDefault()?.Value;
            var tipoInscricaoFederal = !string.IsNullOrEmpty(cnpj) ? "2" : "1";
            var documento = !string.IsNullOrEmpty(cnpj)
                ? cnpj.PadLeft(14, '0')
                : cpf.PadLeft(14, '0');

            var codigoMunicipio = doc.Descendants(ns + "cLocEmi").FirstOrDefault()?.Value?.PadLeft(7, '0');

            var serieDPS = doc.Descendants(ns + "serie").FirstOrDefault()?.Value?.PadLeft(5, '0');

            var numeroDPS = doc.Descendants(ns + "nDPS").FirstOrDefault()?.Value?.PadLeft(15, '0');

            if (string.IsNullOrEmpty(documento) || string.IsNullOrEmpty(codigoMunicipio)
                                                || string.IsNullOrEmpty(serieDPS) || string.IsNullOrEmpty(numeroDPS))
            {
                throw new Exception("Erro ao extrair dados obrigatórios do XML para gerar a chave DPS.");
            }

            var chaveDPS = "DPS"
                           + codigoMunicipio
                           + tipoInscricaoFederal
                           + documento
                           + serieDPS
                           + numeroDPS;

            return chaveDPS;
        }

        private static int CalcularDv(string chave)
        {
            var soma = 0;
            var peso = 2;

            for (var i = chave.Length - 1; i >= 0; i--)
            {
                var num = int.Parse(chave[i].ToString());
                soma += num * peso;
                peso = peso == 9 ? 2 : peso + 1;
            }

            var resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }

        public string InserirNovaChave(string xml, string novoId, string tagXml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("nfse", "http://www.sped.fazenda.gov.br/nfse");

            var infNFSeNode = doc.SelectSingleNode($"//nfse:{tagXml}", ns);
            if (infNFSeNode != null && infNFSeNode.Attributes["Id"] != null)
            {
                infNFSeNode.Attributes["Id"].Value = novoId;
            }

            return doc.OuterXml;
        }
    }
}
