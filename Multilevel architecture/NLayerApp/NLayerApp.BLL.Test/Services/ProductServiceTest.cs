using NLayerApp.BLL.Services;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLayerApp.BLL.Interfaces;
using NLayerApp.BLL.DTO;
using Ninject.Modules;
using NLayerApp.BLL.Infrastructure;
using Ninject;
using NLayerApp.DAL.Interfaces;
using NLayerApp.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace NLayerApp.BLL.Services.Tests
{
    [TestClass()]
    public class ProductServiceTest
    {
        IProductService productService;

        [TestInitialize()]
        public void init()
        {
            IUnitOfWork unitOfWork = new EFUnitOfWork("NLayerContext");
            productService = new ProductService(unitOfWork);
        }

        [TestMethod()]
        public void CreateProductTest()
        {
            ProductDTO productDTO = new ProductDTO("Philips", 1100m);
            productService.CreateProduct(productDTO);
        }

        [TestMethod()]
        public void AssignCategoryIsProductExistTest()
        {
            ProductDTO productDTO = productService.GetProducts().FirstOrDefault();
            productService.AssignCategory(productDTO, new CategoryDTO("Mobile phone"));
            //Assert.AreSame(productService.GetProduct(productDTO.Id), productDTO);
        }
    }
}
