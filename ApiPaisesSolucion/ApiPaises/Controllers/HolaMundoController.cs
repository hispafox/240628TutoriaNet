
namespace ApiPaises.Controllers;

[Route("api/holamundo")] // C1-Especifica la ruta de la api -> https://localhost:5001/api/holamundo
[ApiController]          // C2-Indica que es un controlador de API
public class HolaMundoController : ControllerBase  // C3-ControllerBase es una clase que no tiene vista
//           ========= <-- Nombre del Controlador
//                    ========== <-- Sufijo Controller
{


    public HolaMundoController(ContextoApi contexto)
    {
        
    }


    [HttpGet] // M1-Indica que es un método de tipo Get
    public IActionResult Get() // M2-Método Get que retorna un IActionResult
                               // El nombre del método es cualquiera, en este caso Get
    {
        return Ok("Hola Mundo"); // M3-Retorna un mensaje de Hola Mundo Ok Significa que la petición fue exitosa 
                                 //   y el servidor devuelve la información solicitada
                                 //   con un código de estado 200
    }

    //[HttpGet] // https://localhost:5001/api/holamundo/saludo?saludo=Juan
    //public IActionResult Saludo(string saludo)
    //{
    //    return Ok($"Hola {saludo}");
    //}

}
