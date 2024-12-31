using ModelValidationsExample.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.Models
{
    public class Order
    {
       
        public int? OrderNo { get; set; }
        [Required(ErrorMessage = "{0} can't be blank")]
        [Display (Name = "Order Date")]
        [MinimumDateValidator("2000-01-01", ErrorMessage = "Order Date should be greater than or equal to 2000")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "{0} can't be blank")]
        [InvoicePriceValidator]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public double InvoicePrice { get; set; }
        [Required(ErrorMessage = "{0} can't be blank")]
        [MinimumProductValidator]
        public List<Product>? Products { get; set; }
    }
}
