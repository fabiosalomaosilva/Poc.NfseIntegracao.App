using System.ComponentModel;

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

public enum Ambiente
{
    [Description("Produção")]
    Producao = 1,
    [Description("Produção restrita")]
    Homologacao = 2
}

public enum Prefeitura
{
    RegenteFeijo,
    PatoBranco
}