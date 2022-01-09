using ECommerceApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Repositories
{
    public interface IProductCategoryRepository
    {
        List<ProductCategory> GetAllProductCategory();
    }
}
