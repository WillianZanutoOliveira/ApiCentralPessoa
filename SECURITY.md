[🇺🇸 English](SECURITY.en.md)

# Segurança

## Segredos e credenciais

Não versione senhas de banco de dados, chaves de API, tokens ou outras credenciais neste repositório.

A aplicação espera receber a connection string do MySQL por configuração externa ao controle de versão.

### Variável de ambiente

```text
ConnectionStrings__DefaultConnection
```

Exemplo para desenvolvimento local:

```powershell
$env:ConnectionStrings__DefaultConnection="Server=localhost;Port=3306;Database=centralPessoa;Uid=YOUR_USER;Pwd=YOUR_PASSWORD;"
```

Como alternativa para desenvolvimento local, utilize .NET user-secrets.

## Orientações para produção

Para um deployment em produção:

- utilize um cofre de segredos gerenciado ou injeção de segredos no momento do deployment;
- use um usuário de banco dedicado com privilégio mínimo;
- nunca reutilize senhas do ambiente de desenvolvimento local;
- rotacione credenciais caso exista suspeita de exposição;
- mantenha verificações de dependências e vulnerabilidades habilitadas.

## Reportando um problema de segurança

Se você identificar um problema de segurança neste projeto de portfólio, evite publicar detalhes sensíveis de exploração em uma issue pública. Entre em contato com o proprietário do repositório pelas informações de contato disponíveis no perfil.
