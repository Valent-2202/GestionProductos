using GestionProductos.Models;
using GestionProductos.Interfaces;
using GestionProductos.Repositories;

// Crear una instancia del repositorio
IProductoRepository repo = new ProductoRepository();

// 1. Mostrar todos los productos
Console.WriteLine("=== LISTA DE PRODUCTOS ===");

foreach (Producto p in repo.ObtenerTodos())
{
    Console.WriteLine(
        $"ID: {p.Id} | Nombre: {p.Nombre} | " +
        $"Precio: ${p.Precio} | Categoria: {p.Categoria} | " +
        $"Activo: {p.Activo}"
    );
}

// 2. Buscar un producto por ID
Console.WriteLine("\n=== BUSCAR PRODUCTO POR ID ===");

Producto? productoBuscado = repo.ObtenerPorId(2);

if (productoBuscado != null)
{
    Console.WriteLine($"Producto encontrado: {productoBuscado.Nombre}");
}
else
{
    Console.WriteLine("Producto no encontrado.");
}

// 3. Buscar productos por categoría
Console.WriteLine("\n=== PRODUCTOS DE TECNOLOGIA ===");

List<Producto> productosTecnologia =
    repo.BuscarPorCategoria("Tecnologia");

foreach (Producto p in productosTecnologia)
{
    Console.WriteLine($"{p.Nombre} - ${p.Precio}");
}

// 4. Agregar un producto nuevo
Console.WriteLine("\n=== AGREGAR PRODUCTO ===");

Producto nuevoProducto = new Producto
{
    Id = 5,
    Nombre = "Teclado Redragon",
    Precio = 45000,
    Categoria = "Tecnologia",
    Activo = true
};

repo.Agregar(nuevoProducto);

Console.WriteLine("Producto agregado correctamente.");

// 5. Mostrar la lista actualizada
Console.WriteLine("\n=== LISTA ACTUALIZADA ===");

foreach (Producto p in repo.ObtenerTodos())
{
    Console.WriteLine($"{p.Id} - {p.Nombre} - ${p.Precio}");
}