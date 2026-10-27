using LeitorXML.LeitorXml;
using System.Globalization;
using System.Xml;
using teste_xml;

string pasta = @"C:\XmlNfce";

Console.Write("Informe a série da NFC-e: ");
string serie = (Console.ReadLine() ?? "").Trim();

Console.Write("Informe a competência (AAAA-MM): ");
string competencia = (Console.ReadLine() ?? "").Trim();

// confere se a competência está no formato certo
while (!DateTime.TryParseExact(competencia, "yyyy-MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
{
    Console.Write("Formato inválido. Digite no formato AAAA-MM (ex: 2026-09): ");
    competencia = (Console.ReadLine() ?? "").Trim();
}

// tenta listar os XMLs da pasta
string[] arquivos;

try
{
    arquivos = Directory.GetFiles(pasta, "*.xml");
}
catch (DirectoryNotFoundException)
{
    Console.WriteLine($"A pasta {pasta} não foi encontrada.");
    return;
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine($"Sem permissão para ler a pasta {pasta}.");
    return;
}

if (arquivos.Length == 0)
{
    Console.WriteLine($"Nenhum arquivo .xml encontrado em {pasta}.");
    return;
}

foreach (string arquivoXml in arquivos)
{
    string nomeArquivo = Path.GetFileName(arquivoXml);

    try
    {
        NotaFiscal nota = LeitorXml.Ler(arquivoXml);

        if (nota == null)
        {
            Console.WriteLine($"descartada: {nomeArquivo} (não é um XML de nota fiscal)");
            continue;
        }

        if (nota.Modelo == "65" && nota.Serie == serie && nota.Competencia == competencia && string.IsNullOrWhiteSpace(nota.CpfDest) && string.IsNullOrWhiteSpace(nota.CnpjDest))
        {
            Console.WriteLine($"SELECIONADA: {nota.Arquivo} | serie {nota.Serie} | {nota.Competencia} | {nota.Valor}");
        }
        else
        {
            Console.WriteLine($"descartada: {nota.Arquivo}");
        }
    }
    catch (XmlException)
    {
        Console.WriteLine($"erro: {nomeArquivo} está corrompido ou não é um XML válido");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"erro ao ler {nomeArquivo}: {ex.Message}");
    }
}