<div align="center">

[🇺🇸 English](README.en.md)

# Central Pessoa API

### .NET 10 REST API · EF Core · MySQL · Validation · Problem Details

[![CI](https://github.com/WillianZanutoOliveira/ApiCentralPessoa/actions/workflows/ci.yml/badge.svg)](https://github.com/WillianZanutoOliveira/ApiCentralPessoa/actions/workflows/ci.yml)
![.NET 10](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-Persistence-512BD4)
![MySQL](https://img.shields.io/badge/MySQL-Database-4479A1?logo=mysql&logoColor=white)
![Tests](https://img.shields.io/badge/Tests-NUnit-22C55E)
![Docker](https://img.shields.io/badge/Docker%20Compose-Ready-2496ED?logo=docker&logoColor=white)

</div>

API de portfólio com estilo de produção para gerenciamento de pessoas físicas, pessoas jurídicas, endereços e telefones, com foco em **configuração segura, validação, saúde operacional e verificações automatizadas de qualidade**.

**Links rápidos:** [Arquitetura](docs/architecture.md) · [ADR](docs/adr/0001-modernize-to-dotnet-10.md) · [Segurança](SECURITY.md) · [CI](https://github.com/WillianZanutoOliveira/ApiCentralPessoa/actions/workflows/ci.yml)

## O que este projeto demonstra

- ASP.NET Core Web API
- endpoints RESTful de CRUD
- Entity Framework Core
- persistência com MySQL
- configuração de entidades
- DTOs e mapeamento explícito
- Swagger / OpenAPI
- operações assíncronas de banco de dados
- tratamento centralizado de erros com Problem Details
- endpoint de health check para verificações operacionais
- testes automatizados com NUnit e EF Core InMemory
- CI com artefatos de cobertura de código

## Domínio

A API modela informações relacionadas a:

- pessoas físicas;
- pessoas jurídicas;
- endereços;
- telefones e tipos de telefone;
- informações de pessoas relacionadas.

## Stack técnica

- **C#**
- **.NET 10**
- **ASP.NET Core**
- **Entity Framework Core**
- **MySQL**
- **MySql.EntityFrameworkCore**
- **Swagger / OpenAPI**
- **NUnit**
- **GitHub Actions**
- **Docker / Docker Compose**

> Este projeto foi criado em 2023 e posteriormente modernizado para **.NET 10**, com integração MySQL atualizada, práticas de configuração mais seguras e validação pelo CI.

## Documentação de engenharia

- [Arquitetura](docs/architecture.md)
- [ADR-0001 — Modernização para .NET 10](docs/adr/0001-modernize-to-dotnet-10.md)
- [Segurança e configuração](SECURITY.md)

## Visão geral da arquitetura

```text
Cliente HTTP
    |
    v
ASP.NET Core Controllers
    |
    +--> DTOs / mapeamento explícito
    |
    +--> Entidades de domínio
    |
    +--> EF Core DbContext
             |
             v
           MySQL
```

## Executando localmente

### Requisitos

- .NET 10 SDK
- MySQL

Clone o repositório:

```bash
git clone https://github.com/WillianZanutoOliveira/ApiCentralPessoa.git
cd ApiCentralPessoa
```

Configure a connection string do banco na configuração da aplicação e execute:

```bash
dotnet restore
dotnet run --project ApiCentralPessoa.csproj
```

O Swagger fica habilitado no ambiente de desenvolvimento e pode ser usado para inspecionar e testar os endpoints.

A saúde operacional é exposta em:

```text
GET /health
```

## Banco de dados

O projeto utiliza Entity Framework Core com MySQL. O repositório inclui configuração das entidades e estrutura relacionada a migrations.

## Evolução de engenharia

Como este é um projeto anterior do portfólio, existem pontos que eu trataria de forma diferente em um sistema atual de produção, incluindo:

- separação mais clara entre composição/configuração e persistência;
- cobertura mais ampla de testes de integração para os demais controllers;
- estratégia padronizada de migrations;
- execução local totalmente containerizada;
- observabilidade mais rica e health checks conscientes do estado do banco.

Mostrar essa evolução é intencional: utilizo projetos públicos mais antigos para evidenciar a progressão de desenvolvimento de aplicações para **engenharia de software sênior e arquitetura**.

Para cases atuais e meu perfil profissional:
- https://github.com/WillianZanutoOliveira

## Configuração local segura

Credenciais de banco são intencionalmente **não versionadas** no repositório.

Configure a connection string por variável de ambiente ou user-secrets.

### PowerShell

```powershell
$env:ConnectionStrings__DefaultConnection="Server=localhost;Port=3306;Database=centralPessoa;Uid=YOUR_USER;Pwd=YOUR_PASSWORD;"
dotnet run
```

### Bash

```bash
export ConnectionStrings__DefaultConnection="Server=localhost;Port=3306;Database=centralPessoa;Uid=YOUR_USER;Pwd=YOUR_PASSWORD;"
dotnet run
```

Isso mantém credenciais fora do controle de versão e se aproxima melhor das práticas de configuração usadas em produção.

## Docker Compose

Um ambiente local completo está disponível com a API e o MySQL.

Crie seu arquivo local de ambiente:

```bash
cp .env.example .env
```

Altere as senhas de exemplo no arquivo `.env` e suba a stack:

```bash
docker compose up --build
```

A API ficará disponível em:

```text
http://localhost:8080
```

O arquivo `.env` é ignorado pelo Git, portanto credenciais locais não são versionadas.

## Testes

Execute a suíte de testes automatizados com:

```bash
dotnet test ApiCentralPessoa.sln
```

O pipeline público de CI executa o mesmo fluxo de build e testes da solution e coleta cobertura de código como artefato do GitHub Actions.

## Resiliência da API

Exceções não tratadas são processadas por um handler centralizado e retornadas usando o formato **Problem Details** do ASP.NET Core.

Com `[ApiController]` e DataAnnotations, modelos de requisição inválidos são retornados como respostas HTTP 400 estruturadas.
