using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Informações do intermediário
/// </summary>
public class InfoIntermediario
{
    [XmlElement("infoPessoa")]
    [Required]
    public InfoPessoa InfoPessoa { get; set; } = new InfoPessoa();

    [XmlElement("infoCont")]
    public Contato? Contato { get; set; }
}