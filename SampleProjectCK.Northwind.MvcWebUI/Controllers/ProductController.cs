using SampleProjectCK.Northwind.Business.Abstract;
using SampleProjectCK.Northwind.Entities.Concrete;
using SampleProjectCK.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProjectCK.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }
        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "Gsm",
                QuantityPerUnit = "1",
                UnitPrice = 50
            });
            return "Added";
        }
        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product
            {
                CategoryId = 1,
                ProductName = "Gsm",
                QuantityPerUnit = "1",
                UnitPrice = 50
            },new Product {
                CategoryId = 1,
                ProductName = "Gsm",
                QuantityPerUnit = "1",
                UnitPrice = 30,
                ProductId=77
            });
            return "Done";
        }
    }
}