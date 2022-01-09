using ECommerceApp.Data.Helper;
using ECommerceApp.Data.Models;
using ECommerceApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<JsonPagedList> GetAllProduct(string filterText, int pageIndex, int pageLength, string sortColumn)
        {
            return await _productRepository.GetAllProduct(filterText,pageIndex,pageLength,sortColumn);
        }

        public async Task<string> InsertProduct(ProductAttributeMapping productAttributeMapping)
        {
            return await _productRepository.InsertProduct(productAttributeMapping);
        }

        public async Task<ProductCategoryMapping> GetProduct(long ProductId)
        {
            return await _productRepository.GetProduct(ProductId);
        }

    }
}
