namespace ApiCentralPessoa.EntityConfiguration;

public class TiposTelefonesEntityTypeConfiguration : IEntityTypeConfiguration<TipoTelefone>
{
    public void Configure(EntityTypeBuilder<TipoTelefone> builder)
    {
        builder
            .ToTable("TiposTelefones");

        builder
            .HasKey(tp => tp.Id);

        builder
            .Property(tp => tp.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(tp => tp.Descricao)
            .IsRequired();
    }
}
