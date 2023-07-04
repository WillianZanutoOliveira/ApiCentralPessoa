namespace ApiCentralPessoa.Models;

public class Pai : PessoaFisica
{
    public new int PaiId { get; protected set; }
    public string NomePai { get; set; } = string.Empty;
    protected Pai()
    {
    }

    public Pai (PaiDto paiDto)
    {
        Nome = paiDto.Nome;
        Email = paiDto.Email;
        DataAtualizacao = paiDto.DataAtualizacao;
        DataCriacao = paiDto.DataCriacao;
        CPF = paiDto.CPF;
        DataFalecimento = paiDto.DataFalecimento;
        NomePai = paiDto.NomePai;
    }
}
