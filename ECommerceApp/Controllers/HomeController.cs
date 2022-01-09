using ECommerceApp.Data.Helper;
using ECommerceApp.Data.Models;
using ECommerceApp.Models;
using ECommerceApp.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Controllers
{
    public class HomeController : Controller
    {        
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {            
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GetAllProduct()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = (Convert.ToInt32(start) / Convert.ToInt32(length) + 1);

            JsonPagedList objJsonPagedList = new JsonPagedList();
            objJsonPagedList = await _productService.GetAllProduct(searchValue, skip, pageSize, sortColumn + " " + sortColumnDirection);
            List<ProductCategoryMapping> lstProduct = JsonConvert.DeserializeObject<List<ProductCategoryMapping>>(objJsonPagedList.JsonSourceList);
            return Json(new { draw = draw, recordsFiltered = objJsonPagedList.TotalCount, recordsTotal = objJsonPagedList.TotalCount, data = lstProduct });
        }

    }
}
