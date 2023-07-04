namespace ApiCentralPessoa.Models;

public class PessoaTelefone : Pessoa
{
    [Required]
    public TipoTelefone? TipoTelefone { get; protected set; }

    [Required]
    public int TipoTelefoneId { get; protected set; }

    [Required]
    public string Telefone { get; protected set; } = string.Empty;

    [Required]
    public bool SMS { get; protected set; }

    [Required]
    public bool WhatsApp { get; protected set; }

    protected PessoaTelefone() { }

    public PessoaTelefone(PessoaTelefoneDto pessoaTelefoneDto)
    {
        Id = pessoaTelefoneDto.Id ?? 0;
        Nome = pessoaTelefoneDto.Nome;
        Email = pessoaTelefoneDto.Email;
        Telefone = pessoaTelefoneDto.Telefone;
        SMS = pessoaTelefoneDto.SMS;
        WhatsApp = pessoaTelefoneDto.WhatsApp;
        TipoTelefone = pessoaTelefoneDto.TipoTelefone;
        DataAtualizacao = pessoaTelefoneDto.DataAtualizacao;
        DataCriacao = pessoaTelefoneDto.DataCriacao;
    }

    public PessoaTelefone(
        string nome,
        string email,
        TipoTelefone tipoTelefone,
        string telefone,
        bool sms,
        bool whatsApp,
        DateTime? dataAtualizacao,
        DateTime? dataCriacao
    )
    {
        Nome = nome;
        Email = email;
        TipoTelefone = tipoTelefone;
        Telefone = telefone;
        SMS = sms;
        WhatsApp = whatsApp;
        DataAtualizacao = dataAtualizacao;
        DataCriacao = dataCriacao;
    }

}
