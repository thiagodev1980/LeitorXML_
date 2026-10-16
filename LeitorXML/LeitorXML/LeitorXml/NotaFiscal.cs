using System;
using System.Collections.Generic;
using System.Text;

namespace teste_xml
{
    public class NotaFiscal
    {
        public string Arquivo { get; set; }
        public string Chave { get; set; }
        public string NumeroNF { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string Competencia { get; set; }
        public decimal Valor { get; set; }
        public string? CpfDest { get; set; }
        public string? CnpjDest { get; set; }
    }
}
