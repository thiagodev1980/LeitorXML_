using System.Globalization;
using System.Xml.Linq;
using teste_xml;

namespace LeitorXML.LeitorXml
{
    public class LeitorXml
    {
        static XNamespace ns = "http://www.portalfiscal.inf.br/nfe";

        public static NotaFiscal Ler(string caminho)
        {
            XDocument doc = XDocument.Load(caminho);

            XElement infNFe = doc.Descendants(ns + "infNFe").FirstOrDefault();

            if (infNFe == null)
                return null;

            NotaFiscal nota = new NotaFiscal();

            nota.Arquivo = Path.GetFileName(caminho);

            string id = infNFe.Attribute("Id").Value;

            if (id.StartsWith("NFe"))
                id = id.Substring(3);

            nota.Chave = id;

            XElement ide = infNFe.Element(ns + "ide");
            XElement total = infNFe.Element(ns + "total").Element(ns + "ICMSTot");
            XElement dest = infNFe.Element(ns + "dest");

            nota.NumeroNF = ide.Element(ns + "nNF")?.Value;
            nota.Modelo = ide.Element(ns + "mod")?.Value;
            nota.Serie = ide.Element(ns + "serie")?.Value;

            string dhEmi = ide.Element(ns + "dhEmi")?.Value ?? "";

            if (dhEmi.Length >= 7)
                nota.Competencia = dhEmi.Substring(0, 7);
            else
                nota.Competencia = "";

            nota.Valor = Convert.ToDecimal(total.Element(ns + "vNF")?.Value, CultureInfo.InvariantCulture);
            nota.CpfDest = dest?.Element(ns + "CPF")?.Value;
            nota.CnpjDest = dest?.Element(ns + "CNPJ")?.Value;

            return nota;
        }
    }
}