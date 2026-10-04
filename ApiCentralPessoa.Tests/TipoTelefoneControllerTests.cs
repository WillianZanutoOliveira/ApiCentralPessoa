namespace ApiCentralPessoa.Tests;

[TestFixture]
public class TipoTelefoneControllerTests
{
    private static CentralPessoaContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<CentralPessoaContext>()
            .UseInMemoryDatabase($"central-pessoa-{Guid.NewGuid()}")
            .Options;

        return new CentralPessoaContext(options);
    }

    [Test]
    public async Task GetById_WhenEntityDoesNotExist_ReturnsNotFound()
    {
        await using var context = CreateContext();
        var controller = new TipoTelefoneController(context);

        var result = await controller.GetById(999);

        Assert.That(result.Result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public async Task Post_PersistsEntity_AndReturnsOk()
    {
        await using var context = CreateContext();
        var controller = new TipoTelefoneController(context);
        var tipo = new TipoTelefone("Celular");

        var result = await controller.Post(tipo);

        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(await context.TiposTelefones.CountAsync(), Is.EqualTo(1));
        Assert.That((await context.TiposTelefones.SingleAsync()).Descricao, Is.EqualTo("Celular"));
    }

    [Test]
    public async Task Put_WhenEntityExists_UpdatesDescription()
    {
        await using var context = CreateContext();
        var existing = new TipoTelefone("Residencial");
        await context.TiposTelefones.AddAsync(existing);
        await context.SaveChangesAsync();

        var controller = new TipoTelefoneController(context);

        var result = await controller.Put(existing.Id, new TipoTelefone("Comercial"));

        Assert.That(result, Is.TypeOf<NoContentResult>());
        Assert.That((await context.TiposTelefones.FindAsync(existing.Id))!.Descricao, Is.EqualTo("Comercial"));
    }
}
