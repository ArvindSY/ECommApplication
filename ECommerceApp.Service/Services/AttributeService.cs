using ECommerceApp.Data.Models;
using ECommerceApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Service.Services
{
    public class AttributeService : IAttributeService
    {
        private readonly IAttributeRepository _attributeRepository;

        public AttributeService(IAttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        public async Task<List<AttributeLookUpMapping>> GetProductWiseAttribute(long ProductId)
        {
            return await _attributeRepository.GetProductWiseAttribute(ProductId);
        }

        public async Task<List<ProductAttributeLookup>> GetAllAttributeLookUp(int CategoryId)
        {
            return await _attributeRepository.GetAllAttributeLookUp(CategoryId);
        }


        public async Task<List<ProductAttribute>> GetProductAttribute(long ProductId)
        {
            return await _attributeRepository.GetProductAttribute(ProductId);
        }

    }
}
