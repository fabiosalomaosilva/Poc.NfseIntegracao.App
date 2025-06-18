using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models;

/// <summary>
/// Valor do serviço prestado
/// </summary>
public class VServPrest
{
    [XmlElement("vReceb")]
    [Required]
    [Range(0.01, 999999999999.99)]
    public decimal ValorRecebido { get; set; }

    [XmlElement("vServ")]
    [Range(0.01, 999999999999.99)]
    public decimal? ValorServico { get; set; }

    [XmlElement("vBC")]
    [Range(0, 999999999999.99)]
    public decimal? BaseCalculo { get; set; }
}