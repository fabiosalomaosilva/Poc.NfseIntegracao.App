using Poc.NfseIntegracao.App.DTOs;
using Poc.NfseIntegracao.App.Services;

namespace Poc.NfseIntegracao.App.Janelas
{
    public partial class FrmNsuList : Form
    {
        public FrmNsuList()
        {
            InitializeComponent();
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNsu.Text)) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                var service = new NfseIntegrationService();
                var nsuData = await service.ConsultarLoteDfe(txtNsu.Text);
                lotedfeBindingSource.DataSource = nsuData;
                dataGridView1.DataSource = lotedfeBindingSource;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao consultar NSU: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var current = lotedfeBindingSource?.Current;
            if (current == null) return;

            var item = current as Lotedfe;

            txtXmlCompactado.Controls[0].Text = item?.ArquivoXml;

            var xmlService = new XmlService();
            var xml = await xmlService.DescompactarXmlAsync(item?.ArquivoXml);

            var xmlFormatado = xml;
            try
            {
                var doc = new System.Xml.XmlDocument();
                doc.LoadXml(xml);
                await using var stringWriter = new StringWriter();
                await using var xmlTextWriter = new System.Xml.XmlTextWriter(stringWriter);
                xmlTextWriter.Formatting = System.Xml.Formatting.Indented;
                doc.WriteContentTo(xmlTextWriter);
                xmlTextWriter.Flush();
                xmlFormatado = stringWriter.GetStringBuilder().ToString();
            }
            catch
            {
                // Se não for XML válido, mantém o texto original
            }

            var rtb = new RichTextBox
            {
                Font = new Font("Consolas", 10),
                Text = xmlFormatado,
                SelectionIndent = 2
            };

            txtXmlDescompactado.Controls[0].Text = rtb.Text;
        }

        private void btmFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
