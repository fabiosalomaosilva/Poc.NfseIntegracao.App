using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Informações da DPS conforme TCInfDPS
/// </summary>
public class InfDPS
{
    [XmlAttribute("Id")]
    [Required]
    [StringLength(45)]
    public string Id { get; set; } = string.Empty;

    [XmlElement("tpAmb")]
    [Required]
    [Range(1, 2, ErrorMessage = "Tipo de ambiente deve ser 1 (Produção) ou 2 (Homologação)")]
    public int TipoAmbiente { get; set; } = 2; // Homologação por padrão

    [XmlElement("dhEmi")]
    [Required]
    public DateTime DataHoraEmissao { get; set; } = DateTime.UtcNow;

    [XmlElement("verAplic")]
    [Required]
    [StringLength(20)]
    public string VersaoAplicativo { get; set; } = "1.00";

    [XmlElement("serie")]
    [Required]
    [StringLength(5)]
    public string Serie { get; set; } = "00001";

    [XmlElement("nDPS")]
    [Required]
    [Range(1, 999999999999999)]
    public long NumeroDPS { get; set; }

    [XmlElement("dCompet")]
    [Required]
    public DateTime DataCompetencia { get; set; } = DateTime.Today;

    [XmlElement("subst")]
    public Substituicao? Substituicao { get; set; }

    [XmlElement("infoPrest")]
    [Required]
    public InfoPrestador InfoPrestador { get; set; } = new InfoPrestador();

    [XmlElement("infoToma")]
    public InfoTomador? InfoTomador { get; set; }

    [XmlElement("infoInterm")]
    public InfoIntermediario? InfoIntermediario { get; set; }

    [XmlElement("serv")]
    [Required]
    public Serv Servico { get; set; } = new Serv();

    [XmlElement("infAdic")]
    public string? InformacoesAdicionais { get; set; }
}