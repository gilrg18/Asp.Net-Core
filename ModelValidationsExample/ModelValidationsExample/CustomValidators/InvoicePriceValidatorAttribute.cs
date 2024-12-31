using ModelValidationsExample.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationsExample.CustomValidators
{
    public class InvoicePriceValidatorAttribute : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "Invoice Price should be equal to the total cost of all products (i.e. {0}) in the order.";
        public InvoicePriceValidatorAttribute()
        {
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                PropertyInfo? OtherProperty = validationContext.ObjectType.GetProperty(nameof(Order.Products)); //Products property
                if (OtherProperty != null) 
                {
                    //Value of Products
                    List<Product> products = (List<Product>)OtherProperty.GetValue(validationContext.ObjectInstance)!;
                    double price = 0;
                    foreach (Product product in products)
                    {
                        price += product.Price * product.Quantity;
                    }
                    double invoicePrice = (double)value;
                    if(price != 0)
                    {
                        if (price != invoicePrice) {
                            return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, price), 
                                new string[] { nameof(validationContext.MemberName) });
                        }
                    }
                    else
                    {
                        return new ValidationResult("No products found to validate invoice price", 
                            new string[] { nameof(validationContext.MemberName) });
                    }
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
