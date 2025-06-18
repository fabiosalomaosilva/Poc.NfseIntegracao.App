using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

public class DigestMethod
{
    [XmlAttribute("Algorithm")]
    public string Algorithm { get; set; } = "http://www.w3.org/2001/04/xmlenc#sha256";
}