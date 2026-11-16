namespace FormsXML
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
			btn_Buscar = new Button();
			textBoxSerie = new TextBox();
			textBoxCompetencia = new TextBox();
			SuspendLayout();
			// 
			// labelSerie
			// 
			labelSerie.AutoSize = true;
			labelSerie.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
			labelSerie.ForeColor = Color.WhiteSmoke;
			labelSerie.Location = new Point(230, 54);
			labelSerie.Name = "labelSerie";
			labelSerie.Size = new Size(100, 32);
			labelSerie.TabIndex = 0;
			labelSerie.Text = "SERIE";
			// 
			// labelCompetencia
			// 
			labelCompetencia.AutoSize = true;
			labelCompetencia.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
			labelCompetencia.ForeColor = Color.WhiteSmoke;
			labelCompetencia.Location = new Point(176, 146);
			labelCompetencia.Name = "labelCompetencia";
			labelCompetencia.Size = new Size(226, 32);
			labelCompetencia.TabIndex = 1;
			labelCompetencia.Text = "COMPETENCIA";
			// 
			// btn_Buscar
			// 
			btn_Buscar.BackColor = Color.Gray;
			btn_Buscar.Cursor = Cursors.Hand;
			btn_Buscar.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btn_Buscar.ForeColor = Color.WhiteSmoke;
			btn_Buscar.Location = new Point(230, 249);
			btn_Buscar.Name = "btn_Buscar";
			btn_Buscar.Size = new Size(112, 44);
			btn_Buscar.TabIndex = 2;
			btn_Buscar.Text = "Buscar";
			btn_Buscar.UseVisualStyleBackColor = false;
			btn_Buscar.Click += btn_Buscar_Click;
			// 
			// textBoxSerie
			// 
			textBoxSerie.Location = new Point(193, 89);
			textBoxSerie.Name = "textBoxSerie";
			textBoxSerie.Size = new Size(194, 27);
			textBoxSerie.TabIndex = 3;
			// 
			// textBoxCompetencia
			// 
			textBoxCompetencia.Location = new Point(193, 192);
			textBoxCompetencia.Name = "textBoxCompetencia";
			textBoxCompetencia.Size = new Size(194, 27);
			textBoxCompetencia.TabIndex = 4;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.DimGray;
			ClientSize = new Size(566, 384);
			Controls.Add(textBoxCompetencia);
			Controls.Add(textBoxSerie);
			Controls.Add(btn_Buscar);
			Controls.Add(labelCompetencia);
			Controls.Add(labelSerie);
			ForeColor = Color.Black;
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelSerie;
		private Label labelCompetencia;
		private Button btn_Buscar;
		private TextBox textBoxSerie;
		private TextBox textBoxCompetencia;
	}
}
