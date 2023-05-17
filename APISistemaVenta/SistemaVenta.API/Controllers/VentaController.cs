using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.API.Utilidad;


namespace SistemaVenta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO venta)
        {
            var response = new Response<VentaDTO>();
            try
            {
                response.value = await _ventaService.Registrar(venta);
                response.status = true;
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
                response.status = false;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("Historial")]
        public async Task<IActionResult> Historial(string buscarPor, string? numeroVenta, string? fechaIni, string? fechaFin)
        {
            var response = new Response<List<VentaDTO>>();
            numeroVenta = numeroVenta is null ? "" : numeroVenta;
            fechaIni = fechaIni is null ? "" : fechaIni;
            fechaFin = fechaFin is null ? "" : fechaFin;

            try
            {
                response.status = true;
                response.value = await _ventaService.Historial(buscarPor,numeroVenta,fechaIni,fechaFin);
            }
            catch (Exception ex)
            {
                response.status = false;
                response.msg = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("Reporte")]
        public async Task<IActionResult> Reporte(string fechaIni, string fechaFin)
        {
            var response = new Response<List<ReporteDTO>>();
            try
            {
                response.status = true;
                response.value = await _ventaService.Reporte(fechaIni,fechaFin);
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
