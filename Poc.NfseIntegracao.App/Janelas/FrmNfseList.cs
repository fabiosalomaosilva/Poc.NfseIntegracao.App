using Poc.NfseIntegracao.App.DTOs;
using Poc.NfseIntegracao.App.Services;

namespace Poc.NfseIntegracao.App.Janelas;
public partial class FrmNfseList : Form
{
    public FrmNfseList()
    {
        InitializeComponent();
    }

    private void FrmNfseList_Load(object sender, EventArgs e)
    {
        var dataList = DataService.GetNfseData();
        var lista = dataList.OrderByDescending(p => p.DataProcessamento);
        bindingSource1.DataSource = lista;
        dataGridView1.DataSource = bindingSource1;
        dataGridView1.Refresh();
    }

    private async void button2_Click(object sender, EventArgs e)
    {
        try
        {
            var data = bindingSource1.Current as NfseData;
            if (data == null) return;
            var service = new NfseIntegrationService();
            await service.DowloadDanfeNfse(data.ChaveAcesso);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private async void btnVerXml_Click(object sender, EventArgs e)
    {
        try
        {
            var data = bindingSource1.Current as NfseData;
            if (data == null) return;
            var service = new NfseIntegrationService();
            await service.ConsultarNfse(data.ChaveAcesso);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
