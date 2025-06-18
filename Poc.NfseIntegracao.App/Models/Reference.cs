using Poc.NfseIntegracao.App.Models;
using System.Xml.Serialization;

namespace Poc.NfseNacional.Models;

public class Reference
{
    [XmlAttribute("URI")]
    public string? URI { get; set; }

    [XmlElement("Transforms")]
    public Transforms? Transforms { get; set; }

    [XmlElement("DigestMethod")]
    public DigestMethod DigestMethod { get; set; } = new DigestMethod();

    [XmlElement("DigestValue")]
    public string DigestValue { get; set; } = string.Empty;
}