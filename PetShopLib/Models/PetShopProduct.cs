using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopLib.Models
{
    public class PetShopProduct
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
