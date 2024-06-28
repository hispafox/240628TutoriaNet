
using System.ComponentModel.DataAnnotations;

namespace ConversorAcme.Api.Entidades
{



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
