namespace ApiCentralPessoa.Models;

public abstract class Pessoa : EntityBase
{
    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Nome { get; protected set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(254)]
    public string Email { get; protected set; } = string.Empty;

    public DateTime? DataAtualizacao { get; protected set; }

    public DateTime? DataCriacao { get; protected set; }

    protected Pessoa() { }
}
