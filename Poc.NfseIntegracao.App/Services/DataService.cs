using Poc.NfseIntegracao.App.DTOs;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Poc.NfseIntegracao.App.Services;
public class DataService
{
    public static void SaveData(string chaveAcesso, string cadastroNacional, string nomeEmitente, DateTime data)
    {
        try
        {
            var filePath = "Data/dados.json";
            List<object> dataList = new();

            if (File.Exists(filePath))
            {
                var existingJson = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(existingJson))
                {
                    dataList = JsonSerializer.Deserialize<List<object>>(existingJson) ?? new List<object>();
                }
            }

            var dataToSave = new NfseData
            {
                ChaveAcesso = chaveAcesso,
                CadastroNacional = cadastroNacional,
                NomeEmitente = nomeEmitente,
                DataProcessamento = data
            };

            dataList.Add(dataToSave);

            var json = JsonSerializer.Serialize(dataList, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving data: {ex.Message}");
        }
    }

    public static List<NfseData> GetNfseData()
    {
        var filePath = "Data/dados.json";
        List<NfseData> dataList = [];

        if (!File.Exists(filePath)) return dataList;
        var existingJson = File.ReadAllText(filePath);

        if (!string.IsNullOrWhiteSpace(existingJson))
        {
            dataList = JsonSerializer.Deserialize<List<NfseData>>(existingJson) ?? new List<NfseData>();
        }

        return dataList;
    }
}

