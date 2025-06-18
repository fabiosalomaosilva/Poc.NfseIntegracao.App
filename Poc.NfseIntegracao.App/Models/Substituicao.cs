using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Informações de substituição da NFS-e
/// </summary>
public class Substituicao
{
    [XmlElement("chvNFSeSubst")]
    [Required]
    [StringLength(53)]
    [RegularExpression(@"NFS[0-9]{50}", ErrorMessage = "Chave deve seguir o padrão NFS + 50 dígitos")]
    public string ChaveNFSeSubstituida { get; set; } = string.Empty;

    [XmlElement("motivo")]
    [Required]
    [StringLength(255, MinimumLength = 15)]
    public string Motivo { get; set; } = string.Empty;
}