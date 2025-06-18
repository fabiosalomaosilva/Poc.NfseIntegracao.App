namespace Poc.NfseIntegracao.App.DTOs;

/// <summary>
/// Modelo de resposta simplificado
/// </summary>
public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public MensagemProcessamento? ErrorMessage { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}