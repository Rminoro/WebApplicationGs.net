using Microsoft.EntityFrameworkCore;
using WebApplication1.Datas;

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext para usar o banco de dados Oracle via appsettings.json
builder.Services.AddDbContext<UserContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));
// Adicionar os servi�os de controladores e configura��es do Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de requisi��es
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
