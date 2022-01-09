using ECommerceApp.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public List<ProductCategory> Category { get; set; }


        public List<ProductAttribute> ProductAttribute { get; set; }

        public List<AttributeLookUpMapping> AttributeMapping { get; set; }



    }
}
