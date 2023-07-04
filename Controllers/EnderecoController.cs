namespace ApiCentralPessoa.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnderecoController : ControllerBase
{
    private readonly CentralPessoaContext _context;

    public EnderecoController(CentralPessoaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Endereco>>> GetAll()
    {
        return await _context.Enderecos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Endereco>> GetById(int id)
    {
        var endereco = await _context.Enderecos.FindAsync(id);

        if (endereco == null)
        {
            return NotFound();
        }

        return Ok(endereco);
    }

    [HttpPost]
    public ActionResult<Endereco> Post(Endereco endereco)
    {
        // Lógica para adicionar o endereço ao banco de dados ou outra fonte de dados
        // ...

        // Simulando uma resposta de sucesso com o endereço adicionado
        return CreatedAtAction(nameof(GetById), new { id = endereco.Id }, endereco);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Endereco endereco)
    {
        var enderecoExistente = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if (enderecoExistente == null)
        {
            return NotFound();
        }

        // Lógica para atualizar o endereço no banco de dados ou outra fonte de dados
        // ...

        // Simulando uma resposta de sucesso
        return NoContent();
    }

    [HttpGet("ByPessoa")]
    public ActionResult<IEnumerable<Endereco>> GetByPessoa(int pessoaId)
    {
        var enderecos = _context.Enderecos.Where(e => e.PessoaId == pessoaId).ToList();

        // Simulando uma resposta com a lista de endereços encontrados
        return Ok(enderecos);
    }
}
