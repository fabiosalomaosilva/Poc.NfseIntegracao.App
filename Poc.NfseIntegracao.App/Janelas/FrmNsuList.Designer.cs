namespace Poc.NfseIntegracao.App.Janelas
{
    partial class FrmNsuList
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
            panel1 = new Panel();
            btnVerDanfe = new Button();
            btmFechar = new Button();
            btnPesquisar = new Button();
            txtNsu = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            nSUDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            chaveAcessoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tipoDocumentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataHoraGeracaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lotedfeBindingSource = new BindingSource(components);
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            txtXmlCompactado = new Poc.NfseIntegracao.App.Componentes.RichTextBoxWithLines();
            groupBox2 = new GroupBox();
            txtXmlDescompactado = new Poc.NfseIntegracao.App.Componentes.RichTextBoxWithLines();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lotedfeBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1250, 647);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnVerDanfe);
            panel1.Controls.Add(btmFechar);
            panel1.Controls.Add(btnPesquisar);
            panel1.Controls.Add(txtNsu);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1244, 59);
            panel1.TabIndex = 0;
            // 
            // btnVerDanfe
            // 
            btnVerDanfe.BackColor = Color.Goldenrod;
            btnVerDanfe.FlatStyle = FlatStyle.Flat;
            btnVerDanfe.Font = new Font("Segoe UI", 10F);
            btnVerDanfe.ForeColor = Color.Black;
            btnVerDanfe.Location = new Point(338, 16);
            btnVerDanfe.MinimumSize = new Size(0, 25);
            btnVerDanfe.Name = "btnVerDanfe";
            btnVerDanfe.Size = new Size(115, 32);
            btnVerDanfe.TabIndex = 4;
            btnVerDanfe.Text = "Ver DANFE";
            btnVerDanfe.UseVisualStyleBackColor = false;
            btnVerDanfe.Click += btnVerDanfe_Click;
            // 
            // btmFechar
            // 
            btmFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btmFechar.BackColor = Color.Red;
            btmFechar.FlatStyle = FlatStyle.Flat;
            btmFechar.Font = new Font("Segoe UI", 10F);
            btmFechar.ForeColor = Color.White;
            btmFechar.Location = new Point(1120, 16);
            btmFechar.MinimumSize = new Size(0, 25);
            btmFechar.Name = "btmFechar";
            btmFechar.Size = new Size(115, 32);
            btmFechar.TabIndex = 3;
            btmFechar.Text = "Fechar";
            btmFechar.UseVisualStyleBackColor = false;
            btmFechar.Click += btmFechar_Click;
            // 
            // btnPesquisar
            // 
            btnPesquisar.BackColor = Color.Green;
            btnPesquisar.FlatStyle = FlatStyle.Flat;
            btnPesquisar.Font = new Font("Segoe UI", 10F);
            btnPesquisar.ForeColor = Color.White;
            btnPesquisar.Location = new Point(217, 16);
            btnPesquisar.MinimumSize = new Size(0, 25);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(115, 32);
            btnPesquisar.TabIndex = 2;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = false;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // txtNsu
            // 
            txtNsu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNsu.Location = new Point(56, 16);
            txtNsu.MinimumSize = new Size(0, 32);
            txtNsu.Name = "txtNsu";
            txtNsu.Size = new Size(153, 32);
            txtNsu.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 22);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 0;
            label1.Text = "NSU:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nSUDataGridViewTextBoxColumn, chaveAcessoDataGridViewTextBoxColumn, tipoDocumentoDataGridViewTextBoxColumn, dataHoraGeracaoDataGridViewTextBoxColumn });
            dataGridView1.DataSource = lotedfeBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 68);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1244, 285);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // nSUDataGridViewTextBoxColumn
            // 
            nSUDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nSUDataGridViewTextBoxColumn.DataPropertyName = "NSU";
            nSUDataGridViewTextBoxColumn.HeaderText = "NSU";
            nSUDataGridViewTextBoxColumn.Name = "nSUDataGridViewTextBoxColumn";
            nSUDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // chaveAcessoDataGridViewTextBoxColumn
            // 
            chaveAcessoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            chaveAcessoDataGridViewTextBoxColumn.DataPropertyName = "ChaveAcesso";
            chaveAcessoDataGridViewTextBoxColumn.HeaderText = "ChaveAcesso";
            chaveAcessoDataGridViewTextBoxColumn.Name = "chaveAcessoDataGridViewTextBoxColumn";
            chaveAcessoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoDocumentoDataGridViewTextBoxColumn
            // 
            tipoDocumentoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tipoDocumentoDataGridViewTextBoxColumn.DataPropertyName = "TipoDocumento";
            tipoDocumentoDataGridViewTextBoxColumn.HeaderText = "TipoDocumento";
            tipoDocumentoDataGridViewTextBoxColumn.Name = "tipoDocumentoDataGridViewTextBoxColumn";
            tipoDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataHoraGeracaoDataGridViewTextBoxColumn
            // 
            dataHoraGeracaoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataHoraGeracaoDataGridViewTextBoxColumn.DataPropertyName = "DataHoraGeracao";
            dataHoraGeracaoDataGridViewTextBoxColumn.HeaderText = "DataHoraGeracao";
            dataHoraGeracaoDataGridViewTextBoxColumn.Name = "dataHoraGeracaoDataGridViewTextBoxColumn";
            dataHoraGeracaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lotedfeBindingSource
            // 
            lotedfeBindingSource.DataSource = typeof(DTOs.Lotedfe);
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 359);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Size = new Size(1244, 285);
            splitContainer1.SplitterDistance = 627;
            splitContainer1.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtXmlCompactado);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(627, 285);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "XML Compactado";
            // 
            // txtXmlCompactado
            // 
            txtXmlCompactado.Dock = DockStyle.Fill;
            txtXmlCompactado.Location = new Point(3, 19);
            txtXmlCompactado.Name = "txtXmlCompactado";
            txtXmlCompactado.Size = new Size(621, 263);
            txtXmlCompactado.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtXmlDescompactado);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(613, 285);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Arquivo XML";
            // 
            // txtXmlDescompactado
            // 
            txtXmlDescompactado.Dock = DockStyle.Fill;
            txtXmlDescompactado.Location = new Point(3, 19);
            txtXmlDescompactado.Name = "txtXmlDescompactado";
            txtXmlDescompactado.Size = new Size(607, 263);
            txtXmlDescompactado.TabIndex = 0;
            // 
            // FrmNsuList
            // 
            AcceptButton = btnPesquisar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btmFechar;
            ClientSize = new Size(1250, 647);
            Controls.Add(tableLayoutPanel1);
            Name = "FrmNsuList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consultar lotes por NSU";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lotedfeBindingSource).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button btnPesquisar;
        private TextBox txtNsu;
        private Label label1;
        private DataGridView dataGridView1;
        private BindingSource lotedfeBindingSource;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private Componentes.RichTextBoxWithLines txtXmlCompactado;
        private GroupBox groupBox2;
        private Componentes.RichTextBoxWithLines txtXmlDescompactado;
        private Button btmFechar;
        private DataGridViewTextBoxColumn nSUDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn chaveAcessoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tipoDocumentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataHoraGeracaoDataGridViewTextBoxColumn;
        private Button btnVerDanfe;
    }
}