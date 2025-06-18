using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Informações de endereço
/// </summary>
public class Endereco
{
    [XmlElement("xLgr")]
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Logradouro { get; set; } = string.Empty;

    [XmlElement("nro")]
    [StringLength(10)]
    public string? Numero { get; set; }

    [XmlElement("xCpl")]
    [StringLength(60)]
    public string? Complemento { get; set; }

    [XmlElement("xBairro")]
    [Required]
    [StringLength(60, MinimumLength = 1)]
    public string Bairro { get; set; } = string.Empty;

    [XmlElement("cMun")]
    [Required]
    [Range(1000000, 9999999)]
    public int CodigoMunicipio { get; set; }

    [XmlElement("xMun")]
    [Required]
    [StringLength(60, MinimumLength = 1)]
    public string NomeMunicipio { get; set; } = string.Empty;

    [XmlElement("CEP")]
    [RegularExpression(@"[0-9]{8}", ErrorMessage = "CEP deve conter 8 dígitos")]
    public string? CEP { get; set; }

    [XmlElement("cPais")]
    [Range(1, 9999)]
    public int? CodigoPais { get; set; }

    [XmlElement("xPais")]
    [StringLength(60)]
    public string? NomePais { get; set; }
}