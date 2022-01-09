using ECommerceApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Service.Services
{
    public interface IProductCategoryService
    {
        List<ProductCategory> GetAllProductCategory();
    }
}
