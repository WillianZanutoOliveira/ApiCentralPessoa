[🇧🇷 Português](0001-modernize-to-dotnet-10.md)

# ADR-0001: Modernize Central Pessoa to .NET 10

- **Status:** Accepted
- **Date:** 2026-10-03

## Context

Central Pessoa was originally created in 2023 using .NET 7 and an older MySQL EF Core provider.

As a public portfolio project, keeping an end-of-life runtime and tracked database credentials no longer represented the engineering standards expected from a current Senior .NET profile.

## Decision

Modernize the project to .NET 10 and improve configuration hygiene.

The change includes:

- target framework changed to `net10.0`;
- MySQL integration moved to the current `MySql.EntityFrameworkCore` provider;
- EF Core design tooling aligned with the .NET 10 release line;
- Swagger/OpenAPI dependencies updated;
- database credentials removed from tracked `appsettings.json`;
- connection string moved to environment/user-secret configuration;
- database initialization removed from the DbContext constructor;
- legacy migration metadata adapted to the current MySQL provider;
- unused vulnerable AutoMapper packages removed;
- GitHub Actions updated to build with .NET 10.

## Why use a pull request

The modernization changes package versions, provider behavior and migration metadata.

To reduce risk, the work was performed in a dedicated branch and merged only after the GitHub Actions pipeline passed.

## Consequences

### Positive

- current .NET runtime;
- cleaner dependency graph;
- no database password in current tracked configuration;
- safer DbContext construction;
- public CI proof that the project builds;
- clearer evidence of engineering evolution.

### Trade-offs

- the project remains intentionally small;
- database schema creation still uses `EnsureCreated()` for demo simplicity;
- automated integration tests against MySQL are a future improvement.

## Future improvements

Potential next steps:

- replace `EnsureCreated()` with a controlled migrations strategy;
- add integration tests using disposable MySQL infrastructure;
- add structured validation and Problem Details;
- add health checks and observability;
- containerize local development.
