using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

public class KeyInfo
{
    [XmlElement("X509Data")]
    public X509Data? X509Data { get; set; }
}