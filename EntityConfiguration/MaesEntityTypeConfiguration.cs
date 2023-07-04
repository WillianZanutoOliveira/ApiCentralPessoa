namespace ApiCentralPessoa.EntityConfiguration;
public class MaesEntityTypeConfiguration : IEntityTypeConfiguration<Mae>
{
    public void Configure(EntityTypeBuilder<Mae> builder)
    {
        builder
            .ToTable("Maes");

    }
}