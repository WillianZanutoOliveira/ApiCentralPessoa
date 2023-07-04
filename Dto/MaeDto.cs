﻿namespace ApiCentralPessoa.Dto;

public readonly struct MaeDto
{
    public int? Id { get; init; }
    public required string Nome { get; init; }
    public required string Email { get; init; }
    public required DateTime? DataAtualizacao { get; init; }
    public required DateTime? DataCriacao { get; init; }
    public required string CPF { get; init; }
    public DateTime? DataFalecimento { get; init; }
    public string NomeMae { get; init; }
}
