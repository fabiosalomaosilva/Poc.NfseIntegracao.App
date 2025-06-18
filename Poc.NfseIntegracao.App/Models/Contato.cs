using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Informações de contato
/// </summary>
public class Contato
{
    [XmlElement("xCont")]
    [StringLength(60)]
    public string? NomeContato { get; set; }

    [XmlElement("email")]
    [StringLength(80)]
    [EmailAddress]
    public string? Email { get; set; }

    [XmlElement("fone")]
    [StringLength(20)]
    public string? Telefone { get; set; }
}