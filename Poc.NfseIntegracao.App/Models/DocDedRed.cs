using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Documento de dedução e redução
/// </summary>
public class DocDedRed
{
    [XmlElement("chvDoc")]
    [StringLength(53)]
    public string? ChaveDocumento { get; set; }

    [XmlElement("tpDoc")]
    [Required]
    [Range(1, 9)]
    public int TipoDocumento { get; set; }

    [XmlElement("nDoc")]
    [StringLength(50)]
    public string? NumeroDocumento { get; set; }

    [XmlElement("dEmiDoc")]
    public DateTime? DataEmissaoDocumento { get; set; }

    [XmlElement("vDoc")]
    [Range(0, 999999999999.99)]
    public decimal? ValorDocumento { get; set; }

    [XmlElement("vDedRed")]
    [Range(0, 999999999999.99)]
    public decimal? ValorDeducaoReducao { get; set; }
}