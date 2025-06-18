using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

public class Transform
{
    [XmlAttribute("Algorithm")]
    public string Algorithm { get; set; } = string.Empty;
}