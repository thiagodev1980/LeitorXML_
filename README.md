# Processador de NFC-e

Projeto em grupo da Fábrica de Projetos (ADS – UNIMAR).

O programa lê os XMLs de NFC-e da pasta `C:\XmlNfce`, separa as notas de
consumidor final da série e da competência informadas e grava o resultado
num arquivo `envio.json`.

## Regras

A nota só entra no `envio.json` se passar em todas as regras:

- é NFC-e (modelo 65); NF-e modelo 55 é descartada
- foi autorizada pela Sefaz (`cStat` = 100)
- a série é igual à informada
- a competência (ano e mês de emissão) é igual à informada
- o destinatário não tem CPF nem CNPJ

As notas descartadas e o motivo de cada uma ficam no `log_processamento.txt`.

## Como usar

1. Coloque os XMLs em `C:\XmlNfce`
2. Abra a solução no Visual Studio e rode o projeto **FormsXml**
3. Na tela, informe a série e a competência
4. Clique em **Verificar** para conferir a pasta (o Gerar só é liberado depois disso)
5. Clique em **Gerar**

No fim aparece o resumo de notas gravadas e descartadas, e os botões para
abrir o `envio.json`, o log e a pasta.

## Exemplo do envio.json

```json
[
  {
    "chave": "35260144470771000118650010000009121060719696",
    "serie": "1",
    "modelo": "65",
    "competencia": "01/2026"
  }
]
```

A chave sai com os 44 dígitos, sem o prefixo "NFe" do XML, e a competência
no formato MM/AAAA.

## Estrutura

- **FormsXml**: tela em Windows Forms (etapas Dados, Verificar e Gerar)
- **LeitorXML**: biblioteca com a leitura e as regras
  - `IProcessadorNfce`: interface do processamento
  - `ProcessadorNfceAutorizadas`: aplica as regras, confere o cStat e grava o JSON
  - `LeitorXml`: lê as tags do XML
  - `NotaFiscal`: dados de uma nota
- **XML.Testes**: testes automatizados

## Testes

Os testes usam a pasta temporária do sistema, então rodam no Windows e no Linux.

- lote de 1.000 notas geradas na hora
- XML vazio
- XML inválido
- XML válido, conferindo os campos do JSON

No Visual Studio: **Teste → Gerenciador de Testes → Executar Todos**.
Pelo terminal: `dotnet test` dentro da pasta `LeitorXML`.

## Tecnologias

- C# / .NET 10
- Windows Forms
- `System.Xml.Linq` (XDocument) para ler os XMLs
- `System.Text.Json` para gerar o JSON
- xUnit para os testes

## Equipe

Thiago, João, Felipe, Higor e Daniel
