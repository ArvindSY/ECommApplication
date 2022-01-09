using ECommerceApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Repositories
{
    public interface IAttributeRepository
    {
        Task<List<AttributeLookUpMapping>> GetProductWiseAttribute(long productId);
        Task<List<ProductAttributeLookup>> GetAllAttributeLookUp(int categoryId);        
        Task<List<ProductAttribute>> GetProductAttribute(long productId);
    }
}
