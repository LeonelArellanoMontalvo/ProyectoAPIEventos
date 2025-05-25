using Microsoft.EntityFrameworkCore;
using GestionEventosAcademicos.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar el contexto de datos con PostgreSQL
builder.Services.AddDbContext<EventoContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection") ?? throw new InvalidOperationException("Connection string 'PostgreSqlConnection' not found.")));

// Configurar controladores y serialización con Newtonsoft.Json
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();