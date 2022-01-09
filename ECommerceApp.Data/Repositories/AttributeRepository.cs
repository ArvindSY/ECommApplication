using ECommerceApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ECommerceApp.Data.Repositories
{
    public class AttributeRepository : IAttributeRepository
    {
        protected readonly ECommerceDemoContext ECommerceDemoPatternDemoContext;

        public AttributeRepository(ECommerceDemoContext eCommerceDemoPatternDemoContext)
        {
            ECommerceDemoPatternDemoContext = eCommerceDemoPatternDemoContext;
        }

        public async Task<List<AttributeLookUpMapping>> GetProductWiseAttribute(long productId)
        {
            List<AttributeLookUpMapping> lstProduct = new List<AttributeLookUpMapping>();

            using (var context = new ECommerceDemoContext())
            {
                lstProduct = await Task.FromResult(ECommerceDemoPatternDemoContext.ProductAttributes.Join(
                             ECommerceDemoPatternDemoContext.ProductAttributeLookups, p => p.AttributeId, pa => pa.AttributeId, (p, pa) => new { p, pa })
                             .Where(e => e.p.ProductId == productId)
                             .Select(e => new AttributeLookUpMapping()
                             {
                                 ProductAttrId = e.p.ProductAttrId,
                                 ProductId = e.p.ProductId,
                                 AttributeId = e.p.AttributeId,
                                 AttributeValue = e.p.AttributeValue,
                                 AttributeName = e.pa.AttributeName
                             }).ToList());
            }

            return lstProduct;
        }

        public async Task<List<ProductAttributeLookup>> GetAllAttributeLookUp(int CategoryId)
        {
            List<ProductAttributeLookup> lstProductAttributeLookup = new List<ProductAttributeLookup>();

            using (var context = new ECommerceDemoContext())
            {
                lstProductAttributeLookup = await Task.FromResult(ECommerceDemoPatternDemoContext.ProductAttributeLookups.Where(e => e.ProdCatId == CategoryId).ToList());
            }

            return lstProductAttributeLookup;
        }        

        public async Task<List<ProductAttribute>> GetProductAttribute(long ProductId)
        {
            return await Task.FromResult(ECommerceDemoPatternDemoContext.ProductAttributes.Where(e => e.ProductId == ProductId).ToList());
        }

    }
}
