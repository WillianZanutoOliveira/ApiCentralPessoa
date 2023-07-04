var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CentralPessoaContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection") + ";CharSet=utf8mb4",
        new MySqlServerVersion(new Version(8, 0, 26))));

builder.Services.AddMvc();
builder.Services.AddDbContext<CentralPessoaContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiCentralPessoa API", Version = "v1" });
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var dbContext = services.GetRequiredService<CentralPessoaContext>();

        dbContext.Database.EnsureCreated();
    }
    catch (Exception)
    {
        throw;
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
