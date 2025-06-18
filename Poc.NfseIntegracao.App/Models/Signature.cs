using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Assinatura digital conforme XMLDSIG
/// </summary>
[XmlRoot("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public class Signature
{
    [XmlAttribute("Id")]
    public string? Id { get; set; }

    [XmlElement("SignedInfo")]
    [Required]
    public SignedInfo SignedInfo { get; set; } = new SignedInfo();

    [XmlElement("SignatureValue")]
    [Required]
    public string SignatureValue { get; set; } = string.Empty;

    [XmlElement("KeyInfo")]
    public KeyInfo? KeyInfo { get; set; }
}