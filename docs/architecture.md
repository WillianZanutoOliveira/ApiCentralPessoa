[🇺🇸 English](architecture.en.md)

# Arquitetura

## Visão geral

Central Pessoa é uma API REST para gerenciamento de dados relacionados a pessoas, como pessoas físicas, empresas, endereços e informações de telefone.

O projeto mantém uma estrutura deliberadamente simples de compreender, ao mesmo tempo em que demonstra design de API, persistência, validação, saúde operacional e quality gates automatizados.

```mermaid
flowchart LR
    Client[Cliente HTTP] --> API[ASP.NET Core Controllers]
    API --> DTO[DTOs / Validação]
    API --> Domain[Entidades de domínio]
    Domain --> EF[EF Core DbContext]
    Config[Configurações de entidades] --> EF
    EF --> MySQL[(MySQL)]

    API --> Errors[Problem Details / Global Exception Handler]
    Health[/health] --> App[Saúde da aplicação]
    Tests[NUnit + EF InMemory] --> API
    CI[GitHub Actions] --> Tests
    CI --> Container[Imagem Docker]
    Container --> MySQL
```

## Camada HTTP/API

Os controllers expõem endpoints REST e coordenam o comportamento da aplicação.

As convenções do ASP.NET Core `[ApiController]` fornecem respostas automáticas de validação para modelos inválidos. DataAnnotations reforçam a validação de campos comuns como nomes, e-mails e descrições de tipos de telefone.

## Tratamento de erros

Exceções não tratadas passam por uma implementação centralizada de `IExceptionHandler`.

A API retorna respostas estruturadas em **Problem Details** em vez de expor detalhes de implementação ou exceções brutas.

## Domínio e persistência

O projeto modela:

- pessoas;
- pessoas físicas;
- empresas;
- endereços;
- telefones e tipos de telefone;
- informações familiares relacionadas.

A persistência utiliza Entity Framework Core com mapeamentos explícitos via `IEntityTypeConfiguration<T>` e MySQL por meio de `MySql.EntityFrameworkCore`.

## Segurança da configuração

Credenciais de banco são intencionalmente excluídas da configuração versionada.

A connection string é fornecida por variáveis de ambiente ou .NET user-secrets:

```text
ConnectionStrings__DefaultConnection
```

## Saúde operacional

Um endpoint leve de health check é exposto em:

```text
GET /health
```

Isso oferece às plataformas de deployment e operadores um endpoint estável para verificações de liveness da aplicação.

## Estratégia de testes

A solução contém um projeto NUnit dedicado.

A cobertura automatizada inicial foca no controller de tipos de telefone e valida:

- comportamento de not-found;
- persistência na criação;
- comportamento de atualização.

Os testes usam EF Core InMemory para manter o ciclo de feedback rápido e determinístico.

## Quality gate no CI

O GitHub Actions:

1. restaura dependências;
2. compila a solução em modo Release;
3. executa testes automatizados;
4. coleta cobertura de código XPlat;
5. publica a cobertura como artefato de build.

## Histórico de modernização

O projeto foi construído originalmente em .NET 7 e posteriormente modernizado para .NET 10.

A modernização também incluiu configuração mais segura, limpeza de dependências e atualização do provider de migrations. Um hardening posterior adicionou validação, Problem Details, health checks e testes automatizados.

Consulte:

- [ADR-0001 — Modernização para .NET 10](adr/0001-modernize-to-dotnet-10.md)
- [Segurança](../SECURITY.md)

## Desenvolvimento local containerizado

O repositório inclui um Dockerfile multi-stage em .NET 10 e uma configuração Docker Compose que inicia:

- a API ASP.NET Core;
- MySQL 8.4;
- um volume local persistente para o banco.

Segredos são fornecidos por um arquivo local `.env` baseado em `.env.example`. O arquivo `.env` real fica excluído do controle de versão.

O pipeline de CI constrói a imagem Docker após o build da solução e os testes automatizados, adicionando um quality gate no nível de entrega.

## Manutenção de dependências

O Dependabot verifica mensalmente dependências NuGet e GitHub Actions e pode abrir Pull Requests focados em atualizações.
