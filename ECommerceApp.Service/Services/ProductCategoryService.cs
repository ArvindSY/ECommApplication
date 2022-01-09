using ECommerceApp.Data.Models;
using ECommerceApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Service.Services
{

    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public List<ProductCategory> GetAllProductCategory()
        {
            return _productCategoryRepository.GetAllProductCategory();
        }


    }
}
