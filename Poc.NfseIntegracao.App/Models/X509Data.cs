using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

public class X509Data
{
    [XmlElement("X509Certificate")]
    public string? X509Certificate { get; set; }
}