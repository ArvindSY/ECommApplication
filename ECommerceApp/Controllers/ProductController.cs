using ECommerceApp.Middleware;
using ECommerceApp.Data.Models;
using ECommerceApp.Models;
using ECommerceApp.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Data.Helper;

namespace ECommerceApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IAttributeService _attributeService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService, IAttributeService attributeService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _attributeService = attributeService;
        }


        [HttpGet]
        [Route("Product/{ProductId?}")]
        public async Task<IActionResult> Index(long ProductId)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Category = GetAllCategory();
            Product objProduct = new Product();
            List<AttributeLookUpMapping> lstProductAttMapping = new List<AttributeLookUpMapping>();
            if (ProductId != 0)
            {
                objProduct = await _productService.GetProduct(ProductId);
                lstProductAttMapping = await _attributeService.GetProductWiseAttribute(ProductId);
            }
            productViewModel.Product = objProduct;
            productViewModel.AttributeMapping = lstProductAttMapping;
            return View("Index", productViewModel);
        }

        public List<ProductCategory> GetAllCategory()
        {
            List<ProductCategory> lstProductCategory = _productCategoryService.GetAllProductCategory();
            return lstProductCategory;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllAttributeLookUp(int categoryId = 0)
        {
            return Json(await _attributeService.GetAllAttributeLookUp(categoryId));

        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {

            ProductAttributeMapping objProductAttributeMapping = new ProductAttributeMapping();
            objProductAttributeMapping.ProductId = productViewModel.Product.ProductId;
            objProductAttributeMapping.ProdCatId = productViewModel.Product.ProdCatId;
            objProductAttributeMapping.ProdName = productViewModel.Product.ProdName;
            objProductAttributeMapping.ProdDescription = productViewModel.Product.ProdDescription;

            if (productViewModel.ProductAttribute != null && productViewModel.ProductAttribute.Count() > 0)
            {
                objProductAttributeMapping.ProductAttribute = productViewModel.ProductAttribute;
            }

            string result = await _productService.InsertProduct(objProductAttributeMapping);
            return Json(new { message = result });

        }

    }
}
