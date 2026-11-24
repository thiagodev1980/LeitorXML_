using System.Globalization;
using System.Xml.Linq;
using teste_xml;

namespace LeitorXML.LeitorXml
{
    public class LeitorXml
    {
        // sem o namespace o XDocument não acha as tags da nota
        static XNamespace ns = "http://www.portalfiscal.inf.br/nfe";

        // abre o XML e devolve a nota preenchida
        public static NotaFiscal? Ler(string caminho)
        {
            XDocument doc = XDocument.Load(caminho);

            XElement? infNFe = doc.Descendants(ns + "infNFe").FirstOrDefault();

            // não achou o infNFe, então não é uma nota
            if (infNFe == null)
                return null;

            NotaFiscal nota = new NotaFiscal();

            nota.Arquivo = Path.GetFileName(caminho);

            // a chave vem no Id com "NFe" na frente, tiramos para sobrar os 44 dígitos
            string id = infNFe.Attribute("Id")?.Value ?? "";

            if (id.StartsWith("NFe"))
                id = id.Substring(3);

            nota.Chave = id;

            // se alguma tag faltar, o campo fica vazio em vez de dar erro
            XElement? ide = infNFe.Element(ns + "ide");
            XElement? total = infNFe.Element(ns + "total")?.Element(ns + "ICMSTot");
            XElement? dest = infNFe.Element(ns + "dest");

            nota.NumeroNF = ide?.Element(ns + "nNF")?.Value ?? "";
            nota.Modelo = ide?.Element(ns + "mod")?.Value ?? "";
            nota.Serie = ide?.Element(ns + "serie")?.Value ?? "";

            // da data de emissão pegamos só ano e mês (2026-01)
            string dhEmi = ide?.Element(ns + "dhEmi")?.Value ?? "";

            if (dhEmi.Length >= 7)
                nota.Competencia = dhEmi.Substring(0, 7);
            else
                nota.Competencia = "";

            decimal.TryParse(total?.Element(ns + "vNF")?.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor);
            nota.Valor = valor;

            // se a nota não tiver destinatário, CPF e CNPJ ficam null
            nota.CpfDest = dest?.Element(ns + "CPF")?.Value;
            nota.CnpjDest = dest?.Element(ns + "CNPJ")?.Value;

            return nota;
        }
    }
}