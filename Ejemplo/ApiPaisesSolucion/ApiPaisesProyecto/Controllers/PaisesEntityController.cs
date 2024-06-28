using ApiPaisesProyecto.Contexto;
using ConversorAcme.Api.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPaisesProyecto.Controllers
{
    [Route("api/PaisesEntity")]
    [ApiController]
    public class PaisesEntityController : ControllerBase
    {
        private readonly ContextoApi contexto;

        public PaisesEntityController(ContextoApi contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Obtener todos los paises en la listaPaises
            List<Pais> listaPaises = contexto.Paises.ToList();

            // Agregar nuevo pais
            Pais nuevoPais = new Pais
            {
                Nombre = "Mexico",
                 Capital = "Mexico DF",
                 Idioma = "Español"
            };
            // Añadir el nuevo pais a la listaPaises
            contexto.Paises.Add(nuevoPais);
            // Guardar los cambios en la base de datos
            contexto.SaveChanges();

                    

            // Obtener todos los paises en la listaPaises
           listaPaises = contexto.Paises.ToList();

            // Obtener un pais determinado (4)
            var pais = contexto.Paises.FirstOrDefault(pais=>pais.Id == 4);

            // Obtener un pais por nombre ("Mexico")
            var mexico = contexto.Paises.FirstOrDefault(pais => pais.Nombre == "Mexico");

            // Borrar un pais (5)
            var paisBorrar = contexto.Paises.FirstOrDefault(pais => pais.Id == 5);
            contexto.Paises.Remove(paisBorrar);
            contexto.SaveChanges();

            return Ok();
        }
    }
}
