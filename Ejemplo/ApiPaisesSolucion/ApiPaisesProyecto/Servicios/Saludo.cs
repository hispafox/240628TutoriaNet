namespace ApiPaisesProyecto.Servicios
{
    public class Saludo : ISaludo
    {
        public string saludar(string mensaje)
        {
           return $"Hola {mensaje}";
        }
    }

    // Crear una instancia de la interfaz ISaludo pero saludando en inglés
    public class SaludoEnIngles : ISaludo
    {
        public string saludar(string mensaje)
        {
            return $"Hello {mensaje}";
        }
    }

    public interface ISaludo
    {
        string saludar(string mensaje);
    }
}
