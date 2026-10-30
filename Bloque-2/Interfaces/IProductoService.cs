using Bloque_2.DTOs;

namespace Bloque_2.Interfaces
{
    public interface IProductoService
    {
        List<ProductoDto> ObtenerTodos();

        ProductoDto? ObtenerPorId(int id);

        ProductoDto Crear(CreateProductoDto productoDto);

        bool Actualizar(int id, CreateProductoDto productoDto);

        bool Eliminar(int id);
    }
}