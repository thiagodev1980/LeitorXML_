using System.Diagnostics;
using System.Text.Json;
using LeitorXML.LeitorXml;

namespace FormsXml
{
	public partial class Form1 : Form
	{
		string pasta = @"C:\XmlNfce";

		public Form1()
		{
			InitializeComponent();
		}

		private void btnBuscar_Click(object sender, EventArgs e)
		{
			// a série vem do NumericUpDown e a competência do DateTimePicker,
			// então o usuário não consegue digitar um valor inválido
			string serie = numSerie.Value.ToString();
			string competencia = dtpCompetencia.Value.ToString("yyyy-MM");
			string caminhoJson = Path.Combine(pasta, "envio.json");

			if (!Directory.Exists(pasta))
			{
				MessageBox.Show($"A pasta {pasta} não foi encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				// apaga o envio.json anterior para não mostrar resultado velho
				if (File.Exists(caminhoJson))
				{
					File.Delete(caminhoJson);
				}

				// o processador do Felipe escreve as mensagens no Console;
				// aqui elas são guardadas para aparecer no log da tela
				StringWriter mensagens = new StringWriter();
				TextWriter saidaOriginal = Console.Out;
				Console.SetOut(mensagens);

				try
				{
					IProcessadorNfce processador = new ProcessadorNfceAutorizadas(pasta);
					processador.Processar(serie, competencia);
				}
				finally
				{
					Console.SetOut(saidaOriginal);
				}

				txtLog.Text = mensagens.ToString();

				if (!File.Exists(caminhoJson))
				{
					MessageBox.Show("O envio.json não foi gerado. Veja o motivo no log.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// lê o envio.json gerado e mostra as notas na tabela
				string json = File.ReadAllText(caminhoJson);
				JsonSerializerOptions opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				List<NotaEnvio> notas = JsonSerializer.Deserialize<List<NotaEnvio>>(json, opcoes) ?? new List<NotaEnvio>();

				dgvSelecionadas.DataSource = notas;
				dgvSelecionadas.Columns["Serie"].HeaderText = "Série";
				dgvSelecionadas.Columns["Competencia"].HeaderText = "Competência";
				dgvSelecionadas.Columns["Chave"].FillWeight = 300;

				int totalArquivos = Directory.GetFiles(pasta, "*.xml").Length;
				int descartadas = totalArquivos - notas.Count;

				lblResumo.Text = $"{notas.Count} selecionada(s) · {descartadas} descartada(s) de {totalArquivos} arquivo(s)";
				btnAbrirJson.Enabled = true;
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show($"Sem permissão para ler ou gravar na pasta {pasta}.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (IOException ex)
			{
				MessageBox.Show("Erro ao acessar o envio.json: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (JsonException)
			{
				MessageBox.Show("O envio.json gerado não pôde ser lido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnAbrirJson_Click(object sender, EventArgs e)
		{
			// abre o envio.json no Bloco de Notas
			string caminho = Path.Combine(pasta, "envio.json");

			if (File.Exists(caminho))
			{
				Process.Start("notepad.exe", caminho);
			}
		}
	}
}
