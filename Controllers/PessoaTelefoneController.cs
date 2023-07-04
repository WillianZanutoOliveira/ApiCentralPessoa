namespace ApiCentralPessoa.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PessoaTelefoneController : ControllerBase
{
    private readonly CentralPessoaContext _context;

    public PessoaTelefoneController(CentralPessoaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PessoaTelefone>>> GetAll()
    {
        return await _context.PessoasTelefones.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PessoaTelefone>> GetById(int id)
    {
        var telefone = await _context.PessoasTelefones.FindAsync(id);

        if (telefone == null)
        {
            return NotFound();
        }

        return Ok(telefone);
    }

    [HttpPost]
    public async Task<IActionResult> Post(PessoaTelefone pessoaTelefone)
    {
        await _context.PessoasTelefones.AddAsync(pessoaTelefone);

        await _context.SaveChangesAsync();

        return Ok(pessoaTelefone);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, PessoaTelefone pessoaTelefone)
    {
        var tipoTelefoneExistente = _context.PessoasTelefones.FirstOrDefault(e => e.Id == id);
        if (tipoTelefoneExistente == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("ByPessoa")]
    public ActionResult<IEnumerable<PessoaTelefone>> GetByPessoa(int pessoaId)
    {
        var telefone = _context.PessoasTelefones.Where(e => e.Id == pessoaId).ToList();

        return Ok(telefone);
    }
}
