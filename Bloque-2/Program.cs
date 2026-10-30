using Bloque_2.Interfaces;
using Bloque_2.Repositories;
using Bloque_2.Services;

var builder = WebApplication.CreateBuilder(args);

// Registrar los controladores
builder.Services.AddControllers();

// Configurar la inyección de dependencias
builder.Services.AddScoped<IProductoRepository, ProductoRepositoryInMemory>();
builder.Services.AddScoped<IProductoService, ProductoService>();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();