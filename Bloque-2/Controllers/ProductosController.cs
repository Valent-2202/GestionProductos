using Microsoft.AspNetCore.Mvc;
using Bloque_2.DTOs;
using Bloque_2.Interfaces;

namespace Bloque_2.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/productos
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var productos = _productoService.ObtenerTodos();
            return Ok(productos);
        }

        // GET: api/productos/1
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var producto = _productoService.ObtenerPorId(id);

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        // POST: api/productos
        [HttpPost]
        public IActionResult Crear(CreateProductoDto productoDto)
        {
            var producto = _productoService.Crear(productoDto);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = producto.Id },
                producto
            );
        }

        // PUT: api/productos/1
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, CreateProductoDto productoDto)
        {
            var actualizado = _productoService.Actualizar(id, productoDto);

            if (!actualizado)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/productos/1
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var eliminado = _productoService.Eliminar(id);

            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}