namespace ApiCentralPessoa.EntityConfiguration;

public class PessoasJuridicasEntityTypeConfiguration : IEntityTypeConfiguration<PessoaJuridica>
{
    public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
    {
        builder
            .ToTable("PessoasJuridicas");

        builder
            .Property(j => j.Email)
            .IsRequired();

        builder
            .Property(j=> j.Nome)
            .IsRequired();

        builder
            .Property(j => j.CNPJ)
            .IsRequired();

        builder
            .Property(j=> j.RazaoSocial)
            .IsRequired();

        builder
            .Property(j=> j.Sigla)
            .IsRequired();

        builder
            .Property(j=> j.DataCriacao);

        builder
            .Property(j=> j.DataAtualizacao);
    }
}
