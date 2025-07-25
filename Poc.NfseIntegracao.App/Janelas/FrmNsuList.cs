﻿using Poc.NfseIntegracao.App.DTOs;
using Poc.NfseIntegracao.App.Services;
using MotivoCancelamento = Poc.NfseIntegracao.App.Services.MotivoCancelamento;

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

                var prefeituraSelecionada = rbPatoBranco.Checked ? Prefeitura.PatoBranco : Prefeitura.RegenteFeijo;
                var ambienteSelecionado = rbProducaoRestrita.Checked ? Ambiente.Homologacao : Ambiente.Producao;

                var nsuData = await service.ConsultarLoteDfe(txtNsu.Text, prefeituraSelecionada, ambienteSelecionado);
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

        private async void btnVerDanfe_Click(object sender, EventArgs e)
        {
            try
            {
                var prefeituraSelecionada = rbPatoBranco.Checked ? Prefeitura.PatoBranco : Prefeitura.RegenteFeijo;
                var ambienteSelecionado = rbProducaoRestrita.Checked ? Ambiente.Homologacao : Ambiente.Producao;

                var data = lotedfeBindingSource.Current as Lotedfe;
                if (data == null) return;
                var service = new NfseIntegrationService();
                await service.ConsultarNfse(data.ChaveAcesso, prefeituraSelecionada, ambienteSelecionado);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var prefeituraSelecionada = rbPatoBranco.Checked ? Prefeitura.PatoBranco : Prefeitura.RegenteFeijo;
                var ambienteSelecionado = rbProducaoRestrita.Checked ? Ambiente.Homologacao : Ambiente.Producao;

                var data = lotedfeBindingSource.Current as Lotedfe;
                if (data == null) return;
                var service = new NfseIntegrationService();
                var result = await service.DowloadDanfeNfse(data.ChaveAcesso, prefeituraSelecionada, ambienteSelecionado);
                if (!result)
                    MessageBox.Show($"A chave de acesso não existe no ambiente de {ambienteSelecionado.GetDescription()}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbProducao.Checked)
                {
                    MessageBox.Show($"Não é permitido cancelar NFSe no ambiente de Produção", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var data = lotedfeBindingSource.Current as Lotedfe;
                if (data == null) return;
                var service = new NfseIntegrationService();
                var xmlService = new XmlService();

                var xmlDescompactado = await xmlService.DescompactarXmlAsync(data.ArquivoXml);

                var resultado = await NfSeCancelamentoService.CancelarNFSe(
                    xmlDescompactado,
                    MotivoCancelamento.ErroNaEmissao,
                    "Solicitação de cancelamento via integração",
                    forcarHomologacao: true
                );

                if (resultado.Sucesso)
                {
                    MessageBox.Show("Cancelamento realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Erro ao cancelar NFSe: {resultado.DetalhesErro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //await service.CancelarNota(xmlCompactado, data.ChaveAcesso);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
