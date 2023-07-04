namespace ApiCentralPessoa.Models;

public class Endereco : EntityBase
{
    [Required]
    public Pessoa? Pessoa { get; private set; }

    [Required]
    public string Bairro { get; private set; } = string.Empty;

    [Required]
    public string CEP { get; private set; } = string.Empty;

    [Required]
    public string Cidade { get; private set; } = string.Empty;

    [Required]
    public string Complemento { get; private set; } = string.Empty;

    [Required]
    public string Logradouro { get; private set; } = string.Empty;

    [Required]
    public string Numero { get; private set; } = string.Empty;

    [Required]
    public string Pais { get; private set; } = string.Empty;

    [Required]
    public string UF { get; private set; } = string.Empty;

    [Required]
    public int PessoaId { get; internal set; }

    protected Endereco() { }

    public Endereco(Pessoa pessoa, string bairro, string cep, string cidade, string complemento, string logradouro, string numero, string pais, string uf)
    {
        Pessoa = pessoa;
        Bairro = bairro;
        Cidade = cidade;
        Complemento = complemento;
        Logradouro = logradouro;
        Numero = numero;
        Pais = pais;
        UF = uf;
    }


}
