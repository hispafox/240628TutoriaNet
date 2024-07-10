var builder = WebApplication.CreateBuilder(args);

// 1 - Add services to the container.
// ==================================

// Agregar el servicio de Modelo Vista Controlador
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar el servicio de base de datos SQL Server
builder.Services.AddDbContext<ContextoApi>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConversorApiPaisesSqlServer"));
});



var app = builder.Build();


// 2 - Configure the HTTP request pipeline.
// ========================================

// ===========================================
//   ^           ^
//   Swagger     ^
//               MapControllers

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



app.Run();
