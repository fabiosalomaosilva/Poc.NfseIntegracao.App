using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Poc.NfseIntegracao.App.Models
{
    /// <summary>
    /// Response para operações com DPS
    /// </summary>
    public class DpsResponse
    {
        /// <summary>
        /// ID único da DPS gerada
        /// </summary>
        [JsonPropertyName("id")]
        [Required]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// XML da DPS em formato texto
        /// </summary>
        [JsonPropertyName("dpsXml")]
        public string? DpsXml { get; set; }

        /// <summary>
        /// DPS XML compactado em GZip Base64
        /// </summary>
        [JsonPropertyName("dpsXmlGZipB64")]
        public string? DpsXmlGZipB64 { get; set; }

        /// <summary>
        /// Indica se a DPS foi assinada digitalmente
        /// </summary>
        [JsonPropertyName("assinado")]
        public bool Assinado { get; set; } = false;

        /// <summary>
        /// Data e hora de criação da DPS
        /// </summary>
        [JsonPropertyName("dataCriacao")]
        [Required]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Chave de acesso da NFS-e (quando processada)
        /// </summary>
        [JsonPropertyName("chaveAcesso")]
        public string? ChaveAcesso { get; set; }

        /// <summary>
        /// Série da DPS
        /// </summary>
        [JsonPropertyName("serie")]
        public string? Serie { get; set; }

        /// <summary>
        /// Número da DPS
        /// </summary>
        [JsonPropertyName("numero")]
        public long? Numero { get; set; }

        /// <summary>
        /// Tipo de ambiente (1=Produção, 2=Homologação)
        /// </summary>
        [JsonPropertyName("tipoAmbiente")]
        public int TipoAmbiente { get; set; } = 2;

        /// <summary>
        /// Versão do aplicativo que gerou a DPS
        /// </summary>
        [JsonPropertyName("versaoAplicativo")]
        public string VersaoAplicativo { get; set; } = "1.00";

        /// <summary>
        /// CNPJ do prestador
        /// </summary>
        [JsonPropertyName("cnpjPrestador")]
        public string? CnpjPrestador { get; set; }

        /// <summary>
        /// Valor total do serviço
        /// </summary>
        [JsonPropertyName("valorServico")]
        public decimal? ValorServico { get; set; }

        /// <summary>
        /// Descrição do serviço prestado
        /// </summary>
        [JsonPropertyName("descricaoServico")]
        public string? DescricaoServico { get; set; }

        /// <summary>
        /// Status da DPS (Criada, Validada, Processada, etc.)
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = "Criada";

        /// <summary>
        /// Observações ou informações adicionais
        /// </summary>
        [JsonPropertyName("observacoes")]
        public string? Observacoes { get; set; }

        /// <summary>
        /// Lista de alertas ou avisos
        /// </summary>
        [JsonPropertyName("alertas")]
        public List<string>? Alertas { get; set; }

        /// <summary>
        /// Lista de erros de validação (se houver)
        /// </summary>
        [JsonPropertyName("erros")]
        public List<string>? Erros { get; set; }

        /// <summary>
        /// Tamanho do XML em bytes
        /// </summary>
        [JsonPropertyName("tamanhoXml")]
        public long? TamanhoXml { get; set; }

        /// <summary>
        /// Tamanho do XML compactado em bytes
        /// </summary>
        [JsonPropertyName("tamanhoXmlCompactado")]
        public long? TamanhoXmlCompactado { get; set; }

        /// <summary>
        /// Percentual de compressão alcançado
        /// </summary>
        [JsonPropertyName("percentualCompressao")]
        public decimal? PercentualCompressao { get; set; }

        /// <summary>
        /// Informações sobre o certificado usado (se assinado)
        /// </summary>
        [JsonPropertyName("certificadoInfo")]
        public CertificadoInfo? CertificadoInfo { get; set; }
    }

    /// <summary>
    /// Response para criação de lotes de teste de DPS
    /// </summary>
    public class LoteTesteResponse
    {
        /// <summary>
        /// ID único do lote gerado
        /// </summary>
        [JsonPropertyName("idLote")]
        [Required]
        public string IdLote { get; set; } = string.Empty;

        /// <summary>
        /// Quantidade de DPS geradas no lote
        /// </summary>
        [JsonPropertyName("quantidadeGerada")]
        [Required]
        public int QuantidadeGerada { get; set; }

        /// <summary>
        /// Quantidade solicitada originalmente
        /// </summary>
        [JsonPropertyName("quantidadeSolicitada")]
        public int? QuantidadeSolicitada { get; set; }

        /// <summary>
        /// Lista das DPS geradas no lote
        /// </summary>
        [JsonPropertyName("dpsGeradas")]
        [Required]
        public List<DpsResponse> DpsGeradas { get; set; } = new List<DpsResponse>();

        /// <summary>
        /// Data e hora do processamento do lote
        /// </summary>
        [JsonPropertyName("dataProcessamento")]
        [Required]
        public DateTime DataProcessamento { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Tempo total de processamento em millisegundos
        /// </summary>
        [JsonPropertyName("tempoProcessamentoMs")]
        public long? TempoProcessamentoMs { get; set; }

        /// <summary>
        /// Tipo de ambiente (1=Produção, 2=Homologação)
        /// </summary>
        [JsonPropertyName("tipoAmbiente")]
        public int TipoAmbiente { get; set; } = 2;

        /// <summary>
        /// Versão do aplicativo
        /// </summary>
        [JsonPropertyName("versaoAplicativo")]
        public string VersaoAplicativo { get; set; } = "1.00";

        /// <summary>
        /// Estatísticas do lote processado
        /// </summary>
        [JsonPropertyName("estatisticas")]
        public LoteEstatisticas? Estatisticas { get; set; }

        /// <summary>
        /// Observações sobre o processamento do lote
        /// </summary>
        [JsonPropertyName("observacoes")]
        public string? Observacoes { get; set; }

        /// <summary>
        /// Lista de alertas gerais do lote
        /// </summary>
        [JsonPropertyName("alertas")]
        public List<string>? Alertas { get; set; }

        /// <summary>
        /// Lista de erros gerais do lote
        /// </summary>
        [JsonPropertyName("erros")]
        public List<string>? Erros { get; set; }

        /// <summary>
        /// Status geral do lote
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = "Processado";

        /// <summary>
        /// Indica se todas as DPS do lote foram assinadas
        /// </summary>
        [JsonPropertyName("todasAssinadas")]
        public bool TodasAssinadas { get; set; } = false;
    }

    /// <summary>
    /// Informações sobre o certificado usado na assinatura
    /// </summary>
    public class CertificadoInfo
    {
        /// <summary>
        /// Subject do certificado
        /// </summary>
        [JsonPropertyName("subject")]
        public string? Subject { get; set; }

        /// <summary>
        /// Emissor do certificado
        /// </summary>
        [JsonPropertyName("issuer")]
        public string? Issuer { get; set; }

        /// <summary>
        /// Data de início de validade
        /// </summary>
        [JsonPropertyName("validoDe")]
        public DateTime? ValidoDe { get; set; }

        /// <summary>
        /// Data de fim de validade
        /// </summary>
        [JsonPropertyName("validoAte")]
        public DateTime? ValidoAte { get; set; }

        /// <summary>
        /// CNPJ extraído do certificado
        /// </summary>
        [JsonPropertyName("cnpj")]
        public string? Cnpj { get; set; }

        /// <summary>
        /// Número de série do certificado
        /// </summary>
        [JsonPropertyName("numeroSerie")]
        public string? NumeroSerie { get; set; }

        /// <summary>
        /// Thumbprint do certificado
        /// </summary>
        [JsonPropertyName("thumbprint")]
        public string? Thumbprint { get; set; }

        /// <summary>
        /// Indica se o certificado tem chave privada
        /// </summary>
        [JsonPropertyName("temChavePrivada")]
        public bool TemChavePrivada { get; set; } = false;
    }

    /// <summary>
    /// Estatísticas de processamento do lote
    /// </summary>
    public class LoteEstatisticas
    {
        /// <summary>
        /// Valor total dos serviços do lote
        /// </summary>
        [JsonPropertyName("valorTotalServicos")]
        public decimal ValorTotalServicos { get; set; }

        /// <summary>
        /// Valor médio por DPS
        /// </summary>
        [JsonPropertyName("valorMedioPorDps")]
        public decimal ValorMedioPorDps { get; set; }

        /// <summary>
        /// Maior valor de serviço do lote
        /// </summary>
        [JsonPropertyName("maiorValor")]
        public decimal MaiorValor { get; set; }

        /// <summary>
        /// Menor valor de serviço do lote
        /// </summary>
        [JsonPropertyName("menorValor")]
        public decimal MenorValor { get; set; }

        /// <summary>
        /// Tamanho total dos XMLs não compactados (bytes)
        /// </summary>
        [JsonPropertyName("tamanhoTotalXml")]
        public long TamanhoTotalXml { get; set; }

        /// <summary>
        /// Tamanho total dos XMLs compactados (bytes)
        /// </summary>
        [JsonPropertyName("tamanhoTotalCompactado")]
        public long TamanhoTotalCompactado { get; set; }

        /// <summary>
        /// Percentual médio de compressão do lote
        /// </summary>
        [JsonPropertyName("percentualMedioCompressao")]
        public decimal PercentualMedioCompressao { get; set; }

        /// <summary>
        /// Quantidade de DPS com sucesso
        /// </summary>
        [JsonPropertyName("quantidadeSucesso")]
        public int QuantidadeSucesso { get; set; }

        /// <summary>
        /// Quantidade de DPS com erro
        /// </summary>
        [JsonPropertyName("quantidadeErro")]
        public int QuantidadeErro { get; set; }

        /// <summary>
        /// Quantidade de DPS com alerta
        /// </summary>
        [JsonPropertyName("quantidadeAlerta")]
        public int QuantidadeAlerta { get; set; }
    }

    /// <summary>
    /// Request simplificado para criação de DPS personalizada
    /// </summary>
    //public class CriarDpsRequest
    //{
    //    /// <summary>
    //    /// CNPJ do prestador de serviço
    //    /// </summary>
    //    [JsonPropertyName("cnpjPrestador")]
    //    [Required(ErrorMessage = "CNPJ do prestador é obrigatório")]
    //    public string CnpjPrestador { get; set; } = string.Empty;

    //    /// <summary>
    //    /// Razão social do prestador
    //    /// </summary>
    //    [JsonPropertyName("razaoSocialPrestador")]
    //    [Required(ErrorMessage = "Razão social do prestador é obrigatória")]
    //    public string RazaoSocialPrestador { get; set; } = string.Empty;

    //    /// <summary>
    //    /// CNPJ/CPF do tomador (opcional para DPS fake)
    //    /// </summary>
    //    [JsonPropertyName("documentoTomador")]
    //    public string? DocumentoTomador { get; set; }

    //    /// <summary>
    //    /// Nome/Razão social do tomador
    //    /// </summary>
    //    [JsonPropertyName("nomeTomador")]
    //    public string? NomeTomador { get; set; }

    //    /// <summary>
    //    /// Descrição do serviço prestado
    //    /// </summary>
    //    [JsonPropertyName("descricaoServico")]
    //    [Required(ErrorMessage = "Descrição do serviço é obrigatória")]
    //    public string DescricaoServico { get; set; } = string.Empty;

    //    /// <summary>
    //    /// Código do serviço conforme tabela municipal
    //    /// </summary>
    //    [JsonPropertyName("codigoServico")]
    //    [Required(ErrorMessage = "Código do serviço é obrigatório")]
    //    public string CodigoServico { get; set; } = string.Empty;

    //    /// <summary>
    //    /// Valor do serviço
    //    /// </summary>
    //    [JsonPropertyName("valorServico")]
    //    [Required(ErrorMessage = "Valor do serviço é obrigatório")]
    //    [Range(0.01, double.MaxValue, ErrorMessage = "Valor deve ser maior que zero")]
    //    public decimal ValorServico { get; set; }

    //    /// <summary>
    //    /// Alíquota do ISSQN (opcional, padrão 5%)
    //    /// </summary>
    //    [JsonPropertyName("aliquotaIssqn")]
    //    [Range(0, 100, ErrorMessage = "Alíquota deve estar entre 0 e 100")]
    //    public decimal? AliquotaIssqn { get; set; }

    //    /// <summary>
    //    /// Código do município de prestação do serviço
    //    /// </summary>
    //    [JsonPropertyName("codigoMunicipio")]
    //    public int? CodigoMunicipio { get; set; }

    //    /// <summary>
    //    /// Informações adicionais (opcional)
    //    /// </summary>
    //    [JsonPropertyName("informacoesAdicionais")]
    //    public string? InformacoesAdicionais { get; set; }

    //    /// <summary>
    //    /// Tipo de ambiente (1=Produção, 2=Homologação)
    //    /// </summary>
    //    [JsonPropertyName("tipoAmbiente")]
    //    public int TipoAmbiente { get; set; } = 2;
    //}

    /// <summary>
    /// Enums para status de processamento
    /// </summary>
    public enum StatusDps
    {
        Criada = 1,
        Validada = 2,
        Assinada = 3,
        Processada = 4,
        Rejeitada = 5,
        Cancelada = 6
    }

    /// <summary>
    /// Enums para tipos de certificado
    /// </summary>
    public enum TipoCertificado
    {
        A1 = 1,
        A3 = 2
    }
}