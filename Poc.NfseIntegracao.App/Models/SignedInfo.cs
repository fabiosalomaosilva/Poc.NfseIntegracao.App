using Poc.NfseNacional.Models;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Informações assinadas
/// </summary>
public class SignedInfo
{
    [XmlElement("CanonicalizationMethod")]
    public CanonicalizationMethod CanonicalizationMethod { get; set; } = new CanonicalizationMethod();

    [XmlElement("SignatureMethod")]
    public SignatureMethod SignatureMethod { get; set; } = new SignatureMethod();

    [XmlElement("Reference")]
    public Reference Reference { get; set; } = new Reference();
}