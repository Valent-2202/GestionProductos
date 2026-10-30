using Bloque_2.Models;

namespace Bloque_2.Interfaces
{
    public interface IProductoRepository
    {
        List<Producto> ObtenerTodos();

        Producto? ObtenerPorId(int id);

        void Agregar(Producto producto);

        bool Actualizar(Producto producto);

        bool Eliminar(int id);
    }
}