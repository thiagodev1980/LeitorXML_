﻿namespace FormsXml
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			pnlCabecalho = new Panel();
			lblTitulo = new Label();
			pnlDados = new Panel();
			lblEtapa1 = new Label();
			labelSerie = new Label();
			numSerie = new NumericUpDown();
			labelCompetencia = new Label();
			dtpCompetencia = new DateTimePicker();
			pnlVerificar = new Panel();
			lblEtapa2 = new Label();
			btnVerificar = new Button();
			lblVerificacao = new Label();
			pnlGerar = new Panel();
			lblEtapa3 = new Label();
			btnGerar = new Button();
			progresso = new ProgressBar();
			lblStatus = new Label();
			btnAbrirJson = new Button();
			btnAbrirLog = new Button();
			btnAbrirPasta = new Button();
			pnlCabecalho.SuspendLayout();
			pnlDados.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numSerie).BeginInit();
			pnlVerificar.SuspendLayout();
			pnlGerar.SuspendLayout();
			SuspendLayout();
			//
			// pnlCabecalho
			//
			pnlCabecalho.BackColor = Color.FromArgb(0, 120, 215);
			pnlCabecalho.Controls.Add(lblTitulo);
			pnlCabecalho.Dock = DockStyle.Top;
			pnlCabecalho.Location = new Point(0, 0);
			pnlCabecalho.Name = "pnlCabecalho";
			pnlCabecalho.Size = new Size(480, 64);
			pnlCabecalho.TabIndex = 0;
			//
			// lblTitulo
			//
			lblTitulo.AutoSize = true;
			lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTitulo.ForeColor = Color.White;
			lblTitulo.Location = new Point(24, 16);
			lblTitulo.Name = "lblTitulo";
			lblTitulo.Size = new Size(260, 32);
			lblTitulo.TabIndex = 0;
			lblTitulo.Text = "Leitor de XML";
			//
			// pnlDados
			//
			pnlDados.BackColor = Color.FromArgb(54, 54, 54);
			pnlDados.Controls.Add(lblEtapa1);
			pnlDados.Controls.Add(labelSerie);
			pnlDados.Controls.Add(numSerie);
			pnlDados.Controls.Add(labelCompetencia);
			pnlDados.Controls.Add(dtpCompetencia);
			pnlDados.Location = new Point(24, 84);
			pnlDados.Name = "pnlDados";
			pnlDados.Size = new Size(432, 108);
			pnlDados.TabIndex = 1;
			//
			// lblEtapa1
			//
			lblEtapa1.AutoSize = true;
			lblEtapa1.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEtapa1.ForeColor = Color.FromArgb(142, 197, 255);
			lblEtapa1.Location = new Point(14, 10);
			lblEtapa1.Name = "lblEtapa1";
			lblEtapa1.Size = new Size(160, 19);
			lblEtapa1.TabIndex = 0;
			lblEtapa1.Text = "1 · INFORME OS DADOS";
			//
			// labelSerie
			//
			labelSerie.AutoSize = true;
			labelSerie.Font = new Font("Segoe UI", 9F);
			labelSerie.ForeColor = Color.FromArgb(201, 206, 214);
			labelSerie.Location = new Point(14, 36);
			labelSerie.Name = "labelSerie";
			labelSerie.Size = new Size(41, 20);
			labelSerie.TabIndex = 1;
			labelSerie.Text = "Série";
			//
			// numSerie
			//
			numSerie.Font = new Font("Segoe UI", 10.2F);
			numSerie.ForeColor = Color.Black;
			numSerie.Location = new Point(14, 60);
			numSerie.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
			numSerie.Name = "numSerie";
			numSerie.Size = new Size(80, 30);
			numSerie.TabIndex = 2;
			numSerie.Value = new decimal(new int[] { 1, 0, 0, 0 });
			//
			// labelCompetencia
			//
			labelCompetencia.AutoSize = true;
			labelCompetencia.Font = new Font("Segoe UI", 9F);
			labelCompetencia.ForeColor = Color.FromArgb(201, 206, 214);
			labelCompetencia.Location = new Point(120, 36);
			labelCompetencia.Name = "labelCompetencia";
			labelCompetencia.Size = new Size(95, 20);
			labelCompetencia.TabIndex = 3;
			labelCompetencia.Text = "Competência";
			//
			// dtpCompetencia
			//
			dtpCompetencia.CustomFormat = "MM/yyyy";
			dtpCompetencia.Font = new Font("Segoe UI", 10.2F);
			dtpCompetencia.Format = DateTimePickerFormat.Custom;
			dtpCompetencia.Location = new Point(120, 60);
			dtpCompetencia.Name = "dtpCompetencia";
			dtpCompetencia.ShowUpDown = true;
			dtpCompetencia.Size = new Size(110, 30);
			dtpCompetencia.TabIndex = 4;
			//
			// pnlVerificar
			//
			pnlVerificar.BackColor = Color.FromArgb(54, 54, 54);
			pnlVerificar.Controls.Add(lblEtapa2);
			pnlVerificar.Controls.Add(btnVerificar);
			pnlVerificar.Controls.Add(lblVerificacao);
			pnlVerificar.Location = new Point(24, 204);
			pnlVerificar.Name = "pnlVerificar";
			pnlVerificar.Size = new Size(432, 96);
			pnlVerificar.TabIndex = 2;
			//
			// lblEtapa2
			//
			lblEtapa2.AutoSize = true;
			lblEtapa2.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEtapa2.ForeColor = Color.FromArgb(142, 197, 255);
			lblEtapa2.Location = new Point(14, 10);
			lblEtapa2.Name = "lblEtapa2";
			lblEtapa2.Size = new Size(120, 19);
			lblEtapa2.TabIndex = 0;
			lblEtapa2.Text = "2 · VERIFICAÇÃO";
			//
			// btnVerificar
			//
			btnVerificar.BackColor = Color.FromArgb(0, 120, 215);
			btnVerificar.Cursor = Cursors.Hand;
			btnVerificar.FlatAppearance.BorderSize = 0;
			btnVerificar.FlatStyle = FlatStyle.Flat;
			btnVerificar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnVerificar.ForeColor = Color.White;
			btnVerificar.Location = new Point(14, 38);
			btnVerificar.Name = "btnVerificar";
			btnVerificar.Size = new Size(130, 40);
			btnVerificar.TabIndex = 1;
			btnVerificar.Text = "Verificar";
			btnVerificar.UseVisualStyleBackColor = false;
			btnVerificar.Click += btnVerificar_Click;
			//
			// lblVerificacao
			//
			lblVerificacao.Font = new Font("Segoe UI", 9F);
			lblVerificacao.ForeColor = Color.FromArgb(201, 206, 214);
			lblVerificacao.Location = new Point(156, 38);
			lblVerificacao.Name = "lblVerificacao";
			lblVerificacao.Size = new Size(262, 40);
			lblVerificacao.TabIndex = 2;
			lblVerificacao.Text = "Clique em Verificar para conferir a pasta.";
			lblVerificacao.TextAlign = ContentAlignment.MiddleLeft;
			//
			// pnlGerar
			//
			pnlGerar.BackColor = Color.FromArgb(54, 54, 54);
			pnlGerar.Controls.Add(lblEtapa3);
			pnlGerar.Controls.Add(btnGerar);
			pnlGerar.Controls.Add(progresso);
			pnlGerar.Location = new Point(24, 312);
			pnlGerar.Name = "pnlGerar";
			pnlGerar.Size = new Size(432, 104);
			pnlGerar.TabIndex = 3;
			//
			// lblEtapa3
			//
			lblEtapa3.AutoSize = true;
			lblEtapa3.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEtapa3.ForeColor = Color.FromArgb(142, 197, 255);
			lblEtapa3.Location = new Point(14, 10);
			lblEtapa3.Name = "lblEtapa3";
			lblEtapa3.Size = new Size(140, 19);
			lblEtapa3.TabIndex = 0;
			lblEtapa3.Text = "3 · GERADOR DO JSON";
			//
			// btnGerar
			//
			btnGerar.BackColor = Color.FromArgb(0, 120, 215);
			btnGerar.Cursor = Cursors.Hand;
			btnGerar.FlatAppearance.BorderSize = 0;
			btnGerar.FlatStyle = FlatStyle.Flat;
			btnGerar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnGerar.ForeColor = Color.White;
			btnGerar.Location = new Point(14, 36);
			btnGerar.Name = "btnGerar";
			btnGerar.Size = new Size(404, 40);
			btnGerar.TabIndex = 1;
			btnGerar.Text = "Gerar";
			btnGerar.UseVisualStyleBackColor = false;
			btnGerar.Click += btnGerar_Click;
			//
			// progresso
			//
			progresso.Location = new Point(14, 84);
			progresso.MarqueeAnimationSpeed = 30;
			progresso.Name = "progresso";
			progresso.Size = new Size(404, 10);
			progresso.Style = ProgressBarStyle.Marquee;
			progresso.TabIndex = 2;
			progresso.Visible = false;
			//
			// lblStatus
			//
			lblStatus.BackColor = Color.FromArgb(47, 47, 47);
			lblStatus.Font = new Font("Segoe UI", 9.5F);
			lblStatus.Location = new Point(24, 428);
			lblStatus.Name = "lblStatus";
			lblStatus.Padding = new Padding(10, 0, 0, 0);
			lblStatus.Size = new Size(432, 36);
			lblStatus.TabIndex = 3;
			lblStatus.Text = "Informe a série e a competência e clique em Gerar.";
			lblStatus.TextAlign = ContentAlignment.MiddleLeft;
			//
			// btnAbrirJson
			//
			btnAbrirJson.BackColor = Color.FromArgb(90, 90, 90);
			btnAbrirJson.Cursor = Cursors.Hand;
			btnAbrirJson.FlatAppearance.BorderSize = 0;
			btnAbrirJson.FlatStyle = FlatStyle.Flat;
			btnAbrirJson.Font = new Font("Segoe UI", 9F);
			btnAbrirJson.ForeColor = Color.White;
			btnAbrirJson.Location = new Point(24, 476);
			btnAbrirJson.Name = "btnAbrirJson";
			btnAbrirJson.Size = new Size(140, 34);
			btnAbrirJson.TabIndex = 4;
			btnAbrirJson.Text = "Abrir envio.json";
			btnAbrirJson.UseVisualStyleBackColor = false;
			btnAbrirJson.Click += btnAbrirJson_Click;
			//
			// btnAbrirLog
			//
			btnAbrirLog.BackColor = Color.FromArgb(90, 90, 90);
			btnAbrirLog.Cursor = Cursors.Hand;
			btnAbrirLog.FlatAppearance.BorderSize = 0;
			btnAbrirLog.FlatStyle = FlatStyle.Flat;
			btnAbrirLog.Font = new Font("Segoe UI", 9F);
			btnAbrirLog.ForeColor = Color.White;
			btnAbrirLog.Location = new Point(172, 476);
			btnAbrirLog.Name = "btnAbrirLog";
			btnAbrirLog.Size = new Size(110, 34);
			btnAbrirLog.TabIndex = 5;
			btnAbrirLog.Text = "Abrir log";
			btnAbrirLog.UseVisualStyleBackColor = false;
			btnAbrirLog.Click += btnAbrirLog_Click;
			//
			// btnAbrirPasta
			//
			btnAbrirPasta.BackColor = Color.FromArgb(90, 90, 90);
			btnAbrirPasta.Cursor = Cursors.Hand;
			btnAbrirPasta.FlatAppearance.BorderSize = 0;
			btnAbrirPasta.FlatStyle = FlatStyle.Flat;
			btnAbrirPasta.Font = new Font("Segoe UI", 9F);
			btnAbrirPasta.ForeColor = Color.White;
			btnAbrirPasta.Location = new Point(290, 476);
			btnAbrirPasta.Name = "btnAbrirPasta";
			btnAbrirPasta.Size = new Size(110, 34);
			btnAbrirPasta.TabIndex = 6;
			btnAbrirPasta.Text = "Abrir pasta";
			btnAbrirPasta.UseVisualStyleBackColor = false;
			btnAbrirPasta.Click += btnAbrirPasta_Click;
			//
			// Form1
			//
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(64, 64, 64);
			ClientSize = new Size(480, 532);
			Controls.Add(btnAbrirPasta);
			Controls.Add(btnAbrirLog);
			Controls.Add(btnAbrirJson);
			Controls.Add(lblStatus);
			Controls.Add(pnlGerar);
			Controls.Add(pnlVerificar);
			Controls.Add(pnlDados);
			Controls.Add(pnlCabecalho);
			ForeColor = Color.White;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "Form1";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Processador de NFC-e";
			pnlCabecalho.ResumeLayout(false);
			pnlCabecalho.PerformLayout();
			pnlDados.ResumeLayout(false);
			pnlDados.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numSerie).EndInit();
			pnlVerificar.ResumeLayout(false);
			pnlVerificar.PerformLayout();
			pnlGerar.ResumeLayout(false);
			pnlGerar.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel pnlCabecalho;
		private Label lblTitulo;
		private Panel pnlDados;
		private Label lblEtapa1;
		private Label labelSerie;
		private NumericUpDown numSerie;
		private Label labelCompetencia;
		private DateTimePicker dtpCompetencia;
		private Panel pnlVerificar;
		private Label lblEtapa2;
		private Button btnVerificar;
		private Label lblVerificacao;
		private Panel pnlGerar;
		private Label lblEtapa3;
		private Button btnGerar;
		private ProgressBar progresso;
		private Label lblStatus;
		private Button btnAbrirJson;
		private Button btnAbrirLog;
		private Button btnAbrirPasta;
	}
}
