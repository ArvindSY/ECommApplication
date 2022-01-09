using ECommerceApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ECommerceApp.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        protected readonly ECommerceDemoContext ECommerceDemoPatternDemoContext;

        public ProductCategoryRepository(ECommerceDemoContext eCommerceDemoPatternDemoContext)
        {
            ECommerceDemoPatternDemoContext = eCommerceDemoPatternDemoContext;
        }

        public List<ProductCategory> GetAllProductCategory()
        {
            return ECommerceDemoPatternDemoContext.ProductCategories.ToList();
        }
    }
}
