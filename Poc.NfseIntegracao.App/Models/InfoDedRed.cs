using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Informações de dedução e redução
/// </summary>
public class InfoDedRed
{
    [XmlElement("tpDedRed")]
    [Required]
    [Range(1, 9)]
    public int TipoDeducaoReducao { get; set; }

    [XmlElement("xDescDedRed")]
    [Required]
    [StringLength(2000, MinimumLength = 1)]
    public string DescricaoDeducaoReducao { get; set; } = string.Empty;

    [XmlElement("dtDedRed")]
    public DateTime? DataDeducaoReducao { get; set; }

    [XmlElement("vDedRed")]
    [Required]
    [Range(0.01, 999999999999.99)]
    public decimal ValorDeducaoReducao { get; set; }

    [XmlElement("docDedRed")]
    public List<DocDedRed>? DocumentosDeducaoReducao { get; set; }
}