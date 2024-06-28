using ApiPaisesProyecto.Contexto;
using ApiPaisesProyecto.Servicios;
using ConversorAcme.Api.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

// Paquetes NuGet necesarios:
// Swashbuckle.AspNetCore
// Serilog.AspNetCore -> Un paquete NuGet que proporciona una integración de Serilog con ASP.NET Core
//                  sink -> Un sink es un destino de log
// Serilog.Sinks.Console -> Un paquete NuGet que proporciona un sink para la consola
// Serilog.Sinks.File -> Un paquete NuGet que proporciona un sink para un archivo


var builder = WebApplication.CreateBuilder(args);

// Configurar Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// El servidor de desarrollo local se llama Kestrel
// Kestrel es un servidor web de código abierto y multiplataforma para ASP.NET Core.
// Kestrel es el servidor web predeterminado utilizado por ASP.NET Core y es un servidor web de alto rendimiento.

// 1-Agregar servicios 
// ===================

// Agregar servicio de Serilog
builder.Logging.AddSerilog();

// Agregar MVC para API
builder.Services.AddControllers( options =>
{
    //options.Filters.Add( new ProducesResponseTypeAttribute( StatusCodes.Status200OK ) );
    //options.Filters.Add( new ProducesResponseTypeAttribute( StatusCodes.Status400BadRequest ) );
    //options.Filters.Add( new ProducesResponseTypeAttribute( StatusCodes.Status500InternalServerError ) );
     options.ReturnHttpNotAcceptable = true;
} );

// Agregar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Se utilizan tres metodos: AddSingleton, AddScoped y AddTransient
// AddSingleton: Crea una sola instancia de la clase y la reutiliza en todas las solicitudes.
// AddScoped: Crea una instancia por solicitud.
// AddTransient: Crea una nueva instancia cada vez que se solicita.


var version = "Ingles";
if (version!="Ingles")
{
    builder.Services.AddTransient<ISaludo, Saludo>();
}
else 
{  
    builder.Services.AddTransient<ISaludo, SaludoEnIngles>();
}

// Agregar servicios de acceso a datos (Repositorio)
// Patron Repositorio
// Un repositorio es un objeto que encapsula el acceso a la capa de datos
// y oculta los detalles de cómo se accede a los datos.
// Un repositorio separa la lógica de negocio de la lógica de acceso a datos.
builder.Services.AddScoped<IGestionPaises, GestionPaisesBBDD>();

// Agregar BBDD (SQLite)
builder.Services.AddDbContext<ContextoApi>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("ConversorApiPaises"));
});

var app = builder.Build();

// 2-Configurar el middleware (Software que se ejecuta entre el cliente y el servidor)
// ===================================================================================

if (app.Environment.IsDevelopment())
{
    // Agregar Swagger 
    app.UseSwagger();
    app.UseSwaggerUI();
}


// app.UseHttpsRedirection();

//app.UseAuthorization();

//app.UseRouting();

app.MapControllers();


// 3-Ejecutar la aplicación
// ========================

app.Run();
