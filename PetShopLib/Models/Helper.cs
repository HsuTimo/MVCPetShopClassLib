using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopLib.Models
{
    public class Helper
    {
        public static string Constr(IConfiguration configuation, string name)
        {
            return configuation.GetConnectionString(name);
        }
    }
}
