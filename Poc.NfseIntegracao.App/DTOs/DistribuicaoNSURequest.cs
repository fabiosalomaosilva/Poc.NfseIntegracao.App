using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Poc.NfseIntegracao.App.DTOs
{

    public class NFSePostRequest
    {
        [JsonPropertyName("dpsXmlGZipB64")]
        [Required(ErrorMessage = "DPS XML compactado é obrigatório")]
        public string DpsXmlGZipB64 { get; set; } = string.Empty;
    }

    public class EventosPostRequest : EventoPostRequest
    {
        [JsonPropertyName("eventoXmlGZipB64")]
        [Required(ErrorMessage = "Evento XML compactado é obrigatório")]
        public new string EventoXmlGZipB64
        {
            get => PedidoRegistroEventoXmlGZipB64;
            set => PedidoRegistroEventoXmlGZipB64 = value;
        }
    }


    public class NFSePostResponseSucesso
    {
        [JsonPropertyName("tipoAmbiente")]
        [Required]
        public int TipoAmbiente { get; set; }

        [JsonPropertyName("versaoAplicativo")]
        [Required]
        public string VersaoAplicativo { get; set; } = string.Empty;

        [JsonPropertyName("dataHoraProcessamento")]
        [Required]
        public DateTime DataHoraProcessamento { get; set; }

        [JsonPropertyName("idDps")]
        public string? IdDps { get; set; }

        [JsonPropertyName("chaveAcesso")]
        public string? ChaveAcesso { get; set; }

        [JsonPropertyName("nfseXmlGZipB64")]
        public string? NfseXmlGZipB64 { get; set; }

        [JsonPropertyName("alertas")]
        public List<MensagemProcessamento>? Alertas { get; set; }
    }

    public class NFSePostResponseErro
    {
        [JsonPropertyName("tipoAmbiente")]
        [Required]
        public int TipoAmbiente { get; set; }

        [JsonPropertyName("versaoAplicativo")]
        [Required]
        public string VersaoAplicativo { get; set; } = string.Empty;

        [JsonPropertyName("dataHoraProcessamento")]
        [Required]
        public DateTime DataHoraProcessamento { get; set; }

        [JsonPropertyName("idDPS")]
        public string? IdDPS { get; set; }

        [JsonPropertyName("erros")]
        [Required]
        public List<MensagemProcessamento> Erros { get; set; } = new List<MensagemProcessamento>();
    }

    public class NFSeGetResponseSucesso
    {
        [JsonPropertyName("tipoAmbiente")]
        [Required]
        public int TipoAmbiente { get; set; }

        [JsonPropertyName("versaoAplicativo")]
        [Required]
        public string VersaoAplicativo { get; set; } = string.Empty;

        [JsonPropertyName("dataHoraProcessamento")]
        [Required]
        public DateTime DataHoraProcessamento { get; set; }

        [JsonPropertyName("chaveAcesso")]
        [Required]
        public string ChaveAcesso { get; set; } = string.Empty;

        [JsonPropertyName("nfseXmlGZipB64")]
        [Required]
        public string NfseXmlGZipB64 { get; set; } = string.Empty;
    }

    public class EventosPostResponseSucesso
    {
        [JsonPropertyName("tipoAmbiente")]
        [Required]
        public int TipoAmbiente { get; set; }

        [JsonPropertyName("versaoAplicativo")]
        [Required]
        public string VersaoAplicativo { get; set; } = string.Empty;

        [JsonPropertyName("dataHoraProcessamento")]
        [Required]
        public DateTime DataHoraProcessamento { get; set; }

        [JsonPropertyName("chaveAcesso")]
        [Required]
        public string ChaveAcesso { get; set; } = string.Empty;

        [JsonPropertyName("eventoXmlGZipB64")]
        public string? EventoXmlGZipB64 { get; set; }

        [JsonPropertyName("alertas")]
        public List<MensagemProcessamento>? Alertas { get; set; }
    }

    public class DpsGetResponse
    {
        [JsonPropertyName("tipoAmbiente")]
        [Required]
        public int TipoAmbiente { get; set; }

        [JsonPropertyName("versaoAplicativo")]
        [Required]
        public string VersaoAplicativo { get; set; } = string.Empty;

        [JsonPropertyName("dataHoraProcessamento")]
        [Required]
        public DateTime DataHoraProcessamento { get; set; }

        [JsonPropertyName("idDps")]
        [Required]
        public string IdDps { get; set; } = string.Empty;

        [JsonPropertyName("chaveAcesso")]
        [Required]
        public string ChaveAcesso { get; set; } = string.Empty;
    }

    public class ResponseErro
    {
        [JsonPropertyName("tipoAmbiente")]
        [Required]
        public int TipoAmbiente { get; set; }

        [JsonPropertyName("versaoAplicativo")]
        [Required]
        public string VersaoAplicativo { get; set; } = string.Empty;

        [JsonPropertyName("dataHoraProcessamento")]
        [Required]
        public DateTime DataHoraProcessamento { get; set; }

        [JsonPropertyName("erro")]
        [Required]
        public MensagemProcessamento Erro { get; set; } = new MensagemProcessamento();
    }

    public class LoteDistribuicaoNSUResponse
    {
        [JsonPropertyName("StatusProcessamento")]
        public StatusProcessamentoDistribuicao StatusProcessamento { get; set; }

        [JsonPropertyName("LoteDFe")]
        public List<DistribuicaoNSU>? LoteDFe { get; set; }

        [JsonPropertyName("Alertas")]
        public List<MensagemProcessamento>? Alertas { get; set; }

        [JsonPropertyName("Erros")]
        public List<MensagemProcessamento>? Erros { get; set; }

        [JsonPropertyName("TipoAmbiente")]
        public TipoAmbiente TipoAmbiente { get; set; }

        [JsonPropertyName("VersaoAplicativo")]
        public string? VersaoAplicativo { get; set; }

        [JsonPropertyName("DataHoraProcessamento")]
        public DateTime? DataHoraProcessamento { get; set; }
    }



    public class MensagemProcessamento
    {
        [JsonPropertyName("Descricao")]
        public string? Descricao { get; set; }

        [JsonPropertyName("Codigo")]
        public string? Codigo { get; set; }

        [JsonPropertyName("Parametros")]
        public List<string>? Parametros { get; set; }

        [JsonPropertyName("Complemento")]
        public string Complemento { get; set; }
    }

    public class DistribuicaoNSU
    {
        [JsonPropertyName("NSU")]
        public long? NSU { get; set; }

        [JsonPropertyName("ChaveAcesso")]
        public string? ChaveAcesso { get; set; }

        [JsonPropertyName("TipoDocumento")]
        public TipoDocumentoRequisicao TipoDocumento { get; set; }

        [JsonPropertyName("TipoEvento")]
        public TipoEvento? TipoEvento { get; set; }

        [JsonPropertyName("ArquivoXml")]
        public string? ArquivoXml { get; set; }

        [JsonPropertyName("DataHoraRecebimento")]
        public DateTime? DataHoraRecebimento { get; set; }

        [JsonPropertyName("DataHoraGeracao")]
        public DateTime? DataHoraGeracao { get; set; }
    }

    public enum TipoAmbiente
    {
        PRODUCAO = 1,
        HOMOLOGACAO = 2
    }

    public enum StatusProcessamentoDistribuicao
    {
        SUCESSO,
        ERRO,
        PROCESSANDO
    }

    public enum TipoDocumentoRequisicao
    {
        DPS,
        NFSE,
        EVENTO
    }

    public enum TipoEvento
    {
        CANCELAMENTO_POR_SUBSTITUICAO,
        CANCELAMENTO_POR_ERRO_EMISSAO,
        CANCELAMENTO_POR_DECISAO_JUDICIAL,
        CORRECAO_INFORMACOES_TOMADOR,
        CORRECAO_INFORMACOES_SERVICO,
        CORRECAO_OUTRAS_INFORMACOES,
        SUBSTITUICAO_NFSE,
        ANULACAO_NFSE,
        CONFIRMACAO_PRESTADOR,
        REJEICAO_PRESTADOR,
        CONFIRMACAO_TOMADOR,
        REJEICAO_TOMADOR,
        CONFIRMACAO_INTERMEDIARIO,
        REJEICAO_INTERMEDIARIO,
        CONFIRMACAO_TACITA,
        ANULACAO_REJEICAO,
        CANCELAMENTO_POR_OFICIO,
        BLOQUEIO_POR_OFICIO,
        DESBLOQUEIO_POR_OFICIO,
        INCLUSAO_NFSE_DAN,
        TRIBUTOS_NFSE_RECOLHIDOS
    }


    public class CriarDpsRequest
    {
        [Required]
        public string CNPJPrestador { get; set; } = string.Empty;

        [Required]
        public string RazaoSocialPrestador { get; set; } = string.Empty;

        [Required]
        public EnderecoPrestadorDto EnderecoPrestador { get; set; } = new();

        public TomadorDto? Tomador { get; set; }

        [Required]
        public ServicoDto Servico { get; set; } = new();

        public int TipoAmbiente { get; set; } = 2; // Homologação por padrão

        public string? InformacoesAdicionais { get; set; }
    }

    public class EnderecoPrestadorDto
    {
        [Required]
        public string Logradouro { get; set; } = string.Empty;

        public string? Numero { get; set; }

        public string? Complemento { get; set; }

        [Required]
        public string Bairro { get; set; } = string.Empty;

        [Required]
        public int CodigoMunicipio { get; set; }

        [Required]
        public string NomeMunicipio { get; set; } = string.Empty;

        public string? CEP { get; set; }
    }

    public class TomadorDto
    {
        [Required]
        public int TipoInscricao { get; set; } // 1=CNPJ, 2=CPF

        [Required]
        public string NumeroInscricao { get; set; } = string.Empty;

        [Required]
        public string Nome { get; set; } = string.Empty;

        public EnderecoTomadorDto? Endereco { get; set; }

        public ContatoDto? Contato { get; set; }
    }

    public class EnderecoTomadorDto
    {
        [Required]
        public string Logradouro { get; set; } = string.Empty;

        public string? Numero { get; set; }

        public string? Complemento { get; set; }

        [Required]
        public string Bairro { get; set; } = string.Empty;

        [Required]
        public int CodigoMunicipio { get; set; }

        [Required]
        public string NomeMunicipio { get; set; } = string.Empty;

        public string? CEP { get; set; }
    }

    public class ContatoDto
    {
        public string? Nome { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Telefone { get; set; }
    }

    public class ServicoDto
    {
        [Required]
        public string DescricaoServico { get; set; } = string.Empty;

        [Required]
        public string CodigoServico { get; set; } = string.Empty;

        public string? CodigoNBS { get; set; }

        public string? CodigoCNAE { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal ValorServico { get; set; }

        public decimal? BaseCalculo { get; set; }

        public decimal? AliquotaISSQN { get; set; }

        public decimal? ValorISSQN { get; set; }

        public decimal? DescontoIncondicional { get; set; }

        public decimal? DescontoCondicional { get; set; }
    }

    public class DANFSeResponse
    {
        [JsonPropertyName("chaveAcesso")]
        public string ChaveAcesso { get; set; } = string.Empty;

        [JsonPropertyName("danfseHtml")]
        public string? DANFSeHtml { get; set; }

        [JsonPropertyName("danfsePdf")]
        public string? DANFSePdf { get; set; }

        [JsonPropertyName("dataGeracao")]
        public DateTime DataGeracao { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("tipoAmbiente")]
        public int TipoAmbiente { get; set; } = 2;

        [JsonPropertyName("versaoAplicativo")]
        public string VersaoAplicativo { get; set; } = "1.00";
    }

}