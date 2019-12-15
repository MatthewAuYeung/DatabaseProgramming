using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameBackend.Models
{
    public class Product
    {
        public int idproduct { get; set; }
        public string productName { get; set; }
        public int manufacturingYear { get; set; }
        public string brandName { get; set; }
    }
}