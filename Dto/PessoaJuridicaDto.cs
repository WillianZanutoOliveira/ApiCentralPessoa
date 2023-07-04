namespace ApiCentralPessoa.Dto;

public readonly struct PessoaJuridicaDto
{
    public int? Id { get; init; }
    public required string Nome { get; init; }
    public required string Email { get; init; }
    public required DateTime? DataAtualizacao { get; init; }
    public required DateTime? DataCriacao { get; init; }
    public required string CNPJ { get; init; }
    public required string RazaoSocial { get; init; }
    public required string Sigla { get; init; }
}
