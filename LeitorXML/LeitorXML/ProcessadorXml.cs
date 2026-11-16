using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml;
using teste_xml;

namespace LeitorXML.LeitorXml
{
	public class ProcessadorXml
	{
		public int Processar(string pasta, string serie, string competencia)
		{
			string[] arquivos = Directory.GetFiles(pasta, "*.xml");

			List<object> envio = new List<object>();

			foreach (string arquivoXml in arquivos)
			{
				string nomeArquivo = Path.GetFileName(arquivoXml);

				try
				{
					NotaFiscal nota = LeitorXml.Ler(arquivoXml);

					if (nota == null)
					{
						continue;
					}

					if (nota.Modelo == "65" &&
						nota.Serie == serie &&
						nota.Competencia == competencia &&
						string.IsNullOrWhiteSpace(nota.CpfDest) &&
						string.IsNullOrWhiteSpace(nota.CnpjDest))
					{
						envio.Add(new
						{
							chave = nota.Chave,
							competencia = nota.Competencia,
							valor = nota.Valor
						});
					}
				}

				catch (XmlException)
				{
					continue;
				}
			}

			string caminhoJson = Path.Combine(pasta, "envio.json");

			string json = JsonSerializer.Serialize(
				envio,
				new JsonSerializerOptions { WriteIndented = true }
			);

			File.WriteAllText(caminhoJson, json);

			return envio.Count;
		}
	}
}
