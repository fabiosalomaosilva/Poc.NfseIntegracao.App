using Poc.NfseIntegracao.App.Janelas;
using Poc.NfseIntegracao.App.Services;
using Poc.NfseIntegracao.App.XSDs;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Poc.NfseIntegracao.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                txtApiResponse.Text = string.Empty;
                txtXmlCompactado.Text = string.Empty;
                txtXmlFinal.Text = string.Empty;

                using var serviceIntegration = new NfseIntegrationService();
                var xmlService = new XmlService();

                var chaveDps = xmlService.GerarChaveDpsAsync(txtXml.Controls[0].Text.Trim());
                var xmlComDps = xmlService.InserirNovaChave(txtXml.Controls[0].Text.Trim(), chaveDps, "infDPS");

                var chaveAcesso = xmlService.GerarChaveAcessoAsync(xmlComDps);
                var xmlComChaveAcesso = xmlService.InserirNovaChave(xmlComDps, chaveAcesso, "infNFSe");

                var xmlAssinado = xmlService.AssinarXml(xmlComChaveAcesso);
                var xmlValidator = new XmlValidator();

                //var xmlValidation = xmlValidator.ValidateXml(txtXml.Controls[0].Text.Trim());
                //if (!xmlValidation.IsValid)
                //{
                //    var json = JsonSerializer.Serialize(xmlValidation.Errors, new JsonSerializerOptions
                //    {
                //        WriteIndented = true,
                //        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                //    });
                //    var decodedJson = Regex.Unescape(json);

                //    using var rtbTemp = new RichTextBox();
                //    rtbTemp.Font = new Font("Consolas", 10);
                //    rtbTemp.Text = decodedJson;

                //    txtApiResponse.Rtf = rtbTemp.Rtf;

                //    return;
                //}

                txtXmlFinal.Controls[0].Text = xmlAssinado;

                var ehValido = xmlValidator.ValidarAssinaturaXml(xmlAssinado);

                if (!ehValido)
                {
                    MessageBox.Show("A assinatura do XML não é válida.");
                    return;
                }

                var xmlCompactado = await xmlService.CompactarXmlAsync(xmlAssinado);

                txtXmlCompactado.Text = xmlCompactado;

                var response = await serviceIntegration.CriarNfse(xmlCompactado);

                txtApiResponse.Text = response.Success
                    ? JsonSerializer.Serialize(response.Data, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping })
                        .ToString()
                    : JsonSerializer
                        .Serialize(response.ErrorMessage, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping })
                        .ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void certificadoDigitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmAddCertificado();
            frm.ShowDialog();
        }

        private void editarDadosDoEmitenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var xmlString = txtXml.Controls[0].Text;
            if (string.IsNullOrWhiteSpace(xmlString))
            {
                MessageBox.Show("Por favor, insira o XML antes de editar os dados do emitente.");
                return;
            }

            using var form = new FrmEditarDadosEmitentes(xmlString);

            if (form.ShowDialog() != DialogResult.OK) return;

            var xmlModificado = form.XmlAlterado;

            var rtb = new RichTextBox
            {
                Font = new Font("Consolas", 10),
                Text = xmlModificado,
                SelectionIndent = 2
            };

            txtXml.Controls[0].Text = rtb.Text;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
