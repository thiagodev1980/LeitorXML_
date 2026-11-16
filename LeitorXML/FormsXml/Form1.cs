using System.Globalization;
using LeitorXML.LeitorXml;

namespace FormsXML
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btn_Buscar_Click(object sender, EventArgs e)
		{
			string serie = textBoxSerie.Text.Trim();
			string competencia = textBoxCompetencia.Text.Trim();

			string pasta = @"C:\NotasFiscal";

			if (!DateTime.TryParseExact(
				competencia,
				"yyyy-MM",
				CultureInfo.InvariantCulture,
				DateTimeStyles.None,
				out _))

			{
				MessageBox.Show("Erro ao digitar a competência. Digite a competência no formato AAAA-MM.\nExemplo: 2026-01");
				return;
			}

			try
			{
				// Cria um objeto da classe ProcessadorXml
				ProcessadorXml processador = new ProcessadorXml();

				// Executa a leitura dos XMLs
				int quantidade = processador.Processar(pasta, serie, competencia);

				MessageBox.Show(
					$"{quantidade} nota(s) selecionada(s)!\n" +
					$"Arquivo gerado em: {Path.Combine(pasta, "envio.json")}"
				);
			}
			catch (DirectoryNotFoundException)
			{
				MessageBox.Show("A pasta informada não foi encontrada.");
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Sem permissão para acessar a pasta ou gravar o JSON.");
			}
			catch (IOException ex)
			{
				MessageBox.Show($"Erro ao acessar os arquivos: {ex.Message}");
			}
		}
	}
}

