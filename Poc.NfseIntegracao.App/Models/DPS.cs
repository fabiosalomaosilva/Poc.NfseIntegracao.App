using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Poc.NfseIntegracao.App.Models
{
    /// <summary>
    /// Declaração de Prestação de Serviço (DPS) conforme XSD v1.00
    /// </summary>
    [XmlRoot("DPS", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    public class DPS
    {
        [XmlAttribute("Id")]
        [Required]
        [StringLength(45)]
        [RegularExpression(@"DPS[0-9]{42}", ErrorMessage = "ID deve seguir o padrão DPS + 42 dígitos")]
        public string Id { get; set; } = string.Empty;

        [XmlElement("InfDPS")]
        [Required]
        public InfDPS InfDPS { get; set; } = new InfDPS();

        [XmlElement("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature? Signature { get; set; }
    }

    public class DPSResponse
    {
        [Required]
        [StringLength(45)]
        public string Id { get; set; } = string.Empty;
    }
}