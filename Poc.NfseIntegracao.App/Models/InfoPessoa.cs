using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Informações de pessoa (física ou jurídica)
/// </summary>
public class InfoPessoa
{
    [XmlElement("tpInscr")]
    [Required]
    [Range(1, 4, ErrorMessage = "Tipo de inscrição: 1=CNPJ, 2=CPF, 3=CAEPF, 4=NIF")]
    public int TipoInscricao { get; set; }

    [XmlElement("nInscr")]
    [Required]
    [StringLength(40)]
    public string NumeroInscricao { get; set; } = string.Empty;

    [XmlElement("xNome")]
    [Required]
    [StringLength(115, MinimumLength = 2)]
    public string Nome { get; set; } = string.Empty;

    [XmlElement("xNomeFantasia")]
    [StringLength(60)]
    public string? NomeFantasia { get; set; }

    [XmlElement("endereco")]
    public Endereco? Endereco { get; set; }
}