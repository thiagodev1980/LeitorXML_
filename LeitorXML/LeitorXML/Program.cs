using LeitorXML.LeitorXml;
using System.Globalization;
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

foreach (string arquivoXml in Directory.GetFiles(pasta, "*.xml"))
{
    NotaFiscal nota = LeitorXml.Ler(arquivoXml);

    if (nota.Modelo == "65" && nota.Serie == serie && nota.Competencia == competencia && string.IsNullOrWhiteSpace(nota.CpfDest) && string.IsNullOrWhiteSpace(nota.CnpjDest))
    {
        Console.WriteLine($"SELECIONADA: {nota.Arquivo} | serie {nota.Serie} | {nota.Competencia} | {nota.Valor}");
    }
    else
    {
        Console.WriteLine($"descartada: {nota.Arquivo}");
    }
}