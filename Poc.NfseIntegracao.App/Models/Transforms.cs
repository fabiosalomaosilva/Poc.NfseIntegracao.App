using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

public class Transforms
{
    [XmlElement("Transform")]
    public List<Transform> Transform { get; set; } = new List<Transform>();
}