# ApiCentralPessoa
Desenvolver uma aplicação com API para cadastro de pessoa Física e jurídica. 

## Retorno da API
- Implementar as operações de criação (POST), consulta (GET) (Por Id e GetAll), atualização (PUT) e exclusão (DELETE) de todas as entidades.

## Requisitos

- .NET 7.0 SDK instalado ([Download](https://dotnet.microsoft.com/pt-br/download/dotnet/7.0))
- .NET CLI instalado ([Download](https://learn.microsoft.com/en-us/dotnet/machine-learning/how-to-guides/install-ml-net-cli?tabs=windows))
- Visual Studio ou Visual Studio Code (opcional)
- Banco MySql

## Caso inicie um novo banco de dados rodar os comandos abaixo para rodar as Migrations:

```bash

dotnet ef migrations add InitialCreate
 
dotnet ef database update
```

## Configuração

1. Clone o repositório para o seu ambiente local:
   ```bash
   git clone https://github.com/WillianZanutoOliveira/ApiCentralPessoa.git
   ```
   
2. Abra o projeto no Visual Studio ou Visual Studio Code.


## Executando o projeto

### Visual Studio

- Clique em "Start" ou pressione F5 para iniciar a aplicação.

### Visual Studio Code

- Abra um terminal na pasta do projeto e execute o seguinte comando:

```bash
dotnet run --project ApiCentralPessoa.csproj
```

## Executando o projeto

- O projeto tem o swagger implementado da API será executado e estará disponível na URL [https://localhost:7017;http://localhost:5159] ou verifique no cmd qual é a porta que ele está rodando o projeto.
