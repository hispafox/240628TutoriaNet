using ApiPaisesProyecto.ValidationAtributes;
using System.ComponentModel.DataAnnotations;

namespace ConversorAcme.Api.Entidades
{
    // Sistemas de validacion utilizados en esta clase:
    // 1-Atributos de validación de datos de DataAnnotations
    //   Documentacion: https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-6.0
    // 2-Interfaz IValidatableObject
    //   Documentacion : https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.ivalidatableobject?view=net-6.0
    // 3-Validación personalizada mediante atributo DateRangeAttribute
    //   Documentacion atributos personalizados: https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validationattribute?view=net-6.0
    // 4-Validacion mediante FluentValidation
    //   Documentacion: https://docs.fluentvalidation.net/en/latest/index.html



    [DateRange("FechaInicioTemporadaAlta", "FechaFinTemporadaAlta")]
    public class Pais : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$")]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string? Idioma { get; set; }

        [MaxLength(50)]
        public string? Capital { get; set; }

        public DateTime FechaInicioTemporadaAlta { get; set; }
        public DateTime FechaFinTemporadaAlta { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Idioma==Capital)
            {
                yield return new ValidationResult("Idioma y capital deben ser diferentes");
            }
            //if (FechaInicioTemporadaAlta>=FechaFinTemporadaAlta) {
            //    yield return new ValidationResult("La fecha de inicio no puede ser posterior a la fecha de fin");
            //}
        }
    }
}
