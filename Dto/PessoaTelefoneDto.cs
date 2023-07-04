namespace ApiCentralPessoa.Dto;

public readonly struct PessoaTelefoneDto
{
    public int? Id { get; init; }
    public required string Nome { get; init; }
    public required string Email { get; init; }
    public required DateTime? DataAtualizacao { get; init; }
    public required DateTime? DataCriacao { get; init; }
    public required TipoTelefone TipoTelefone { get; init; }
    public required string Telefone { get; init; }
    public required bool SMS { get; init; }
    public required bool WhatsApp { get; init; }

}
