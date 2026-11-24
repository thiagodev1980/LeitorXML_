using System.Globalization;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using teste_xml;

namespace LeitorXML.LeitorXml
{
    public class ProcessadorNfceAutorizadas : IProcessadorNfce
    {
        private static readonly XNamespace Ns = "http://www.portalfiscal.inf.br/nfe";
        private readonly string _pasta;

        // se não passar a pasta, usa a C:\XmlNfce
        public ProcessadorNfceAutorizadas(string pasta = @"C:\XmlNfce")
        {
            _pasta = pasta;
        }

        public void Processar(string serie, string competencia)
        {
            serie = (serie ?? "").Trim();
            competencia = (competencia ?? "").Trim();

            // a competência tem que vir no formato 2026-01
            if (!DateTime.TryParseExact(competencia, "yyyy-MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataCompetencia))
            {
                Console.WriteLine($"Competência inválida ({competencia}). Use o formato AAAA-MM (ex: 2026-01).");
                return;
            }

            // pega os XMLs da pasta, tratando pasta que não existe ou sem permissão
            string[] arquivos;
            try
            {
                arquivos = Directory.GetFiles(_pasta, "*.xml");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine($"A pasta {_pasta} não foi encontrada.");
                return;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Sem permissão para ler a pasta {_pasta}.");
                return;
            }

            if (arquivos.Length == 0)
            {
                Console.WriteLine($"Nenhum arquivo .xml encontrado em {_pasta}.");
                return;
            }

            // lista que vira o envio.json, e a competência já no formato 01/2026
            List<object> envio = new List<object>();
            string anoMesFormatado = dataCompetencia.ToString("MM/yyyy", CultureInfo.InvariantCulture);

            foreach (string arquivoXml in arquivos)
            {
                string nomeArquivo = Path.GetFileName(arquivoXml);

                try
                {
                    // usa o leitor que já existia
                    NotaFiscal? nota = LeitorXml.Ler(arquivoXml);

                    if (nota == null)
                    {
                        Console.WriteLine($"descartada: {nomeArquivo} (não é um XML de nota fiscal)");
                        continue;
                    }

                    string? cStat = LerStatusProtocolo(arquivoXml);

                    // regras do desafio: NFC-e, série e competência certas e sem CPF/CNPJ
                    bool regrasBasicas =
                        nota.Modelo == "65" &&
                        nota.Serie == serie &&
                        nota.Competencia == competencia &&
                        string.IsNullOrWhiteSpace(nota.CpfDest) &&
                        string.IsNullOrWhiteSpace(nota.CnpjDest);

                    // 100 = nota autorizada pela Sefaz
                    bool notaAutorizada = cStat == "100";

                    if (regrasBasicas && notaAutorizada)
                    {
                        Console.WriteLine($"SELECIONADA: {nota.Arquivo} (NF {nota.NumeroNF}) | serie {nota.Serie} | modelo {nota.Modelo} | {anoMesFormatado} | cStat {cStat}");

                        // só os campos que as diretrizes pedem
                        envio.Add(new
                        {
                            chave = nota.Chave,
                            serie = nota.Serie,
                            modelo = nota.Modelo,
                            competencia = anoMesFormatado
                        });
                    }
                    else
                    {
                        Console.WriteLine($"descartada: {nota.Arquivo} (NF {nota.NumeroNF} | serie {nota.Serie} | cStat {cStat ?? "N/A"})");
                    }
                }
                // se um arquivo der problema, avisa e segue para o próximo
                catch (XmlException)
                {
                    Console.WriteLine($"erro: {nomeArquivo} está corrompido ou não é um XML válido");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"erro ao ler {nomeArquivo}: {ex.Message}");
                }
            }

            // grava o envio.json na mesma pasta dos XMLs
            string caminhoJson = Path.Combine(_pasta, "envio.json");

            try
            {
                string json = JsonSerializer.Serialize(envio, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(caminhoJson, json);

                Console.WriteLine();
                Console.WriteLine($"{envio.Count} nota(s) gravada(s) em {caminhoJson}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Sem permissão para gravar o arquivo {caminhoJson}.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Erro ao gravar o envio.json: {ex.Message}");
            }
        }

        // lê o cStat dentro do protNFe, que é o status que a Sefaz devolveu
        private static string? LerStatusProtocolo(string caminho)
        {
            XDocument doc = XDocument.Load(caminho);
            return doc.Descendants(Ns + "protNFe")
                      .Descendants(Ns + "cStat")
                      .FirstOrDefault()?.Value?.Trim();
        }
    }
}
