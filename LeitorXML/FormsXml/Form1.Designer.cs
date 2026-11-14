namespace FormsXml
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
			labelSerie = new Label();
			numSerie = new NumericUpDown();
			labelCompetencia = new Label();
			dtpCompetencia = new DateTimePicker();
			btnBuscar = new Button();
			labelSelecionadas = new Label();
			dgvSelecionadas = new DataGridView();
			labelLog = new Label();
			txtLog = new TextBox();
			lblResumo = new Label();
			btnAbrirJson = new Button();
			((System.ComponentModel.ISupportInitialize)numSerie).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvSelecionadas).BeginInit();
			SuspendLayout();
			//
			// labelSerie
			//
			labelSerie.AutoSize = true;
			labelSerie.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			labelSerie.Location = new Point(20, 22);
			labelSerie.Name = "labelSerie";
			labelSerie.Size = new Size(50, 23);
			labelSerie.TabIndex = 0;
			labelSerie.Text = "Série";
			//
			// numSerie
			//
			numSerie.Font = new Font("Segoe UI", 10.2F);
			numSerie.ForeColor = Color.Black;
			numSerie.Location = new Point(80, 18);
			numSerie.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
			numSerie.Name = "numSerie";
			numSerie.Size = new Size(80, 30);
			numSerie.TabIndex = 1;
			numSerie.Value = new decimal(new int[] { 1, 0, 0, 0 });
			//
			// labelCompetencia
			//
			labelCompetencia.AutoSize = true;
			labelCompetencia.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			labelCompetencia.Location = new Point(190, 22);
			labelCompetencia.Name = "labelCompetencia";
			labelCompetencia.Size = new Size(116, 23);
			labelCompetencia.TabIndex = 2;
			labelCompetencia.Text = "Competência";
			//
			// dtpCompetencia
			//
			dtpCompetencia.CustomFormat = "MM/yyyy";
			dtpCompetencia.Font = new Font("Segoe UI", 10.2F);
			dtpCompetencia.Format = DateTimePickerFormat.Custom;
			dtpCompetencia.Location = new Point(320, 18);
			dtpCompetencia.Name = "dtpCompetencia";
			dtpCompetencia.ShowUpDown = true;
			dtpCompetencia.Size = new Size(110, 30);
			dtpCompetencia.TabIndex = 3;
			//
			// btnBuscar
			//
			btnBuscar.BackColor = Color.FromArgb(0, 120, 215);
			btnBuscar.Cursor = Cursors.Hand;
			btnBuscar.FlatAppearance.BorderSize = 0;
			btnBuscar.FlatStyle = FlatStyle.Flat;
			btnBuscar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnBuscar.ForeColor = Color.White;
			btnBuscar.Location = new Point(460, 14);
			btnBuscar.Name = "btnBuscar";
			btnBuscar.Size = new Size(120, 38);
			btnBuscar.TabIndex = 4;
			btnBuscar.Text = "Buscar";
			btnBuscar.UseVisualStyleBackColor = false;
			btnBuscar.Click += btnBuscar_Click;
			//
			// labelSelecionadas
			//
			labelSelecionadas.AutoSize = true;
			labelSelecionadas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			labelSelecionadas.Location = new Point(20, 68);
			labelSelecionadas.Name = "labelSelecionadas";
			labelSelecionadas.Size = new Size(230, 20);
			labelSelecionadas.TabIndex = 5;
			labelSelecionadas.Text = "Notas selecionadas (envio.json)";
			//
			// dgvSelecionadas
			//
			dgvSelecionadas.AllowUserToAddRows = false;
			dgvSelecionadas.AllowUserToDeleteRows = false;
			dgvSelecionadas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
			dgvSelecionadas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			dgvSelecionadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvSelecionadas.BackgroundColor = Color.FromArgb(50, 50, 50);
			dgvSelecionadas.BorderStyle = BorderStyle.None;
			dgvSelecionadas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
			dgvSelecionadas.DefaultCellStyle.ForeColor = Color.Black;
			dgvSelecionadas.Location = new Point(20, 92);
			dgvSelecionadas.Name = "dgvSelecionadas";
			dgvSelecionadas.ReadOnly = true;
			dgvSelecionadas.RowHeadersVisible = false;
			dgvSelecionadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvSelecionadas.Size = new Size(720, 190);
			dgvSelecionadas.TabIndex = 6;
			//
			// labelLog
			//
			labelLog.AutoSize = true;
			labelLog.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			labelLog.Location = new Point(20, 294);
			labelLog.Name = "labelLog";
			labelLog.Size = new Size(170, 20);
			labelLog.TabIndex = 7;
			labelLog.Text = "Log do processamento";
			//
			// txtLog
			//
			txtLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			txtLog.BackColor = Color.FromArgb(30, 30, 30);
			txtLog.BorderStyle = BorderStyle.None;
			txtLog.Font = new Font("Consolas", 9F);
			txtLog.ForeColor = Color.FromArgb(220, 220, 220);
			txtLog.Location = new Point(20, 318);
			txtLog.Multiline = true;
			txtLog.Name = "txtLog";
			txtLog.ReadOnly = true;
			txtLog.ScrollBars = ScrollBars.Vertical;
			txtLog.Size = new Size(720, 160);
			txtLog.TabIndex = 8;
			//
			// lblResumo
			//
			lblResumo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			lblResumo.AutoSize = true;
			lblResumo.Font = new Font("Segoe UI", 10.2F);
			lblResumo.Location = new Point(20, 502);
			lblResumo.Name = "lblResumo";
			lblResumo.Size = new Size(400, 23);
			lblResumo.TabIndex = 9;
			lblResumo.Text = "Informe a série e a competência e clique em Buscar.";
			//
			// btnAbrirJson
			//
			btnAbrirJson.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnAbrirJson.BackColor = Color.FromArgb(90, 90, 90);
			btnAbrirJson.Cursor = Cursors.Hand;
			btnAbrirJson.Enabled = false;
			btnAbrirJson.FlatAppearance.BorderSize = 0;
			btnAbrirJson.FlatStyle = FlatStyle.Flat;
			btnAbrirJson.Font = new Font("Segoe UI", 10.2F);
			btnAbrirJson.ForeColor = Color.White;
			btnAbrirJson.Location = new Point(580, 494);
			btnAbrirJson.Name = "btnAbrirJson";
			btnAbrirJson.Size = new Size(160, 38);
			btnAbrirJson.TabIndex = 10;
			btnAbrirJson.Text = "Abrir envio.json";
			btnAbrirJson.UseVisualStyleBackColor = false;
			btnAbrirJson.Click += btnAbrirJson_Click;
			//
			// Form1
			//
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(64, 64, 64);
			ClientSize = new Size(760, 550);
			Controls.Add(btnAbrirJson);
			Controls.Add(lblResumo);
			Controls.Add(txtLog);
			Controls.Add(labelLog);
			Controls.Add(dgvSelecionadas);
			Controls.Add(labelSelecionadas);
			Controls.Add(btnBuscar);
			Controls.Add(dtpCompetencia);
			Controls.Add(labelCompetencia);
			Controls.Add(numSerie);
			Controls.Add(labelSerie);
			ForeColor = Color.White;
			MinimumSize = new Size(700, 480);
			Name = "Form1";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Processador de NFC-e";
			((System.ComponentModel.ISupportInitialize)numSerie).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvSelecionadas).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelSerie;
		private NumericUpDown numSerie;
		private Label labelCompetencia;
		private DateTimePicker dtpCompetencia;
		private Button btnBuscar;
		private Label labelSelecionadas;
		private DataGridView dgvSelecionadas;
		private Label labelLog;
		private TextBox txtLog;
		private Label lblResumo;
		private Button btnAbrirJson;
	}
}
