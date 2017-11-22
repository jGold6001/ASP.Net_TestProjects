using AutoMapper;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.BLL.Interfaces;
using NLayerApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayerApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        IProductService productService;
        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }
        public ActionResult Index()
        {
            IEnumerable<ProductDTO> productsDTOs = productService.GetProducts();
            Mapper.Initialize(ctg => ctg.CreateMap<ProductDTO, ProductViewModel>());
            var products = Mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(productsDTOs);
            if(products.Count == 0)
                return Content("<h1>Database is empty<h2>");

            return View(products);
        }

        public ActionResult GetProduct(int? id)
        {
            try
            {
                ProductDTO productDTO = productService.GetProduct(id);
                Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
                var product = Mapper.Map<ProductDTO, ProductViewModel>(productDTO);
                return Content($"The product {product.Name}  is cost {product.Price}");
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductViewModel productVM)
        {
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<ProductViewModel, ProductDTO>());
                var productDTO = Mapper.Map<ProductViewModel, ProductDTO>(productVM);
                productService.CreateProduct(productDTO);
                return Content($"<h2>The {productDTO.Name} is created</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(productVM);
        }

        protected override void Dispose(bool disposing)
        {
            productService.Dispose();
            base.Dispose(disposing);
        }
    }
}