using LeitorXML.LeitorXml;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Linq;
using teste_xml;

string pasta = @"C:\NotasFiscais";

foreach (string arquivoXml in Directory.GetFiles(pasta, "*.xml"))
{
    NotaFiscal nota = LeitorXml.Ler(arquivoXml);

    Console.WriteLine($"{nota.NumeroNF} | mod {nota.Modelo} | serie {nota.Serie} | {nota.Competencia.Substring(0, 7)} | {nota.Valor} | cpf: {nota.CpfDest} | cnpj: {nota.CnpjDest}");
}