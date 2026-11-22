using LeitorXML.LeitorXml;
using System.Diagnostics;
using System.Text.Json;
using Xunit;

namespace Xml.Testes;

public class ProcessadorNfceTestes
{
    [Fact]
    public void Deve_Processar_Lote_De_Mil_Notas_Sem_Internet_E_Gerar_Json()
    {
        string pastaTeste = Path.Combine(Path.GetTempPath(), $"XmlTeste_{Guid.NewGuid()}");
        Directory.CreateDirectory(pastaTeste);

        try
        {
            for (int i = 1; i <= 1000; i++)
            {
                string mod = (i % 10 == 0) ? "55" : "65";
                string cStat = (i % 5 == 0) ? "999" : "100";
                string destXml = (i % 2 == 0)
                    ? "<dest><CPF>12345678901</CPF></dest>"
                    : "<dest><xNome>CONSUMIDOR FINAL</xNome></dest>";

                string chave = i.ToString().PadLeft(44, '0');

                string xmlContent = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<nfeProc xmlns=""http://www.portalfiscal.inf.br/nfe"">
  <NFe>
    <infNFe Id=""NFe{chave}"">
      <ide>
        <mod>{mod}</mod>
        <serie>1</serie>
        <nNF>{i}</nNF>
        <dhEmi>2026-01-15T10:30:00-03:00</dhEmi>
      </ide>
      {destXml}
      <total>
        <ICMSTot>
          <vNF>10.50</vNF>
        </ICMSTot>
      </total>
    </infNFe>
  </NFe>
  <protNFe>
    <infProt>
      <cStat>{cStat}</cStat>
    </infProt>
  </protNFe>
</nfeProc>";

                File.WriteAllText(Path.Combine(pastaTeste, $"nfce_{i}.xml"), xmlContent);
            }

            var stopwatch = Stopwatch.StartNew();

            IProcessadorNfce processador = new ProcessadorNfceAutorizadas(pastaTeste);
            processador.Processar("1", "2026-01");

            stopwatch.Stop();

            string caminhoJson = Path.Combine(pastaTeste, "envio.json");

            Assert.True(File.Exists(caminhoJson), "O arquivo envio.json não foi gerado.");
            Assert.True(stopwatch.ElapsedMilliseconds < 10000,
                $"O processamento de 1.000 XMLs demorou {stopwatch.ElapsedMilliseconds} ms.");

            string jsonConteudo = File.ReadAllText(caminhoJson);
            using var docJson = JsonDocument.Parse(jsonConteudo);

            Assert.Equal(JsonValueKind.Array, docJson.RootElement.ValueKind);

            Assert.Equal(400, docJson.RootElement.GetArrayLength());
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
