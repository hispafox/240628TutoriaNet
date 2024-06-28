using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPaisesProyecto.Migrations
{
    public partial class datosiniciales110 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Capital", "FechaFinTemporadaAlta", "FechaInicioTemporadaAlta", "Idioma", "Nombre" },
                values: new object[] { 1, "Madrid", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Español", "España" });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Capital", "FechaFinTemporadaAlta", "FechaInicioTemporadaAlta", "Idioma", "Nombre" },
                values: new object[] { 2, "París", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Francés", "Francia" });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Capital", "FechaFinTemporadaAlta", "FechaInicioTemporadaAlta", "Idioma", "Nombre" },
                values: new object[] { 3, "Roma", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italiano", "Italia" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Email", "Nombre" },
                values: new object[] { 1, "García", "", "Juan" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Email", "Nombre" },
                values: new object[] { 2, "Lopez", "", "Maria" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Email", "Nombre" },
                values: new object[] { 3, "Gomez", "", "Pedro" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Email", "Nombre" },
                values: new object[] { 4, "Rodriguez", "", "Laura" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Email", "Nombre" },
                values: new object[] { 5, "Perez", "", "Carlos" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
