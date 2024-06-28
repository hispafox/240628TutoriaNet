using ConversorAcme.Api.Entidades;

namespace ConversorAcme.Api.Servicios
{
    
    public interface IGestionPaises
    {
        Task<List<Pais>> ObtenerTodos();
        Task<List<Pais>> ObtenerTodosFiltrado(string? idioma, string? nombre, int numeroPagina, int tamañoPagina);
        Task<Pais?> ObtenerPorId(int id);
        
        Task<bool> GuardarCambios();

        void Agregar(Pais pais);

        void ActualizarPais(Pais pais);

        // Metodo para eliminar pais
        void EliminarPais(Pais pais);
    }
}