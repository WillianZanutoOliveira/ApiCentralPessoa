namespace ApiCentralPessoa.Models;
public abstract class Pessoa : EntityBase
{
    [Required]
    public string Nome { get; protected set; } = string.Empty;

    [Required]
    public string Email { get; protected set; } = string.Empty;

    public DateTime? DataAtualizacao { get; protected set; }

    public DateTime? DataCriacao { get; protected set; }

    protected Pessoa() { }
}
