# Security

## Secrets and credentials

Do not commit database passwords, API keys, tokens or other credentials to this repository.

The application expects the MySQL connection string from configuration outside source control.

### Environment variable

```text
ConnectionStrings__DefaultConnection
```

Example for local development:

```powershell
$env:ConnectionStrings__DefaultConnection="Server=localhost;Port=3306;Database=centralPessoa;Uid=YOUR_USER;Pwd=YOUR_PASSWORD;"
```

Use .NET user-secrets as an alternative for local development.

## Production guidance

For a production deployment:

- use a managed secret store or deployment-time secret injection;
- use a dedicated least-privilege database user;
- never reuse local development passwords;
- rotate credentials if exposure is suspected;
- keep dependency and vulnerability scanning enabled.

## Reporting a security issue

If you identify a security issue in this portfolio project, avoid publishing sensitive exploit details in a public issue. Contact the repository owner through the profile contact information instead.
