namespace ApiCentralPessoa.Models;

public class TipoTelefone : EntityBase
{
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
