using ApiCentralPessoa.Dto;
using Microsoft.EntityFrameworkCore;

namespace ApiCentralPessoa.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoTelefoneController : ControllerBase
{
    private readonly CentralPessoaContext _context;

    public TipoTelefoneController(CentralPessoaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoTelefone>>> GetAll()
    {
        return await _context.TiposTelefones.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TipoTelefone>> GetById(int id)
    {
        var tipoTelefone = await _context.TiposTelefones.FindAsync(id);

        if (tipoTelefone == null)
        {
            return NotFound();
        }

        return Ok(tipoTelefone);
    }

    [HttpPost]
    public async Task<IActionResult> Post(TipoTelefone tipoTelefone)
    {
        
        await _context.TiposTelefones.AddAsync(tipoTelefone);

        await _context.SaveChangesAsync();

        return Ok(tipoTelefone);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, TipoTelefone tipoTelefone)
    {
        var tipoTelefoneExistente = _context.TiposTelefones.FirstOrDefault(e => e.Id == id);
        if (tipoTelefoneExistente == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("ByPessoa")]
    public ActionResult<IEnumerable<TipoTelefone>> GetByPessoa(int pessoaId)
    {
        var tipoTelefone = _context.TiposTelefones.Where(e => e.Id == pessoaId).ToList();

        return Ok(tipoTelefone);
    }
}
