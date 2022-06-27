# API Validadora de transações - Universidade Positivo
API de validação de transações de uma rede blockchain simulada.

## Envolvidos no Projeto
- Bernardo Carneiro
- Heitor Hellou
- Othon Valentim

## Sobre a aplicação
A aplicação foi desenvolvida para validar transações financeiras, de uma rede local blockchain simulada, de um seletor que o selecionou para validar certa transação criada por um gerenciador. Logo, a API deve receber a transação e fazer somente as validações necessárias, retornando para o seletor se ela foi aprovada ou não.

## Arquitetura
Projeto com arquitetura baseada em:
- .NET Core 6
- Clean Architecture

## Dependências
- RestSharp
- Newtonsoft Json

## Como executar o projeto
Rode o projeto de preferência no Visual Studio 2022. Você pode utilizar o próprio swagger para enviar as requisições ou o Postman.

## UseCases
Quando um Validador é cadastrado no sistema do Seletor uma chave única é gerada e enviada para o Validador através da rota POST:

`/Chave`

```
{
  "chaveUnica": "string"
}
```

Para enviar transações para a validação basta consumir a rota POST abaixo:

`/Transacao`

```
{
  "id": 0,
  "remetente": 0,
  "recebedor": 0,
  "valor": 0,
  "horario": "string",
  "status": 0
}
```

## Fluxo da aplicação
- Deve ser cadastrado no sistema do Seletor
- Recebe chave única para validação
- É selecionado para validar certa transação
- Recebe transação
- Sincroniza com tempo do gerenciador
- Valida transação
- Retorna se transação foi aprovada ou não para o seletor

## Observações
O Validador não possui estrutura de banco de dados, por não precisar salvar informações diversas. A única informação salva é a chave única gerada pelo seletor, que pode ser reescrita caso o validador seja recadastrado.
