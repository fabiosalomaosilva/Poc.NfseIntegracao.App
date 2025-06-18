using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Informações de valores do serviço
/// </summary>
public class InfoValores
{
    [XmlElement("vServPrest")]
    [Required]
    public VServPrest ValorServicoPrestado { get; set; } = new VServPrest();

    [XmlElement("vDescCondIncond")]
    public VDescCondIncond? ValorDesconto { get; set; }

    [XmlElement("vRetTrib")]
    public VRetTrib? ValorRetencaoTributaria { get; set; }

    [XmlElement("ISSQN")]
    public ISSQN? ISSQN { get; set; }

    [XmlElement("tribNac")]
    public TribNacional? TributacaoNacional { get; set; }

    [XmlElement("tribTotal")]
    public TribTotal? TributacaoTotal { get; set; }

    [XmlElement("infDedRed")]
    public List<InfoDedRed>? InfoDeducaoReducao { get; set; }
}