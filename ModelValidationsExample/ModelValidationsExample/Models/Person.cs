using System.ComponentModel.DataAnnotations;
namespace ModelValidationsExample.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Please provide name :)")] //this indicates the property Name is mandatory, cannot be null or empty
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Price { get; set; }

        public override string ToString()
        {
            return $"Person object - Name: {Name}, Email: {Email}, Phone: {Phone}, Password: {Password}, Price: {Price}";
        }
    }
}
