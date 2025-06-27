using Poc.NfseIntegracao.App.DTOs;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Poc.NfseIntegracao.App.Services;
public class DataService
{
    public static void SaveData(NfseData nfseData, DateTime data)
    {
        try
        {
            var filePath = "c:/CertificadoClientes/Dados/dados.json";
            List<object> dataList = [];

            if (File.Exists(filePath))
            {
                var existingJson = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(existingJson))
                {
                    dataList = JsonSerializer.Deserialize<List<object>>(existingJson) ?? [];
                }
            }

            dataList.Add(nfseData);

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
        var filePath = "c:/CertificadoClientes/Dados/dados.json";
        List<NfseData> dataList = [];

        if (!File.Exists(filePath)) return dataList;
        var existingJson = File.ReadAllText(filePath);
        var file = new FileInfo(filePath);

        if (!string.IsNullOrWhiteSpace(existingJson))
        {
            dataList = JsonSerializer.Deserialize<List<NfseData>>(existingJson) ?? [];
        }

        return dataList;
    }
}

