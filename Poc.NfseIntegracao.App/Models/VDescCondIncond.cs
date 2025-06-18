using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Valor de desconto condicional e incondicional
/// </summary>
public class VDescCondIncond
{
    [XmlElement("vDescIncond")]
    [Range(0, 999999999999.99)]
    public decimal? DescontoIncondicional { get; set; }

    [XmlElement("vDescCond")]
    [Range(0, 999999999999.99)]
    public decimal? DescontoCondicional { get; set; }
}