namespace ApiCentralPessoa.EntityConfiguration;

public class PessoasTelefonesEntityTypeConfiguration : IEntityTypeConfiguration<PessoaTelefone>
{
    public void Configure(EntityTypeBuilder<PessoaTelefone> builder)
    {
        builder
            .ToTable("PessoasTelefone");

        builder
            .Property(t => t.Telefone)
            .IsRequired();

        builder
            .Property(t => t.SMS)
            .IsRequired();

        builder
            .Property(t => t.WhatsApp)
            .IsRequired();

        builder
           .HasOne(t => t.TipoTelefone)
           .WithMany()
           .HasForeignKey(t => t.TipoTelefoneId)
           .IsRequired();
    }
}
