using Bloque_2.Interfaces;
using Bloque_2.Repositories;
using Bloque_2.Services;

var builder = WebApplication.CreateBuilder(args);

// Registrar los controladores
builder.Services.AddControllers();

// Configurar la inyección de dependencias
builder.Services.AddScoped<IProductoRepository, ProductoRepositoryInMemory>();
builder.Services.AddScoped<IProductoService, ProductoService>();

// Configurar OpenAPI
builder.Services.AddOpenApi();

var app = builder.Build();

// Configurar el entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();