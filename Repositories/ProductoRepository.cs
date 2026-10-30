using GestionProductos.Models;
using GestionProductos.Interfaces;

namespace GestionProductos.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        // Lista privada para almacenar los productos en memoria
        private List<Producto> productos;

        // Constructor: inicializa la lista con productos de prueba
        public ProductoRepository()
        {
            productos = new List<Producto>
            {
                new Producto
                {
                    Id = 1,
                    Nombre = "Notebook Lenovo",
                    Precio = 850000,
                    Categoria = "Tecnologia",
                    Activo = true
                },

                new Producto
                {
                    Id = 2,
                    Nombre = "Mouse Logitech",
                    Precio = 25000,
                    Categoria = "Tecnologia",
                    Activo = true
                },

                new Producto
                {
                    Id = 3,
                    Nombre = "Escritorio",
                    Precio = 150000,
                    Categoria = "Muebles",
                    Activo = true
                },

                new Producto
                {
                    Id = 4,
                    Nombre = "Silla de oficina",
                    Precio = 120000,
                    Categoria = "Muebles",
                    Activo = false
                }
            };
        }

        // Método para agregar un producto a la lista
        public void Agregar(Producto producto)
        {
            productos.Add(producto);
        }

        // Método para obtener todos los productos
        public List<Producto> ObtenerTodos()
        {
            return productos.ToList();
        }

        // Método para buscar un producto por su ID
        public Producto? ObtenerPorId(int id)
        {
            return productos.FirstOrDefault(p => p.Id == id);
        }

        // Método para buscar productos por categoría
        public List<Producto> BuscarPorCategoria(string categoria)
        {
            return productos
                .Where(p => p.Categoria.Equals(
                    categoria,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}