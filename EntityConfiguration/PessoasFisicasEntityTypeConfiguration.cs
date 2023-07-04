namespace ApiCentralPessoa.EntityConfiguration;

public class PessoasFisicasEntityTypeConfiguration : IEntityTypeConfiguration<PessoaFisica>
{
    public void Configure(EntityTypeBuilder<PessoaFisica> builder)
    {
        builder
            .ToTable("PessoasFisicas");

        builder
            .Property(f => f.CPF)
            .IsRequired();

        builder
            .Property(f => f.DataNascimento)
            .IsRequired();

        builder
            .Property(f => f.Genero)
            .IsRequired();

        builder
            .Property(f => f.DataFalecimento);

        builder
            .HasOne(f => f.Mae)
            .WithOne()
            .HasForeignKey<PessoaFisica>(f => f.MaeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(f => f.Pai)
            .WithOne()
            .HasForeignKey<PessoaFisica>(f => f.PaiId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
