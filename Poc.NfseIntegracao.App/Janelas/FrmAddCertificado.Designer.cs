﻿namespace Poc.NfseIntegracao.App.Janelas
{
    partial class FrmAddCertificado
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
            txtFile = new TextBox();
            btnFindFile = new Button();
            btnCancelar = new Button();
            button3 = new Button();
            label1 = new Label();
            dgFindFile = new OpenFileDialog();
            SuspendLayout();
            // 
            // txtFile
            // 
            txtFile.Location = new Point(12, 39);
            txtFile.Name = "txtFile";
            txtFile.ReadOnly = true;
            txtFile.Size = new Size(323, 23);
            txtFile.TabIndex = 0;
            // 
            // btnFindFile
            // 
            btnFindFile.Location = new Point(341, 39);
            btnFindFile.Name = "btnFindFile";
            btnFindFile.Size = new Size(44, 23);
            btnFindFile.TabIndex = 1;
            btnFindFile.Text = "...";
            btnFindFile.TextAlign = ContentAlignment.TopCenter;
            btnFindFile.UseVisualStyleBackColor = true;
            btnFindFile.Click += btnFindFile_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9.75F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(270, 76);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(115, 32);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Green;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9.75F);
            button3.ForeColor = Color.White;
            button3.Location = new Point(149, 76);
            button3.Name = "button3";
            button3.Size = new Size(115, 32);
            button3.TabIndex = 3;
            button3.Text = "Salvar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(116, 15);
            label1.TabIndex = 4;
            label1.Text = "Caminho do arquivo";
            // 
            // dgFindFile
            // 
            dgFindFile.FileName = "cert";
            dgFindFile.Filter = "certificado|*.pfx";
            // 
            // FrmAddCertificado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 120);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(btnCancelar);
            Controls.Add(btnFindFile);
            Controls.Add(txtFile);
            MaximizeBox = false;
            MaximumSize = new Size(411, 159);
            MinimizeBox = false;
            MinimumSize = new Size(411, 159);
            Name = "FrmAddCertificado";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Adicionar Certificado Digital";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFile;
        private Button btnFindFile;
        private Button btnCancelar;
        private Button button3;
        private Label label1;
        private OpenFileDialog dgFindFile;
    }
}