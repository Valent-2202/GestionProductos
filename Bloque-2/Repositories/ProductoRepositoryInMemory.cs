using Bloque_2.Interfaces;
using Bloque_2.Models;

namespace Bloque_2.Repositories
{
    public class ProductoRepositoryInMemory : IProductoRepository
    {
        private static readonly List<Producto> productos = new()
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
            }
        };

        public List<Producto> ObtenerTodos()
        {
            return productos.ToList();
        }

        public Producto? ObtenerPorId(int id)
        {
            return productos.FirstOrDefault(p => p.Id == id);
        }

        public void Agregar(Producto producto)
        {
            producto.Id = productos.Count == 0
                ? 1
                : productos.Max(p => p.Id) + 1;

            productos.Add(producto);
        }

        public bool Actualizar(Producto producto)
        {
            var existente = ObtenerPorId(producto.Id);

            if (existente == null)
                return false;

            existente.Nombre = producto.Nombre;
            existente.Precio = producto.Precio;
            existente.Categoria = producto.Categoria;
            existente.Activo = producto.Activo;

            return true;
        }

        public bool Eliminar(int id)
        {
            var producto = ObtenerPorId(id);

            if (producto == null)
                return false;

            productos.Remove(producto);
            return true;
        }
    }
}