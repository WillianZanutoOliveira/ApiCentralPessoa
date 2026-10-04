# Central Pessoa API

[![CI](https://github.com/WillianZanutoOliveira/ApiCentralPessoa/actions/workflows/ci.yml/badge.svg)](https://github.com/WillianZanutoOliveira/ApiCentralPessoa/actions/workflows/ci.yml)

REST API built with **C# / ASP.NET Core** for managing individuals and companies, including related addresses and phone information.

The project demonstrates CRUD operations, domain entities, relational persistence and API documentation.

## What this project demonstrates

- ASP.NET Core Web API
- RESTful CRUD endpoints
- Entity Framework Core
- MySQL persistence
- entity configuration
- DTOs and explicit mapping
- Swagger / OpenAPI
- asynchronous database operations

## Domain

The API models information related to:

- individuals;
- companies;
- addresses;
- phone numbers and phone types;
- related person information.

## Tech stack

- **C#**
- **.NET 10**
- **ASP.NET Core**
- **Entity Framework Core**
- **MySQL**
- **MySql.EntityFrameworkCore**
- **Swagger / OpenAPI**

> This project was created in 2023 and later modernized to **.NET 10**, with updated MySQL integration, safer configuration practices and CI validation.

## Engineering documentation

- [Architecture](docs/architecture.md)
- [ADR-0001 — Modernize to .NET 10](docs/adr/0001-modernize-to-dotnet-10.md)
- [Security & configuration](SECURITY.md)

## Architecture overview

```text
HTTP Client
    |
    v
ASP.NET Core Controllers
    |
    +--> DTOs / explicit mapping
    |
    +--> Domain entities
    |
    +--> EF Core DbContext
             |
             v
           MySQL
```

## Running locally

### Requirements

- .NET 10 SDK
- MySQL

Clone the repository:

```bash
git clone https://github.com/WillianZanutoOliveira/ApiCentralPessoa.git
cd ApiCentralPessoa
```

Configure the database connection string in the application configuration and then run:

```bash
dotnet restore
dotnet run --project ApiCentralPessoa.csproj
```

Swagger is enabled in the development environment and can be used to inspect and test the endpoints.

## Database

The project uses Entity Framework Core with MySQL. The repository includes entity configuration and migrations-related structure.

## Engineering evolution

Because this is an earlier portfolio project, there are areas I would approach differently in a current production system, including:

- clearer separation between composition/configuration and persistence;
- stronger automated test coverage;
- standardized migrations strategy;
- structured validation and error handling;
- CI/CD and containerized local execution;
- observability and health checks.

Showing that evolution is intentional: I use older public projects to demonstrate the progression from application development toward **senior software engineering and architecture**.

For current case studies and my professional profile:
- https://github.com/WillianZanutoOliveira


## Secure local configuration

Database credentials are intentionally **not committed** to the repository.

Configure the connection string using an environment variable or user-secrets.

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

This keeps credentials outside version control and better reflects production configuration practices.
