using ECommerceApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using ECommerceApp.Data.Helper;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;

namespace ECommerceApp.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly ECommerceDemoContext ECommerceDemoContext;

        public ProductRepository(ECommerceDemoContext eCommerceDemoContext)
        {
            ECommerceDemoContext = eCommerceDemoContext;
        }

        public async Task<JsonPagedList> GetAllProduct(string filterText, int pageIndex, int pageLength, string sortColumn)
        {
            JsonPagedList jsonResponse = new JsonPagedList();
            using (var context = new ECommerceDemoContext())
            {
                var lstProduct = ECommerceDemoContext.Products.Join(
                               ECommerceDemoContext.ProductCategories, p => p.ProdCatId, pc => pc.ProdCatId, (p, pc) => new { p, pc })
                               .Where(e => e.p.ProdName.Contains(filterText) || e.pc.CategoryName.Contains(filterText))
                               .Select(e => new ProductCategoryMapping()
                               {
                                   ProductId = e.p.ProductId,
                                   ProdName = e.p.ProdName,
                                   CategoryName = e.pc.CategoryName
                               }).OrderBy(sortColumn);

                if (lstProduct != null && lstProduct.Count() > 0)
                {
                    if (pageIndex != 0)
                    {
                        var listResponse = await Task.FromResult(lstProduct.Skip((pageIndex - 1) * pageLength).Take(pageLength).ToList());
                        jsonResponse.TotalCount = lstProduct.Count();
                        jsonResponse.JsonSourceList = JsonConvert.SerializeObject(listResponse);
                    }
                    else
                    {
                        var listResponse = await Task.FromResult(lstProduct.Take(pageLength).ToList());
                        jsonResponse.TotalCount = lstProduct.Count();
                        jsonResponse.JsonSourceList = JsonConvert.SerializeObject(listResponse);
                    }
                }
                else
                {
                    jsonResponse.TotalCount = 0;
                    jsonResponse.JsonSourceList = "";
                }

            }

            return jsonResponse;
        }

        public async Task<string> InsertProduct(ProductAttributeMapping productAttributeMapping)
        {            
            try
            {
                Product objProduct = new Product()
                {
                    ProductId = productAttributeMapping.ProductId,
                    ProdCatId = productAttributeMapping.ProdCatId,
                    ProdName = productAttributeMapping.ProdName,
                    ProdDescription = productAttributeMapping.ProdDescription,
                };

                string productJson = JsonConvert.SerializeObject(objProduct);
                string attrJson = JsonConvert.SerializeObject(productAttributeMapping.ProductAttribute);
                var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@ProductJson",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = productJson
                        },
                        new SqlParameter() {
                            ParameterName = "@AttributeJson",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = attrJson
                        },
                        new SqlParameter() {
                            ParameterName = "@OutResult",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size=100,
                            Direction = System.Data.ParameterDirection.Output,
                        }};

                await ECommerceDemoContext.Database.ExecuteSqlRawAsync("EXECUTE  dbo.[InsertUpdateProduct] @ProductJson,@AttributeJson,@OutResult out", param);
                return Convert.ToString(param[2].Value);                

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ProductCategoryMapping> GetProduct(long ProductId)
        {
            return await Task.FromResult(ECommerceDemoContext.Products.Where(e => e.ProductId == ProductId).Select(e => new ProductCategoryMapping()
            {
                ProductId = e.ProductId,
                CategoryName = string.Empty,
                ProdCatId = e.ProdCatId,
                ProdName = e.ProdName,
                ProdDescription = e.ProdDescription
            }).SingleOrDefault());
        }

    }
}
