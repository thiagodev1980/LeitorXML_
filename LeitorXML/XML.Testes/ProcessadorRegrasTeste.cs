using System.Text.Json;
using LeitorXML.LeitorXml;
using Xunit;

namespace Xml.Testes;

public class ProcessadorRegrasTeste
{
    [Fact]
    public void Deve_Ignorar_Xml_Vazio()
    {
        string pastaTeste = Path.Combine(Path.GetTempPath(), $"XmlTeste_{Guid.NewGuid()}");
        Directory.CreateDirectory(pastaTeste);

        try
        {
            File.WriteAllText(Path.Combine(pastaTeste, "nfce_vazio.xml"), "");

            IProcessadorNfce processador = new ProcessadorNfceAutorizadas(pastaTeste);
            processador.Processar("1", "2026-01");

            string jsonFilePath = Path.Combine(pastaTeste, "envio.json");
            Assert.True(File.Exists(jsonFilePath), "O arquivo envio.json deveria ter sido gerado.");

            using var docJson = JsonDocument.Parse(File.ReadAllText(jsonFilePath));
            Assert.Equal(JsonValueKind.Array, docJson.RootElement.ValueKind);
            Assert.Equal(0, docJson.RootElement.GetArrayLength());
        }
        finally
        {
            if (Directory.Exists(pastaTeste))
            {
                Directory.Delete(pastaTeste, recursive: true);
            }
        }
    }

    [Fact]
    public void Deve_Ignorar_Xml_Invalido()
    {
        string pastaTeste = Path.Combine(Path.GetTempPath(), $"XmlTeste_{Guid.NewGuid()}");
        Directory.CreateDirectory(pastaTeste);

        try
        {
            File.WriteAllText(Path.Combine(pastaTeste, "nfce_invalido.xml"), "<xml_invalido>");

            IProcessadorNfce processador = new ProcessadorNfceAutorizadas(pastaTeste);
            processador.Processar("1", "2026-01");

            string jsonFilePath = Path.Combine(pastaTeste, "envio.json");
            Assert.True(File.Exists(jsonFilePath), "O arquivo envio.json deveria ter sido gerado.");

            using var docJson = JsonDocument.Parse(File.ReadAllText(jsonFilePath));
            Assert.Equal(JsonValueKind.Array, docJson.RootElement.ValueKind);
            Assert.Equal(0, docJson.RootElement.GetArrayLength());
        }
        finally
        {
            if (Directory.Exists(pastaTeste))
            {
                Directory.Delete(pastaTeste, recursive: true);
            }
        }
    }

    [Fact]
    public void Deve_Aceitar_Xml_Valido()
    {
        string pastaTeste = Path.Combine(Path.GetTempPath(), $"XmlTeste_{Guid.NewGuid()}");
        Directory.CreateDirectory(pastaTeste);

        try
        {
            string chaveEsperada = "12345678901234567890123456789012345678901234";
            string xmlValido = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<nfeProc xmlns=""http://www.portalfiscal.inf.br/nfe"">
  <NFe>
    <infNFe Id=""NFe{chaveEsperada}"">
      <ide>
        <mod>65</mod>
        <serie>1</serie>
        <nNF>1</nNF>
        <dhEmi>2026-01-15T10:30:00-03:00</dhEmi>
      </ide>
      <dest>
        <xNome>CONSUMIDOR FINAL</xNome>
      </dest>
      <total>
        <ICMSTot>
          <vNF>10.50</vNF>
        </ICMSTot>
      </total>
    </infNFe>
  </NFe>
  <protNFe>
    <infProt>
      <cStat>100</cStat>
    </infProt>
  </protNFe>
</nfeProc>";

            File.WriteAllText(Path.Combine(pastaTeste, "nfce_valido.xml"), xmlValido);

            IProcessadorNfce processador = new ProcessadorNfceAutorizadas(pastaTeste);
            processador.Processar("1", "2026-01");

            string jsonFilePath = Path.Combine(pastaTeste, "envio.json");
            Assert.True(File.Exists(jsonFilePath), "O arquivo envio.json deveria ter sido gerado.");

            using var docJson = JsonDocument.Parse(File.ReadAllText(jsonFilePath));
            Assert.Equal(JsonValueKind.Array, docJson.RootElement.ValueKind);
            Assert.Equal(1, docJson.RootElement.GetArrayLength());

            JsonElement nota = docJson.RootElement[0];
            Assert.Equal(chaveEsperada, nota.GetProperty("chave").GetString());
            Assert.Equal("1", nota.GetProperty("serie").GetString());
            Assert.Equal("65", nota.GetProperty("modelo").GetString());
            Assert.Equal("01/2026", nota.GetProperty("competencia").GetString());
            Assert.False(nota.TryGetProperty("valor", out _), "O campo 'valor' não deveria existir no JSON.");
        }
        finally
        {
            if (Directory.Exists(pastaTeste))
            {
                Directory.Delete(pastaTeste, recursive: true);
            }
        }
    }
}
