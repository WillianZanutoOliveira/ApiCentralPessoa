namespace ApiCentralPessoa.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PesssoaFisicaController : ControllerBase
{
    private readonly CentralPessoaContext _context;

    public PesssoaFisicaController(CentralPessoaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PessoaFisica>>> GetAll()
    {
        return await _context.PessoasFisicas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PessoaFisica>> GetById(int id)
    {
        var pessoaFisica = await _context.PessoasFisicas.FindAsync(id);

        if (pessoaFisica == null)
        {
            return NotFound();
        }

        return Ok(pessoaFisica);
    }

    [HttpPost]

    public async Task<IActionResult> Post(PessoaFisica pessoaFisica)
    {

        await _context.PessoasFisicas.AddAsync(pessoaFisica);

        await _context.SaveChangesAsync();

        return Ok(pessoaFisica);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, PessoaFisica pessoaFisica)
    {
        var pessoaFisicaExistente = _context.PessoasFisicas.FirstOrDefault(e => e.Id == id);
        if (pessoaFisicaExistente == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("ByPessoa")]
    public ActionResult<IEnumerable<PessoaFisica>> GetByPessoa(int pessoaId)
    {
        var pessoaFisica = _context.PessoasFisicas.Where(e => e.Id == pessoaId).ToList();

        return Ok(pessoaFisica);
    }
}
