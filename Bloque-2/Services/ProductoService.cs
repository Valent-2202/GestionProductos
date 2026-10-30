using Bloque_2.DTOs;
using Bloque_2.Interfaces;
using Bloque_2.Models;

namespace Bloque_2.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public List<ProductoDto> ObtenerTodos()
        {
            return _repository.ObtenerTodos()
                .Select(p => ConvertirADto(p))
                .ToList();
        }

        public ProductoDto? ObtenerPorId(int id)
        {
            var producto = _repository.ObtenerPorId(id);

            if (producto == null)
                return null;

            return ConvertirADto(producto);
        }

        public ProductoDto Crear(CreateProductoDto productoDto)
        {
            var producto = new Producto
            {
                Nombre = productoDto.Nombre,
                Precio = productoDto.Precio!.Value,
                Categoria = productoDto.Categoria,
                Activo = true
            };

            _repository.Agregar(producto);

            return ConvertirADto(producto);
        }

        public bool Actualizar(int id, CreateProductoDto productoDto)
        {
            var producto = _repository.ObtenerPorId(id);

            if (producto == null)
                return false;

            producto.Nombre = productoDto.Nombre;
            producto.Precio = productoDto.Precio!.Value;
            producto.Categoria = productoDto.Categoria;

            return _repository.Actualizar(producto);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }

        private ProductoDto ConvertirADto(Producto producto)
        {
            return new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Categoria = producto.Categoria,
                Activo = producto.Activo
            };
        }
    }
}