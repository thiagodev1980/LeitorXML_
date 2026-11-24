using System;
using System.Collections.Generic;
using System.Text;

namespace teste_xml
{
    // dados de uma nota lida do XML
    public class NotaFiscal
    {
        public string Arquivo { get; set; } = "";
        public string Chave { get; set; } = "";
        public string NumeroNF { get; set; } = "";
        public string Modelo { get; set; } = "";
        public string Serie { get; set; } = "";
        public string Competencia { get; set; } = ""; // ex: 2026-01
        public decimal Valor { get; set; }

        // se os dois estiverem vazios, é consumidor final
        public string? CpfDest { get; set; }
        public string? CnpjDest { get; set; }
    }
}
