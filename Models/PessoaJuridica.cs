namespace ApiCentralPessoa.Models;

public class PessoaJuridica : Pessoa
{
    [Required]
    public string CNPJ { get; private set; } = string.Empty;

    [Required]
    public string RazaoSocial { get; private set; } = string.Empty;

    [Required]
    public string Sigla { get; private set; } = string.Empty;

    protected PessoaJuridica() { }

    public PessoaJuridica(PessoaJuridicaDto pessoaJuridicaDto)
    {
        Id = pessoaJuridicaDto.Id ?? 0;
        Nome = pessoaJuridicaDto.Nome;
        Email = pessoaJuridicaDto.Email;
        DataAtualizacao = pessoaJuridicaDto.DataAtualizacao;
        DataCriacao = pessoaJuridicaDto.DataCriacao;
        CNPJ = pessoaJuridicaDto.CNPJ;
        RazaoSocial = pessoaJuridicaDto.RazaoSocial;
        Sigla = pessoaJuridicaDto.Sigla;
    }

    public PessoaJuridica(
        string nome,
        string email,
        string cnpj,
        string razaoSocial,
        string sigla,
        DateTime? dataAtualizacao,
        DateTime? dataCriacao
    )
    {
        Nome = nome;
        Email = email;
        CNPJ = cnpj;
        RazaoSocial = razaoSocial;
        Sigla = sigla;
        DataAtualizacao = dataAtualizacao;
        DataCriacao = dataCriacao;
    }
}