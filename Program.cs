using Microsoft.EntityFrameworkCore;
using WebApplication1.Datas;
using WebApplication1.Services;
using WebApplication1.Singleton; // Importa o namespace correto
using Microsoft.OpenApi.Models; // Para o Swagger

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext para usar o banco de dados Oracle via appsettings.json
builder.Services.AddDbContext<UserContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar SingletonUser como Singleton
builder.Services.AddSingleton<SingletonUser>();

// Adicionar os servi�os de controladores e configura��es do Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Challenge", Version = "v1" });
    c.EnableAnnotations(); // Ativar anota��es no Swagger
});

var app = builder.Build();

// Configurar o pipeline de requisi��es
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Adicionar Swagger tamb�m no modo de produ��o
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
