using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.ViewModels
{
    public class ProductsVM
    {
        public Product[] Products { get; set; }
        public string Message { get; set; }
    }
}
