﻿using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.Models
{
    public class Product
    {
        [Required(ErrorMessage = "{0} can't be blank")]
        public int ProductCode { get; set; }
        [Required(ErrorMessage = "{0} can't be blank")]
        public double Price { get; set; }
        [Required(ErrorMessage = "{0} can't be blank")]
        public int Quantity { get; set; }


    }
}
