namespace ApiCentralPessoa.Models;

public class TipoTelefone : EntityBase
{
    [Required]
    [StringLength(80, MinimumLength = 2)]
    public string Descricao { get; protected set; } = string.Empty;

    protected TipoTelefone() { }

    public TipoTelefone(string descricao)
    {
        Descricao = descricao;
    }

    public void AtualizarDescricao(string novaDescricao)
    {
        Descricao = novaDescricao;
    }
}
