namespace ApiCentralPessoa.EntityConfiguration;

public class PessoasEntityTypeConfiguration : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder
            .ToTable("Pessoas");

        builder
            .HasKey(p => p.Id);

        builder
           .Property(tp => tp.Id)
           .ValueGeneratedOnAdd();

        builder
            .Property(p => p.Nome)
            .IsRequired();

        builder
            .Property(p => p.Email)
            .IsRequired();

        builder
            .Property(p => p.DataAtualizacao);

        builder
            .Property(p => p.DataCriacao);
    }
}
