namespace ApiCentralPessoa.Models;

public class PessoaFisica : Pessoa
{
    [Required]
    public string CPF { get; protected set; } = string.Empty;

    [Required]
    public string Genero { get; protected set; } = string.Empty;

    [Required]
    public DateTime DataNascimento { get; protected set; } 

    [Required]
    public int MaeId { get; protected set; }

    [Required]
    public int PaiId { get; protected set; }
    public Pai? Pai { get; protected set; }
    public Mae? Mae { get; protected set; }

    public DateTime? DataFalecimento { get; protected set; }

    protected PessoaFisica() { }

    public PessoaFisica(PessoaFisicaDto pessoaFisicaDto)
    {
        CPF = pessoaFisicaDto.CPF;
        DataFalecimento = pessoaFisicaDto.DataFalecimento;
        Genero = pessoaFisicaDto.Genero;
        DataNascimento = pessoaFisicaDto.DataNascimento;
        Pai = pessoaFisicaDto.Pai;
        Mae = pessoaFisicaDto.Mae;
        DataFalecimento = pessoaFisicaDto.DataFalecimento;
    }

    public PessoaFisica(
       string cpf,
       string genero,
       DateTime dataNascimento,
       Pai? pai,
       Mae? mae,
       DateTime? dataFalecimento
   )
    {
        CPF = cpf;
        Genero = genero;
        DataNascimento = dataNascimento;
        Pai = pai;
        Mae = mae;
        DataFalecimento = dataFalecimento;
    }
}

