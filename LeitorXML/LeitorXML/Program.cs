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

    Console.WriteLine($"{nota.NumeroNF} | mod {nota.Modelo} | serie {nota.Serie} | {nota.Competencia} | {nota.Valor} | cpf: {nota.CpfDest} | cnpj: {nota.CnpjDest}");
}