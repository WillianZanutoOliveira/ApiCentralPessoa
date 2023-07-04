namespace ApiCentralPessoa.Models;

public class Mae : PessoaFisica
{
    public new int MaeId { get; protected set; }

    [Required]
    public string NomeMae { get; protected set; } = string.Empty;

    protected Mae()
    {
    }

    public Mae (MaeDto maeDto)
    {
        Nome = maeDto.Nome;
        Email = maeDto.Email;
        DataAtualizacao = maeDto.DataAtualizacao;
        DataCriacao = maeDto.DataCriacao;
        CPF = maeDto.CPF;
        DataFalecimento = maeDto.DataFalecimento;
        NomeMae = maeDto.NomeMae;
        
    }
}

