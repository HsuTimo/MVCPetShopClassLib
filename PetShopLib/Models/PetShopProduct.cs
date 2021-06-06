using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetShopLib.Models
{
    public class PetShopProduct
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter a product name.")]
        [Display(Name = "Product name")]
        [StringLength(30,MinimumLength = 3,ErrorMessage = "The product name must be at least 3 characters long and maximum 30 characters long.")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please enter the amount of products")]
        [Display(Name = "Product quantity")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please enter the product price")]
        [Display(Name = "Product price")]
        public decimal Price { get; set; }
    }
}
