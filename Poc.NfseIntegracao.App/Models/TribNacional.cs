using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Tributação nacional
/// </summary>
public class TribNacional
{
    [XmlElement("vBCTribNac")]
    [Range(0, 999999999999.99)]
    public decimal? BaseCalculoTributacaoNacional { get; set; }

    [XmlElement("aliqTribNac")]
    [Range(0, 100)]
    public decimal? AliquotaTributacaoNacional { get; set; }

    [XmlElement("vTribNac")]
    [Range(0, 999999999999.99)]
    public decimal? ValorTributacaoNacional { get; set; }
}