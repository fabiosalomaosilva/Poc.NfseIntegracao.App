using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Tributação total
/// </summary>
public class TribTotal
{
    [XmlElement("vTotTrib")]
    [Range(0, 999999999999.99)]
    public decimal? ValorTotalTributacao { get; set; }

    [XmlElement("pTotTrib")]
    [Range(0, 100)]
    public decimal? PercentualTotalTributacao { get; set; }
}