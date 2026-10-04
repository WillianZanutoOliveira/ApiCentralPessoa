# Architecture

## Overview

Central Pessoa is a REST API for managing person-related data such as individuals, companies, addresses and phone information.

The project keeps a deliberately understandable structure while demonstrating API design, persistence, validation, operational health and automated quality gates.

```mermaid
flowchart LR
    Client[HTTP Client] --> API[ASP.NET Core Controllers]
    API --> DTO[DTOs / Validation]
    API --> Domain[Domain Entities]
    Domain --> EF[EF Core DbContext]
    Config[Entity Configurations] --> EF
    EF --> MySQL[(MySQL)]

    API --> Errors[Problem Details / Global Exception Handler]
    Health[/health] --> App[Application Health]
    Tests[NUnit + EF InMemory] --> API
    CI[GitHub Actions] --> Tests
```

## HTTP/API layer

Controllers expose REST endpoints and coordinate application behavior.

ASP.NET Core `[ApiController]` conventions provide automatic validation responses for invalid models. DataAnnotations strengthen validation for common fields such as names, e-mail addresses and phone-type descriptions.

## Error handling

Unhandled exceptions flow through a centralized `IExceptionHandler` implementation.

The API returns structured **Problem Details** responses instead of leaking implementation details or raw exception output.

## Domain and persistence

The project models:

- people;
- individuals;
- companies;
- addresses;
- phone numbers and phone types;
- related family information.

Persistence uses Entity Framework Core with explicit `IEntityTypeConfiguration<T>` mappings and MySQL through `MySql.EntityFrameworkCore`.

## Configuration security

Database credentials are intentionally excluded from tracked configuration.

The connection string is supplied using environment variables or .NET user-secrets:

```text
ConnectionStrings__DefaultConnection
```

## Operational health

A lightweight health endpoint is exposed at:

```text
GET /health
```

This gives deployment platforms and operators a stable endpoint for application liveness checks.

## Testing strategy

The solution contains a dedicated NUnit test project.

Initial automated coverage focuses on the phone-type controller and validates:

- not-found behavior;
- persistence on create;
- update behavior.

Tests use EF Core InMemory to keep the feedback loop fast and deterministic.

## CI quality gate

GitHub Actions:

1. restores dependencies;
2. builds the solution in Release mode;
3. executes automated tests;
4. collects XPlat code coverage;
5. publishes coverage output as a build artifact.

## Modernization history

The project was originally built on .NET 7 and later modernized to .NET 10.

The modernization also included safer configuration, dependency cleanup and migration-provider updates. Subsequent quality hardening added validation, Problem Details, health checks and automated tests.

See:

- [ADR-0001 — Modernize to .NET 10](adr/0001-modernize-to-dotnet-10.md)
- [Security](../SECURITY.md)
