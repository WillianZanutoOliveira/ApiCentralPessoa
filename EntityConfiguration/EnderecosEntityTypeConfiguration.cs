namespace ApiCentralPessoa.EntityConfiguration;

public class EnderecosEntityTypeConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder
            .ToTable("Enderecos");

        builder
            .Property(e => e.Bairro)
            .IsRequired();

        builder
            .Property(e=> e.CEP)
            .IsRequired();

        builder
            .Property(e => e.Cidade)
            .IsRequired();

        builder
            .Property(e=> e.Complemento)
            .IsRequired();

        builder
            .Property(e=> e.Logradouro)
            .IsRequired();

        builder
            .Property(e=> e.Numero);

        builder
            .Property(e=> e.Pais);

        builder
            .HasOne(e => e.Pessoa)
            .WithMany()
            .HasForeignKey(t => t.PessoaId)
            .IsRequired();
    }
}
