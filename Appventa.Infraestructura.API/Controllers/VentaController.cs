using AppVenta.Aplicacion.Servicios;
using AppVenta.dominio;
using AppVenta.infraestructura.datos.Contextos;
using AppVenta.infraestructura.datos.Repositorios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Appventa.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        VentaServicio CrearServicio()
        {
            VentaContexto db = new VentaContexto();
            VentaRepositorio repositorioVenta = new VentaRepositorio(db);
            ProductoRepositorio repositorioProducto = new ProductoRepositorio(db);
            VentaDetalleRepositorio repositorioVentaDetalle = new VentaDetalleRepositorio(db);
            VentaServicio servicio = new VentaServicio(repositorioVenta, repositorioProducto, repositorioVentaDetalle);
            return servicio;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<List<Venta>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Venta> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.selecionarPorId(id));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Venta venta )
        {
            var servicio = CrearServicio();
            servicio.Agregar(venta);
            return Ok();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Anular(id);
            return Ok("Anulado correctamente.");
        }
    }
}
