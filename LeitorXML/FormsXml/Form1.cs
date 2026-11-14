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

			// o Gerar só é liberado depois que a pasta for verificada
			LiberarGerar(false);
		}

		// etapa 2: confere se a pasta existe e se tem arquivos XML
		private void btnVerificar_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists(pasta))
			{
				MostrarVerificacao($"✖ A pasta {pasta} não foi encontrada.", false);
				return;
			}

			int quantidade;

			try
			{
				quantidade = Directory.GetFiles(pasta, "*.xml").Length;
			}
			catch (UnauthorizedAccessException)
			{
				MostrarVerificacao($"✖ Sem permissão para ler a pasta {pasta}.", false);
				return;
			}

			if (quantidade == 0)
			{
				MostrarVerificacao("✖ Nenhum arquivo XML na pasta.", false);
				return;
			}

			MostrarVerificacao($"✔ {quantidade} arquivo(s) XML encontrado(s).", true);
		}

		// etapa 3: processa os XMLs e grava o envio.json
		private async void btnGerar_Click(object sender, EventArgs e)
		{
			// a série vem do NumericUpDown e a competência do DateTimePicker,
			// então o usuário não consegue digitar um valor inválido
			string serie = numSerie.Value.ToString();
			string competencia = dtpCompetencia.Value.ToString("yyyy-MM");
			string caminhoJson = Path.Combine(pasta, "envio.json");
			string caminhoLog = Path.Combine(pasta, "log_processamento.txt");

			// confere de novo, caso a pasta tenha sido apagada depois da verificação
			if (!Directory.Exists(pasta))
			{
				MostrarVerificacao($"✖ A pasta {pasta} não foi encontrada.", false);
				return;
			}

			// enquanto processa: bloqueia os botões e mostra a barra
			btnGerar.Enabled = false;
			btnVerificar.Enabled = false;
			progresso.Visible = true;
			lblStatus.Text = "Processando os arquivos... aguarde.";

			try
			{
				// apaga o envio.json anterior para não confundir com o resultado novo
				if (File.Exists(caminhoJson))
				{
					File.Delete(caminhoJson);
				}

				// roda em segundo plano para a janela não travar com muitos arquivos
				string log = await Task.Run(() => ProcessarArquivos(serie, competencia));

				// o log vai para um arquivo, e não para a tela
				File.WriteAllText(caminhoLog, log);

				if (!File.Exists(caminhoJson))
				{
					lblStatus.Text = "O envio.json não foi gerado. Veja o motivo no log.";
					return;
				}

				int selecionadas = ContarNotasDoJson(caminhoJson);
				int total = Directory.GetFiles(pasta, "*.xml").Length;
				int descartadas = total - selecionadas;

				lblStatus.Text = $"✔ {selecionadas} nota(s) gravada(s) · {descartadas} descartada(s)";
			}
			catch (UnauthorizedAccessException)
			{
				lblStatus.Text = "Erro ao processar.";
				MessageBox.Show($"Sem permissão para ler ou gravar na pasta {pasta}.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (IOException ex)
			{
				lblStatus.Text = "Erro ao processar.";
				MessageBox.Show("Erro ao acessar os arquivos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (JsonException)
			{
				lblStatus.Text = "Erro ao processar.";
				MessageBox.Show("O envio.json gerado não pôde ser lido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				// terminou: libera os botões e esconde a barra
				btnGerar.Enabled = true;
				btnVerificar.Enabled = true;
				progresso.Visible = false;
			}
		}

		// mostra o resultado da verificação e libera (ou não) o Gerar
		private void MostrarVerificacao(string mensagem, bool pastaOk)
		{
			lblVerificacao.Text = mensagem;

			if (pastaOk)
			{
				lblVerificacao.ForeColor = Color.FromArgb(120, 220, 140);
			}
			else
			{
				lblVerificacao.ForeColor = Color.FromArgb(255, 130, 130);
			}

			LiberarGerar(pastaOk);
		}

		// deixa o botão Gerar verde quando liberado e cinza quando bloqueado
		private void LiberarGerar(bool liberado)
		{
			btnGerar.Enabled = liberado;

			if (liberado)
			{
				btnGerar.BackColor = Color.FromArgb(16, 124, 16);
			}
			else
			{
				btnGerar.BackColor = Color.FromArgb(90, 90, 90);
			}
		}

		// chama o processador do Felipe e guarda as mensagens que ele
		// escreveria no console, para gravar depois no log
		private string ProcessarArquivos(string serie, string competencia)
		{
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

			return mensagens.ToString();
		}

		// conta quantas notas foram gravadas no envio.json
		private int ContarNotasDoJson(string caminhoJson)
		{
			string json = File.ReadAllText(caminhoJson);
			JsonSerializerOptions opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<NotaEnvio>? notas = JsonSerializer.Deserialize<List<NotaEnvio>>(json, opcoes);

			if (notas == null)
			{
				return 0;
			}

			return notas.Count;
		}

		private void btnAbrirJson_Click(object sender, EventArgs e)
		{
			AbrirNoBlocoDeNotas(Path.Combine(pasta, "envio.json"));
		}

		private void btnAbrirLog_Click(object sender, EventArgs e)
		{
			AbrirNoBlocoDeNotas(Path.Combine(pasta, "log_processamento.txt"));
		}

		private void btnAbrirPasta_Click(object sender, EventArgs e)
		{
			if (Directory.Exists(pasta))
			{
				Process.Start("explorer.exe", pasta);
			}
		}

		private void AbrirNoBlocoDeNotas(string caminho)
		{
			if (File.Exists(caminho))
			{
				Process.Start("notepad.exe", caminho);
			}
			else
			{
				MessageBox.Show("O arquivo ainda não foi gerado. Clique em Gerar primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}
