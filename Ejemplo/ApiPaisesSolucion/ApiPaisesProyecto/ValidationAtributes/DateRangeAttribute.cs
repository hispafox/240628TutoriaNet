using System.ComponentModel.DataAnnotations;

namespace ApiPaisesProyecto.ValidationAtributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DateRangeAttribute : ValidationAttribute
    {
        private readonly string _startDatePropertyName;
        private readonly string _endDatePropertyName;

        public DateRangeAttribute(string startDatePropertyName, string endDatePropertyName)
        {
            _startDatePropertyName = startDatePropertyName;
            _endDatePropertyName = endDatePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var startDateProperty = validationContext.ObjectType.GetProperty(_startDatePropertyName);
            var endDateProperty = validationContext.ObjectType.GetProperty(_endDatePropertyName);

            if (startDateProperty == null)
                throw new ArgumentException($"Property with this name not found: {_startDatePropertyName}");

            if (endDateProperty == null)
                throw new ArgumentException($"Property with this name not found: {_endDatePropertyName}");

            var startDate = (DateTime)startDateProperty.GetValue(validationContext.ObjectInstance, null);
            var endDate = (DateTime)endDateProperty.GetValue(validationContext.ObjectInstance, null);

            if (startDate < endDate)
                return ValidationResult.Success;

            return new ValidationResult($"The {startDateProperty.Name} should be less than {endDateProperty.Name}");
        }
    }
}
