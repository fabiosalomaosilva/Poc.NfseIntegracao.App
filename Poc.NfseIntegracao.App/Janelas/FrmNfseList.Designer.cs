namespace Poc.NfseIntegracao.App.Janelas
{
    partial class FrmNfseList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            dataGridView1 = new DataGridView();
            bindingSource1 = new BindingSource(components);
            panel1 = new Panel();
            btnCancelar = new Button();
            btnVerXml = new Button();
            ChaveAcesso = new DataGridViewTextBoxColumn();
            CadastroNacional = new DataGridViewTextBoxColumn();
            NomeEmitente = new DataGridViewTextBoxColumn();
            Data = new DataGridViewTextBoxColumn();
            cTribNac = new DataGridViewTextBoxColumn();
            vServ = new DataGridViewTextBoxColumn();
            vBC = new DataGridViewTextBoxColumn();
            pAliqAplic = new DataGridViewTextBoxColumn();
            vISSQN = new DataGridViewTextBoxColumn();
            vLiq = new DataGridViewTextBoxColumn();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(1135, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ChaveAcesso, CadastroNacional, NomeEmitente, Data, cTribNac, vServ, vBC, pAliqAplic, vISSQN, vLiq });
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1129, 394);
            dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnVerXml);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 403);
            panel1.Name = "panel1";
            panel1.Size = new Size(1129, 44);
            panel1.TabIndex = 1;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9.75F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(1005, 6);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(115, 32);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += button2_Click;
            // 
            // btnVerXml
            // 
            btnVerXml.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVerXml.BackColor = Color.Green;
            btnVerXml.FlatStyle = FlatStyle.Flat;
            btnVerXml.Font = new Font("Segoe UI", 9.75F);
            btnVerXml.ForeColor = Color.White;
            btnVerXml.Location = new Point(884, 6);
            btnVerXml.Name = "btnVerXml";
            btnVerXml.Size = new Size(115, 32);
            btnVerXml.TabIndex = 0;
            btnVerXml.Text = "Ver DANFE";
            btnVerXml.UseVisualStyleBackColor = false;
            btnVerXml.Click += btnVerXml_Click;
            // 
            // ChaveAcesso
            // 
            ChaveAcesso.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ChaveAcesso.DataPropertyName = "ChaveAcesso";
            ChaveAcesso.FillWeight = 8.244996F;
            ChaveAcesso.HeaderText = "Chave de Acesso NFSe";
            ChaveAcesso.Name = "ChaveAcesso";
            ChaveAcesso.ReadOnly = true;
            // 
            // CadastroNacional
            // 
            CadastroNacional.DataPropertyName = "CadastroNacional";
            CadastroNacional.FillWeight = 78.94147F;
            CadastroNacional.HeaderText = "CPF/CNPJ";
            CadastroNacional.MinimumWidth = 150;
            CadastroNacional.Name = "CadastroNacional";
            CadastroNacional.ReadOnly = true;
            CadastroNacional.Width = 150;
            // 
            // NomeEmitente
            // 
            NomeEmitente.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NomeEmitente.DataPropertyName = "NomeEmitente";
            NomeEmitente.FillWeight = 8.244996F;
            NomeEmitente.HeaderText = "Nome emitente";
            NomeEmitente.Name = "NomeEmitente";
            NomeEmitente.ReadOnly = true;
            // 
            // Data
            // 
            Data.DataPropertyName = "DataProcessamento";
            Data.FillWeight = 304.568542F;
            Data.HeaderText = "Data do Processamento";
            Data.MinimumWidth = 170;
            Data.Name = "Data";
            Data.ReadOnly = true;
            Data.Resizable = DataGridViewTriState.False;
            Data.Width = 170;
            // 
            // cTribNac
            // 
            cTribNac.DataPropertyName = "cTribNac";
            cTribNac.HeaderText = "Tributo ISSQN";
            cTribNac.Name = "cTribNac";
            cTribNac.ReadOnly = true;
            // 
            // vServ
            // 
            vServ.DataPropertyName = "vServ";
            vServ.HeaderText = "Valor do Serviço";
            vServ.Name = "vServ";
            vServ.ReadOnly = true;
            // 
            // vBC
            // 
            vBC.DataPropertyName = "vBC";
            vBC.HeaderText = "BC ISSQN";
            vBC.Name = "vBC";
            vBC.ReadOnly = true;
            // 
            // pAliqAplic
            // 
            pAliqAplic.DataPropertyName = "pAliqAplic";
            pAliqAplic.HeaderText = "Alíquota Aplic";
            pAliqAplic.Name = "pAliqAplic";
            pAliqAplic.ReadOnly = true;
            // 
            // vISSQN
            // 
            vISSQN.DataPropertyName = "vISSQN";
            vISSQN.HeaderText = "ISSQN Apurado";
            vISSQN.Name = "vISSQN";
            vISSQN.ReadOnly = true;
            // 
            // vLiq
            // 
            vLiq.DataPropertyName = "vLiq";
            vLiq.HeaderText = "Valor Liq. NFSe";
            vLiq.Name = "vLiq";
            vLiq.ReadOnly = true;
            // 
            // FrmNfseList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(1135, 450);
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmNfseList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de NFSE";
            WindowState = FormWindowState.Maximized;
            Load += FrmNfseList_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridView1;
        private BindingSource bindingSource1;
        private Panel panel1;
        private Button btnCancelar;
        private Button btnVerXml;
        private DataGridViewTextBoxColumn ChaveAcesso;
        private DataGridViewTextBoxColumn CadastroNacional;
        private DataGridViewTextBoxColumn NomeEmitente;
        private DataGridViewTextBoxColumn Data;
        private DataGridViewTextBoxColumn cTribNac;
        private DataGridViewTextBoxColumn vServ;
        private DataGridViewTextBoxColumn vBC;
        private DataGridViewTextBoxColumn pAliqAplic;
        private DataGridViewTextBoxColumn vISSQN;
        private DataGridViewTextBoxColumn vLiq;
    }
}