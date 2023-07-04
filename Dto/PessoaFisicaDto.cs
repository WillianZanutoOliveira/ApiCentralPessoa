namespace ApiCentralPessoa.Dto;

public readonly struct PessoaFisicaDto
{
    public required string CPF { get; init; }
    

    public required string Genero { get; init; }

    public required DateTime DataNascimento { get; init; }

    public required int MaeId { get; init; }
    public required int PaiId { get; init; }
    public Pai? Pai { get; init; }
    public Mae? Mae { get; init; }
    public DateTime? DataFalecimento { get; init; }

}
