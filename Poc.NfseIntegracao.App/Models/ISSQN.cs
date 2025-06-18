using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Informações do ISSQN
/// </summary>
public class ISSQN
{
    [XmlElement("tpTribISSQN")]
    [Required]
    [Range(1, 6)]
    public int TipoTributacaoISSQN { get; set; }

    [XmlElement("vBCISSQN")]
    [Range(0, 999999999999.99)]
    public decimal? BaseCalculoISSQN { get; set; }

    [XmlElement("aliqISSQN")]
    [Range(0, 100)]
    public decimal? AliquotaISSQN { get; set; }

    [XmlElement("vISSQN")]
    [Range(0, 999999999999.99)]
    public decimal? ValorISSQN { get; set; }

    [XmlElement("cListServ")]
    [StringLength(5)]
    public string? CodigoListaServico { get; set; }

    [XmlElement("cSitTrib")]
    [Range(1, 9)]
    public int? CodigoSituacaoTributaria { get; set; }
}