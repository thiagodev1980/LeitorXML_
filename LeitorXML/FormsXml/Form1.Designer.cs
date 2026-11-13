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
			labelCompetencia = new Label();
			txtBoxSerie = new TextBox();
			txtBoxCompetencia = new TextBox();
			btnBuscar = new Button();
			label1 = new Label();
			SuspendLayout();
			// 
			// labelSerie
			// 
			labelSerie.AutoSize = true;
			labelSerie.Font = new Font("Arial Black", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			labelSerie.Location = new Point(163, 21);
			labelSerie.Name = "labelSerie";
			labelSerie.Size = new Size(79, 32);
			labelSerie.TabIndex = 0;
			labelSerie.Text = "Serie";
			// 
			// labelCompetencia
			// 
			labelCompetencia.AutoSize = true;
			labelCompetencia.Font = new Font("Arial Black", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			labelCompetencia.Location = new Point(123, 103);
			labelCompetencia.Name = "labelCompetencia";
			labelCompetencia.Size = new Size(178, 32);
			labelCompetencia.TabIndex = 1;
			labelCompetencia.Text = "Competencia";
			// 
			// txtBoxSerie
			// 
			txtBoxSerie.BackColor = Color.DarkGray;
			txtBoxSerie.BorderStyle = BorderStyle.FixedSingle;
			txtBoxSerie.Location = new Point(117, 56);
			txtBoxSerie.Name = "txtBoxSerie";
			txtBoxSerie.Size = new Size(184, 27);
			txtBoxSerie.TabIndex = 2;
			// 
			// txtBoxCompetencia
			// 
			txtBoxCompetencia.BackColor = Color.DarkGray;
			txtBoxCompetencia.BorderStyle = BorderStyle.FixedSingle;
			txtBoxCompetencia.Location = new Point(117, 138);
			txtBoxCompetencia.Name = "txtBoxCompetencia";
			txtBoxCompetencia.Size = new Size(184, 27);
			txtBoxCompetencia.TabIndex = 3;
			// 
			// btnBuscar
			// 
			btnBuscar.BackColor = Color.Transparent;
			btnBuscar.Font = new Font("Arial Black", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			btnBuscar.ForeColor = SystemColors.ActiveCaptionText;
			btnBuscar.Location = new Point(132, 188);
			btnBuscar.Name = "btnBuscar";
			btnBuscar.Size = new Size(158, 42);
			btnBuscar.TabIndex = 4;
			btnBuscar.Text = "Buscar";
			btnBuscar.UseVisualStyleBackColor = false;
			btnBuscar.Click += btnBuscar_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(168, 278);
			label1.Name = "label1";
			label1.Size = new Size(0, 20);
			label1.TabIndex = 5;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(64, 64, 64);
			ClientSize = new Size(417, 450);
			Controls.Add(label1);
			Controls.Add(btnBuscar);
			Controls.Add(txtBoxCompetencia);
			Controls.Add(txtBoxSerie);
			Controls.Add(labelCompetencia);
			Controls.Add(labelSerie);
			ForeColor = SystemColors.ButtonHighlight;
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelSerie;
		private Label labelCompetencia;
		private TextBox txtBoxSerie;
		private TextBox txtBoxCompetencia;
		private Button btnBuscar;
		private Label label1;
	}
}
