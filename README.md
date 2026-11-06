# Processador de NFC-e

Projeto em grupo da Fábrica de Projetos (ADS – UNIMAR).

O programa lê os XMLs de NFC-e de uma pasta, separa as notas que servem
para as instituições e gera um arquivo `envio.json` com as chaves e o
imposto pago.

## Regras

- Só considera NFC-e modelo 65 (modelo 55 é descartado)
- Só entram notas sem CPF do destinatário
- O valor usado é o imposto pago, não o valor total da nota

## Como usar

1. Coloque os XMLs em `C:\XmlNfce`
2. Rode o projeto e informe a série e a competência
3. O `envio.json` é gerado ao final

## Tecnologias

- C# / .NET 10 (aplicação console)

## Equipe

Thiago, João, Felipe e Higor
