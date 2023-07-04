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

    public async Task<IActionResult> Post(Endereco endereco)
    {
        await _context.Enderecos.AddAsync(endereco);

        await _context.SaveChangesAsync();

        return Ok(endereco);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Endereco endereco)
    {
        var enderecoExistente = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if (enderecoExistente == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("ByPessoa")]
    public ActionResult<IEnumerable<Endereco>> GetByPessoa(int pessoaId)
    {
        var enderecos = _context.Enderecos.Where(e => e.PessoaId == pessoaId).ToList();

        return Ok(enderecos);
    }
}
