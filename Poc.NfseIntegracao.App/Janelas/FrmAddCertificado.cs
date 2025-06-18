namespace Poc.NfseIntegracao.App.Janelas
{
    public partial class FrmAddCertificado : Form
    {
        public FrmAddCertificado()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFindFile_Click(object sender, EventArgs e)
        {
            var file = dgFindFile.ShowDialog();
            if (file == DialogResult.OK)
            {
                txtFile.Text = dgFindFile.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            const string path = "c:/CertificadoClientes";
            const string pathFile = "c:/CertificadoClientes/cert.pfx";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                File.Copy(txtFile.Text, pathFile);
                this.Close();
                return;
            }

            if (File.Exists(pathFile)) return;
            File.Copy(txtFile.Text, pathFile);
            this.Close();
        }
    }
}
