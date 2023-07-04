namespace ApiCentralPessoa.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PesssoaJuridicaController : ControllerBase
{
    private readonly CentralPessoaContext _context;

    public PesssoaJuridicaController(CentralPessoaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PessoaJuridica>>> GetAll()
    {
        return await _context.PessoasJuridicas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PessoaJuridica>> GetById(int id)
    {
        var pessoaJuridica = await _context.PessoasJuridicas.FindAsync(id);

        if (pessoaJuridica == null)
        {
            return NotFound();
        }

        return Ok(pessoaJuridica);
    }

    [HttpPost]
    public ActionResult<PessoaJuridica> Post(PessoaJuridica pessoaJuridica)
    {
        
        return CreatedAtAction(nameof(GetById), new { id = pessoaJuridica.Id }, pessoaJuridica);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, PessoaJuridica pessoaJuridica)
    {
        var pessoaJuridicaExistente = _context.PessoasJuridicas.FirstOrDefault(e => e.Id == id);
        if (pessoaJuridicaExistente == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("ByPessoa")]
    public ActionResult<IEnumerable<PessoaJuridica>> GetByPessoa(int pessoaId)
    {
        var pessoaJuridica = _context.PessoasJuridicas.Where(e => e.Id == pessoaId).ToList();

        return Ok(pessoaJuridica);
    }
}
