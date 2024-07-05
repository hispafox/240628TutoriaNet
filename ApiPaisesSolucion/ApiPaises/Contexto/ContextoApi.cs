

namespace ApiPaises.Contexto;

public class ContextoApi : DbContext  // DbContext es una clase de Entity Framework Core
{

    // Constructor
    public ContextoApi(DbContextOptions<ContextoApi> options) : base(options)
    {
    }



    // Propiedades de entidades
    public DbSet<Pais> Paises { get; set; } // Pais es una entidad
                                            // Paises es el nombre de la tabla

    public DbSet<Usuario> Usuarios { get; set; } // Usuario es una entidad
                                                 // Usuarios es el nombre de la tabla

 



}
