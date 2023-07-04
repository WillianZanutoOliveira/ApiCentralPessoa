namespace ApiCentralPessoa.EntityConfiguration;

public class PaisEntityTypeConfiguration : IEntityTypeConfiguration<Pai>
{
    public void Configure(EntityTypeBuilder<Pai> builder)
    {
        builder
            .ToTable("Pais");
    }
}
