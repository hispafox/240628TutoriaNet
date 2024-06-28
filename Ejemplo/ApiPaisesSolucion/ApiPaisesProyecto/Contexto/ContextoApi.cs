using ConversorAcme.Api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiPaisesProyecto.Contexto
{
    // 1-Instalar estos paquetes NuGet (Sqlite):
    // Deben coincidir con la version del proyecto de la API (6.x.x)
    // Microsoft.EntityFrameworkCore -> Entity Framework Core es un O/RM (Object-Relational Mapper)
    //                                  que permite a los desarrolladores de .NET
    //                                  trabajar con una base de datos utilizando objetos .NET.
    // Microsoft.EntityFrameworkCore.Sqlite -> Proveedor de base de datos SQLite para Entity Framework Core.
    // Microsoft.EntityFrameworkCore.Tools -> Herramientas de Entity Framework Core para la CLI de .NET.

    // 2-Crear la clase ConversorContexto y Entidades (Pais.cs,Usuario.cs) en la carpeta Entidades

    // 3-Agregar cadena de conexión en appsettings.json

    // 4-Configurar el servicio de base de datos en Program.cs


    // 5-Crear la migración
    //   desde la terminal de comandos:
    //   dotnet ef migrations add InitialCreate
    //   desde Visual Studio:
    //   Herramientas -> Administrador de paquetes NuGet -> Consola del Administrador de paquetes
    //   Add-Migration "inicial"

    // 6-Aplicar la migración
    //   desde la terminal de comandos:
    //   dotnet ef database update
    //   desde Visual Studio:
    //   Herramientas -> Administrador de paquetes NuGet -> Consola del Administrador de paquetes
    //   Update-Database

    public class ContextoApi : DbContext // DbContext es una clase de Entity Framework Core
    {
        public ContextoApi(DbContextOptions<ContextoApi> options) : base(options)
        {
        }

        // DbSet es una colección de entidades que se pueden consultar, insertar, actualizar y eliminar.
        // DbSet es una propiedad de DbContext que representa una colección de entidades en la base de datos.
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }



        // OnConfiguring se llama cuando se crea el contexto
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Para activar el seguimiento de consultas,
            // se debe establecer el nivel de seguimiento en Debug
            // en el archivo de configuración de la aplicación (appsettings.json)
            // y se debe agregar el siguiente código 
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Agregar tres paises por defecto a la base de datos
            modelBuilder.Entity<Pais>().HasData(
                                          new Pais { Id = 1, Nombre = "España", Idioma = "Español", Capital = "Madrid" },
                                          new Pais { Id = 2, Nombre = "Francia", Idioma = "Francés", Capital = "París" },
                                          new Pais { Id = 3, Nombre = "Italia", Idioma = "Italiano", Capital = "Roma" }
                                          );
            // Agregar tres usuarios por defecto a la base de datos mediante modelBuilder
            modelBuilder.Entity<Usuario>().HasData(
                                          new Usuario { Id = 1, Nombre = "Juan", Apellidos = "García", Email = "" },
                                          new Usuario { Id = 2, Nombre = "Maria", Apellidos = "Lopez", Email = "" },
                                          new Usuario { Id = 3, Nombre = "Pedro", Apellidos = "Gomez", Email = "" },
                                          new Usuario { Id = 4, Nombre = "Laura", Apellidos = "Rodriguez", Email = "" },
                                          new Usuario { Id = 5, Nombre = "Carlos", Apellidos = "Perez", Email = "" }
                                          );
        }
    }
   
}
