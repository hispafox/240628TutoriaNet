using ConversorAcme.Api.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteApi
{
    public class ApiCliente
    {
        private static HttpClient _httpClient = new HttpClient();

        public ApiCliente()
        {
            _httpClient.BaseAddress = new Uri("http://localhost:5240/");
        }

        public async Task EjecutarAsync()
        {
            // Realizar una solicitud GET a la API para obtener todos los usuarios
            HttpResponseMessage respuesta = await _httpClient.GetAsync("api/paises");

            // Verificar si la solicitud fue exitosa
            respuesta.EnsureSuccessStatusCode();

            // Leer el contenido de la respuesta
            string contenido = await respuesta.Content.ReadAsStringAsync();

            // Deserializar el contenido de la respuesta en una lista de paises
            // Deserializar JSON -> Objeto
            List<Pais> paises =
                JsonConvert.DeserializeObject<List<Pais>>(contenido);

            // Imprimir los paises por consola
            foreach (var pais in paises)
            {
                Console.WriteLine($"Id: {pais.Id}, Nombre: {pais.Nombre}, Idioma: {pais.Idioma}");
            }
        }
    }
}
