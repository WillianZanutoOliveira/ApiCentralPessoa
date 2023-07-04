namespace ApiCentralPessoa.Models;

public class TipoTelefone : EntityBase
{
    public string Descricao { get; private set; } = string.Empty;
    protected TipoTelefone() { }

    public TipoTelefone(string descricao)
    {
        Descricao = descricao;
    }
}
