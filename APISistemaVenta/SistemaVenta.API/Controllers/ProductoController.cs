using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.API.Utilidad;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace SistemaVenta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var response = new Response<List<ProductoDTO>>();
            try
            {
                response.status = true;
                response.value = await _productoService.Lista();
            }
            catch (Exception ex)
            {
                response.status = false;
                response.msg = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Crear([FromBody] ProductoDTO producto)
        {
            var response = new Response<ProductoDTO>();
            try
            {
                response.status = true;
                response.value = await _productoService.Crear(producto);
            }
            catch (Exception ex)
            {
                response.status = false;
                response.msg = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO producto)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _productoService.Editar(producto);
            }
            catch (Exception ex)
            {
                response.status = false;
                response.msg = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("Eliminar(id int")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _productoService.Eliminar(id);
            }
            catch (Exception ex)
            {
                response.status = false;
                response.msg = ex.Message;
            }
            return Ok(response);
        }
    }
}
