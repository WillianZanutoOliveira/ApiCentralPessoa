[🇺🇸 English](0001-modernize-to-dotnet-10.en.md)

# ADR-0001: Modernização do Central Pessoa para .NET 10

- **Status:** Aceito
- **Data:** 2026-10-03

## Contexto

O Central Pessoa foi criado originalmente em 2023 usando .NET 7 e um provider MySQL antigo para EF Core.

Como projeto público de portfólio, manter um runtime fora de suporte e credenciais de banco versionadas deixou de representar os padrões de engenharia esperados de um perfil Senior .NET atual.

## Decisão

Modernizar o projeto para .NET 10 e melhorar a higiene de configuração.

A mudança inclui:

- target framework alterado para `net10.0`;
- integração MySQL migrada para o provider atual `MySql.EntityFrameworkCore`;
- tooling de design do EF Core alinhado à linha de versões do .NET 10;
- dependências Swagger/OpenAPI atualizadas;
- credenciais de banco removidas do `appsettings.json` versionado;
- connection string movida para configuração por ambiente/user-secrets;
- inicialização do banco removida do construtor do DbContext;
- metadados de migration legados adaptados ao provider MySQL atual;
- pacotes AutoMapper vulneráveis e não utilizados removidos;
- GitHub Actions atualizado para buildar com .NET 10.

## Por que usar Pull Request

A modernização altera versões de pacotes, comportamento do provider e metadados de migration.

Para reduzir risco, o trabalho foi feito em uma branch dedicada e integrado apenas depois que o pipeline do GitHub Actions passou.

## Consequências

### Positivas

- runtime .NET atual;
- grafo de dependências mais limpo;
- nenhuma senha de banco na configuração atual versionada;
- construção do DbContext mais segura;
- prova pública no CI de que o projeto builda;
- evidência mais clara da evolução de engenharia.

### Trade-offs

- o projeto permanece intencionalmente pequeno;
- a criação do schema ainda usa `EnsureCreated()` pela simplicidade da demonstração;
- testes automatizados de integração contra MySQL são uma melhoria futura.

## Melhorias futuras

Possíveis próximos passos:

- substituir `EnsureCreated()` por uma estratégia controlada de migrations;
- adicionar testes de integração usando infraestrutura MySQL descartável;
- ampliar validação estruturada e Problem Details;
- adicionar health checks e observabilidade;
- containerizar o desenvolvimento local.
