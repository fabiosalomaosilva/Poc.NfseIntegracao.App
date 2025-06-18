using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Informações do serviço prestado
/// </summary>
public class Serv
{
    [XmlElement("tpTrib")]
    [Required]
    [Range(1, 6)]
    public int TipoTributacao { get; set; }

    [XmlElement("locPrest")]
    [Required]
    [Range(1000000, 9999999)]
    public int LocalPrestacao { get; set; }

    [XmlElement("xServ")]
    [Required]
    [StringLength(2000, MinimumLength = 1)]
    public string DescricaoServico { get; set; } = string.Empty;

    [XmlElement("cServ")]
    [Required]
    [StringLength(20)]
    public string CodigoServico { get; set; } = string.Empty;

    [XmlElement("cNBS")]
    [StringLength(9)]
    public string? CodigoNBS { get; set; }

    [XmlElement("cCNAE")]
    [StringLength(7)]
    public string? CodigoCNAE { get; set; }

    [XmlElement("infValores")]
    [Required]
    public InfoValores InfoValores { get; set; } = new InfoValores();
}