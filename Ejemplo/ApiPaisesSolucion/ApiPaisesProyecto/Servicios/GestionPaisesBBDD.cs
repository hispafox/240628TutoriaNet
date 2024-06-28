using ApiPaisesProyecto.Contexto;
using ConversorAcme.Api.Entidades;
using ConversorAcme.Api.Servicios;
using Microsoft.EntityFrameworkCore;

namespace ApiPaisesProyecto.Servicios
{
    public class GestionPaisesBBDD : IGestionPaises
    {
        private readonly ContextoApi contextoApi;

        public GestionPaisesBBDD(ContextoApi contextoApi)
        {
            this.contextoApi = contextoApi;
        }
        public void ActualizarPais(Pais pais)
        {
            contextoApi.Paises.Update(pais);
        }

        public void Agregar(Pais pais)
        {
            contextoApi.Paises.Add(pais);
        }

        public void EliminarPais(Pais pais)
        {
            contextoApi.Paises.Remove(pais);
        }

        public async Task<bool> GuardarCambios()
        {
            return await contextoApi.SaveChangesAsync() > 0;
        }

        public async Task<Pais?> ObtenerPorId(int id)
        {
            return await contextoApi.Paises.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Pais>> ObtenerTodos()
        {
            return await contextoApi.Paises.ToListAsync();
        }

        public async Task<List<Pais>> ObtenerTodosFiltrado(string? idioma, string? nombre, int numeroPagina, int TamañoPagina)
        {
           // En una consulta LINQ hay dos fases
           // 1. Definición de la consulta
            var consulta = from pais in contextoApi.Paises
                           select pais;

           // Agregar criterios de filtrado y búsqueda
            if (!string.IsNullOrEmpty(idioma))
            {
                idioma = idioma.Trim();
                consulta = consulta.Where(pais => pais.Idioma == idioma);
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                nombre = nombre.Trim();
                consulta = consulta.Where(pais => pais.Nombre.Contains(nombre));
            }
            // Ordenar por nombre de pais
            consulta = consulta.OrderBy(pais => pais.Nombre);

            // Paginación
            consulta = consulta.Skip((numeroPagina - 1) * TamañoPagina).Take(TamañoPagina);

            // Paginacion optimizada para muchos registros sin utilizar skip y take
            // No se debe utilizar skip y take para paginar en bases de datos grandes
            // Se debe utilizar una paginación basada en el valor de la clave primaria
            // Ejemplo
            // Si la clave primaria es un entero
            // Se puede hacer una paginación basada en el valor de la clave primaria

            // Paginación
            // Paginacion optimizada para muchos registros sin utilizar skip y take
            // No se debe utilizar skip y take para paginar en bases de datos grandes
            // Se debe utilizar una paginación basada en el valor de la clave primaria
            // Ejemplo
            // Si la clave primaria es un entero
            // Se puede hacer una paginación basada en el valor de la clave primaria
            //var ultimoIdPaginaAnterior = contextoApi.Paises
            //    .OrderByDescending(pais => pais.Id)
            //    .Skip((numeroPagina - 1) * TamañoPagina)
            //    .Take(1)
            //    .Select(pais => pais.Id)
            //    .FirstOrDefault();

            //consulta = consulta.Where(pais => pais.Id <= ultimoIdPaginaAnterior);

            // 2. Ejecución de la consulta


            // 2. Ejecución de la consulta
            return await consulta.ToListAsync();
        }
    }
}
