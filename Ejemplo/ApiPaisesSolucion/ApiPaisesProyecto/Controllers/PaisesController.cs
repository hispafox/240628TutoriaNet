using ApiPaisesProyecto.Servicios;
using ConversorAcme.Api.Entidades;
using ConversorAcme.Api.Servicios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPaisesProyecto.Controllers
{
    // CRUD de paises
    // Create, Read, Update, Delete
    // Crear, Leer, Actualizar, Borrar

    // http://localhost:5240/api/paises
    // http://localhost:5240 -> URL base
    // api/paises -> Ruta de la API




    [Route("api/paises")] // Especificar la ruta de la API -> api/paises
    [ApiController]       // Decorador que indica que es un controlador de API
                          // Documentación de ApiController: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.apicontrollerattribute?view=aspnetcore-5.0
    public class PaisesController : ControllerBase // Hereda de ControllerBase
    {
        private readonly ISaludo saludo;
        private readonly IGestionPaises gestionPaises;
        private readonly ILogger<PaisesController> logger;

        public PaisesController(ISaludo saludo, IGestionPaises gestionPaises, ILogger<PaisesController> logger)
        {
            this.saludo = saludo;
            this.gestionPaises = gestionPaises;
            this.logger = logger;
        }

        const int TamañoPagina = 5;

        // Obtener todos los paises
        // GET: api/<PaisesController>
        [HttpGet] // Decorador que indica que es un método Get -> http://localhost:5240/api/paises
        public async Task<ActionResult<List<Pais>>> Get([FromQuery] string? idioma, 
                                 [FromQuery] string? nombre,
                                 [FromQuery] int numeroPagina = 1,
                                 [FromQuery] int tamañoPagina = TamañoPagina
                                 ) // Devuelve un IActionResult
                                   // IActionResult es una interfaz que representa
                                   // el resultado de un método de acción
                                   // Get es un método de acción
        {
            var textoSaludo = saludo.saludar("Juan");
            logger.LogInformation(textoSaludo);

            //var gestionPaises = new GestionPaises();
            var paises = await gestionPaises.ObtenerTodosFiltrado(idioma,nombre,numeroPagina,tamañoPagina);
            logger.LogInformation($"Obteniendo todos los paises. Numero de paises: {paises.Count}");
            return Ok(paises);
        }

        // Obtener un pais por id
        // GET api/PaisesController/5
        [HttpGet("{id}")] // Decorador que indica que es un método Get
        public async Task<ActionResult<Pais>> Get([FromRoute] int id)
        {
            //var gestionPaises = new GestionPaises();
            var pais = await gestionPaises.ObtenerPorId(id);
            if (pais == null)
            {
                return NotFound();
            }


            return Ok(pais);
        }

        // Alta de pais
        // POST api/<PaisesController>
        [HttpPost] // Decorador que indica que es un método Post
        public async Task<ActionResult<Pais>> Post([FromBody] Pais pais)
        {
            var modeloValido = ModelState.IsValid;
            if (pais.Id != 0) {
                ModelState.AddModelError("Id", "No se debe especificar el Id al agregar un pais");
            }
            
            if (!modeloValido)
            {
                return BadRequest(ModelState);
            }

            //var gestionPaises = new GestionPaises();
            gestionPaises.Agregar(pais);
            await gestionPaises.GuardarCambios();

            return CreatedAtAction(nameof(Get), new { id = pais.Id }, pais);
        }

        // Actualizar pais
        // PUT api/<PaisesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] Pais pais)
        {
            //var gestionPaises = new GestionPaises();

            var paisActual = await gestionPaises.ObtenerPorId(id);
            if (paisActual == null)
            {
                return NotFound();
            }
            // Actualizar paisActual con los datos de pais
            paisActual.Nombre = pais.Nombre;
            paisActual.Idioma = pais.Idioma;
            paisActual.Capital = pais.Capital;
            paisActual.FechaInicioTemporadaAlta = pais.FechaInicioTemporadaAlta;
            paisActual.FechaFinTemporadaAlta = pais.FechaFinTemporadaAlta;
                

            gestionPaises.ActualizarPais(paisActual);
            await gestionPaises.GuardarCambios();
            return NoContent();
        }

        // Baja de pais
        // DELETE api/<PaisesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            //var gestionPaises = new GestionPaises();
            var pais = await gestionPaises.ObtenerPorId(id);
            if (pais == null)
            {
                return NotFound();
            }
            gestionPaises.EliminarPais(pais);
            await gestionPaises.GuardarCambios();
            return Ok();
        }
    }
}
