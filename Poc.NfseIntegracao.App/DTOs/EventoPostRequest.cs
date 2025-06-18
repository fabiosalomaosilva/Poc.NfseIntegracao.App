using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Poc.NfseIntegracao.App.DTOs
{
    public class EventoPostRequest
    {
        [JsonPropertyName("pedidoRegistroEventoXmlGZipB64")]
        [Required(ErrorMessage = "Pedido de registro de evento XML compactado é obrigatório")]
        public string PedidoRegistroEventoXmlGZipB64 { get; set; } = string.Empty;

        [JsonIgnore]
        public string EventoXmlGZipB64
        {
            get => PedidoRegistroEventoXmlGZipB64;
            set => PedidoRegistroEventoXmlGZipB64 = value;
        }
    }

    public class EventosGetResponse
    {
        [JsonPropertyName("tipoAmbiente")]
        [Required]
        public int TipoAmbiente { get; set; }

        [JsonPropertyName("versaoAplicativo")]
        [Required]
        public string VersaoAplicativo { get; set; } = string.Empty;

        [JsonPropertyName("dataHoraProcessamento")]
        [Required]
        public DateTime DataHoraProcessamento { get; set; }

        [JsonPropertyName("chaveAcesso")]
        [Required]
        public string ChaveAcesso { get; set; } = string.Empty;

        [JsonPropertyName("eventos")]
        public List<EventoNfse>? Eventos { get; set; }

        [JsonPropertyName("alertas")]
        public List<MensagemProcessamento>? Alertas { get; set; }
    }

    public class EventoNfse
    {
        [JsonPropertyName("tipoEvento")]
        [Required]
        public string TipoEvento { get; set; } = string.Empty;

        [JsonPropertyName("dataHoraEvento")]
        [Required]
        public DateTime DataHoraEvento { get; set; }

        [JsonPropertyName("eventoXmlGZipB64")]
        public string? EventoXmlGZipB64 { get; set; }

        [JsonPropertyName("statusEvento")]
        public string? StatusEvento { get; set; }

        [JsonPropertyName("observacoes")]
        public string? Observacoes { get; set; }

        [JsonPropertyName("numeroSequencial")]
        public int? NumeroSequencial { get; set; }

        [JsonPropertyName("versaoEvento")]
        public string? VersaoEvento { get; set; }
    }


    public class DfeResponse
    {
        public Lote[] Lote { get; set; }
        public string TipoAmbiente { get; set; }
        public string VersaoAplicativo { get; set; }
        public DateTime DataHoraProcessamento { get; set; }
    }

    public class Lote
    {
        public string ChaveAcesso { get; set; }
        public string Nsu { get; set; }
        public string StatusProcessamento { get; set; }
        public Alerta[] Alertas { get; set; }
        public Erro[] Erros { get; set; }
    }

    public class Alerta
    {
        public object Mensagem { get; set; }
        public string[] Parametros { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Complemento { get; set; }
    }

    public class Erro
    {
        public object Mensagem { get; set; }
        public string[] Parametros { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Complemento { get; set; }
    }
}