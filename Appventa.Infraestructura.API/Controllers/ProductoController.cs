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
    public class ProductoController : ControllerBase
    {
        ProductoServicio CrearServicio() { 
            VentaContexto db = new VentaContexto();
            ProductoRepositorio repositorio = new ProductoRepositorio(db);
            ProductoServicio servicio = new ProductoServicio(repositorio);
            return servicio;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.selecionarPorId(id));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            servicio.Agregar(producto);
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            servicio.Editar(producto);
            return Ok();    
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Eliminado correctamente.");
        }
    }
}
