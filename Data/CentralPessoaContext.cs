using ApiCentralPessoa.EntityConfiguration;

namespace ApiCentralPessoa.Data;

public class CentralPessoaContext: DbContext
{
    public CentralPessoaContext(DbContextOptions<CentralPessoaContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
    public DbSet<PessoaFisica> PessoasFisicas { get; set; }
    public DbSet<Mae> Maes { get; set; }
    public DbSet<Pai> Pais { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<PessoaTelefone> PessoasTelefones { get; set; }
    public DbSet<TipoTelefone> TiposTelefones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PessoasEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new EnderecosEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PessoasFisicasEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MaesEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PaisEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PessoasJuridicasEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PessoasTelefonesEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TiposTelefonesEntityTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
