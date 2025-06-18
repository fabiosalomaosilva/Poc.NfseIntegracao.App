using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Valor de retenção tributária
/// </summary>
public class VRetTrib
{
    [XmlElement("vRetPIS")]
    [Range(0, 999999999999.99)]
    public decimal? RetencaoPIS { get; set; }

    [XmlElement("vRetCOFINS")]
    [Range(0, 999999999999.99)]
    public decimal? RetencaoCOFINS { get; set; }

    [XmlElement("vRetCSLL")]
    [Range(0, 999999999999.99)]
    public decimal? RetencaoCSLL { get; set; }

    [XmlElement("vRetIRRF")]
    [Range(0, 999999999999.99)]
    public decimal? RetencaoIRRF { get; set; }

    [XmlElement("vRetINSS")]
    [Range(0, 999999999999.99)]
    public decimal? RetencaoINSS { get; set; }
}