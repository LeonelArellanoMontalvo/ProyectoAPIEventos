using Microsoft.EntityFrameworkCore;
using GestionEventosAcademicos.NewApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Para usar PostgreSQL, descomenta lo siguiente:
 //builder.Services.AddDbContext<EventoContext>(options =>
 //   options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection") ?? throw new InvalidOperationException("Connection string 'PostgreSqlConnection' not found.")));

// Para usar SQL Server, descomenta lo siguiente:
  builder.Services.AddDbContext<EventoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection") ?? throw new InvalidOperationException("Connection string 'SqlServerConnection' not found.")));

// El resto queda igual...

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

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
