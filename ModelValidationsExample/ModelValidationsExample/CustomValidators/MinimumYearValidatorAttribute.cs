using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000; //2000 default value
        public string DefaultErrorMessage { get; set; } = "Year should be less than {0}";
        public MinimumYearValidatorAttribute()//parameterless constructor
        {
        }

        public MinimumYearValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value; //convert the value to DateTime
                if (date.Year >= MinimumYear)
                {
                    //ErrorMessage predefined property of ValidationAttribute
                    //ErrorMessage ?? DefaultErrorMessage (if ErrorMessage is null, take DefaultErrorMessage
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
                }
                return ValidationResult.Success;
            }

            return null;
        }
    }
}
