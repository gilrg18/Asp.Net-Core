using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationsExample.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string OtherPropertyName { get; set; }
        public DateRangeValidatorAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //value is the value of the property of which the attribute is applied, in this case 'ToDate'
            if (value != null)
            {
                DateTime toDate = Convert.ToDateTime(value); //gets the value of ToDate property
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);//reference of the FromDate property
                if (otherProperty != null)
                {
                    DateTime fromDate = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance)); //gets the value of FromDate property
                    if (fromDate > toDate)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName, validationContext.MemberName });
                        //errormessage, name of the properties that contain the error message
                        //the error message will appear twice because one error will refer to ToDate and the other to FromDate
                    }
                    return ValidationResult.Success;
                }
                return null;
            }
            return null;
        }
    }
}
