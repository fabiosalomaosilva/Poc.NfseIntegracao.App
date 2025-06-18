using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Informações do prestador de serviços
/// </summary>
public class InfoPrestador
{
    [XmlElement("infoPessoa")]
    [Required]
    public InfoPessoa InfoPessoa { get; set; } = new InfoPessoa();

    [XmlElement("infoCont")]
    public Contato? Contato { get; set; }
}