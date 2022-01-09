using ECommerceApp.Data.Helper;
using ECommerceApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Repositories
{
    public interface IProductRepository
    {
        Task<JsonPagedList> GetAllProduct(string filterText, int pageIndex, int pageLength, string sortColumn);

        Task<string> InsertProduct(ProductAttributeMapping productAttributeMapping);

        Task<ProductCategoryMapping> GetProduct(long ProductId);

    }
}
