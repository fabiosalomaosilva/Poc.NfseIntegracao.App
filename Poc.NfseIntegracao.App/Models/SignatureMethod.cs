using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

public class SignatureMethod
{
    [XmlAttribute("Algorithm")]
    public string Algorithm { get; set; } = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";
}