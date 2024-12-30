using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ModelValidationsExample.CustomValidators;
using System.ComponentModel.DataAnnotations;
namespace ModelValidationsExample.Models
{
    public class Person : IValidatableObject
    {
        [Required(ErrorMessage = "{0} can't be empty or null")] //this indicates the property Name is mandatory, cannot be null or empty
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} to {1} characters long")]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contain only alphabets, space and dot")] //accept only letter and .
        public string? Name { get; set; }
        [EmailAddress(ErrorMessage = "{0} should be a proper email address")]
        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Email { get; set; }
        [Phone(ErrorMessage = "{0} should contain 10 digits")]
        [ValidateNever]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match")]
        [Display(Name = "Password Confirmation")]
        public string? ConfirmPassword { get; set; }
        [Range(0, 999.99, ErrorMessage = "{0} should be between {1} and {2}")]
        public double? Price { get; set; }

        [MinimumYearValidator(1995)]
        [BindNever]
        public DateTime? DateOfBirth { get; set; }

        public DateTime? FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "'FromDate' Should be older than or equal to 'ToDate'")]
        public DateTime? ToDate { get; set; }
        public int? Age { get; set; }

        //string? - accepts null values
        public List<string?> Tags { get; set; } = new List<string?>();
        public override string ToString()
        {
            return $"Person object - Name: {Name}, Email: {Email}, Phone: {Phone}, Password: {Password},ConfirmPassword: {ConfirmPassword}, Price: {Price}, Birth: {DateOfBirth}, From: {FromDate}, To:{ToDate}" +
                $"\n Tags: {String.Join(',', Tags)}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth.HasValue == false && Age.HasValue == false)
            {
                yield return new ValidationResult("Date of birth or Age must be supplied", new[] { nameof(Age) });
            }

        }
    }
}
