using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPaisesProyecto.Controllers
{

    // Decorador que indica que es un controlador de API
    // Documentación de ApiController: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.apicontrollerattribute?view=aspnetcore-5.0



    // http://localhost:5240/api/holamundo
    [Route("api/holamundo")] //  Especificar la ruta de la API -> api/holamundo
    [ApiController]  // Decorador que indica que es un controlador de API
                     // Documentación de ApiController: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.apicontrollerattribute?view=aspnetcore-5.0

    // Clase HolaMundoController que hereda de ControllerBase
    public class HolaMundoController : ControllerBase // Hereda de ControllerBase
    {

        // http://localhost:5240/api/holamundo
        // Método Get
      
        
        [HttpGet] // Decorador que indica que es un método Get
        public IActionResult Get() // Método Get
        {
            return Ok("Hola Mundo"); // Devuelve un mensaje de Hola Mundo
        }

    }
}
