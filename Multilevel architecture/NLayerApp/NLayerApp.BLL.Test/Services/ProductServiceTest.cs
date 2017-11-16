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
using NLayerApp.DAL.Entities;

namespace NLayerApp.BLL.Services.Tests
{
    [TestClass()]
    public class ProductServiceTest
    {
        IProductService productService;
        IUnitOfWork unitOfWork;

        
        [TestInitialize()]
        public void init()
        {
            unitOfWork = new EFUnitOfWork("NLayerContext");
            productService = new ProductService(unitOfWork);
            productService.CreateProduct(new ProductDTO("Philips", 1100m));
        }

        [TestMethod()]
        public void AssignCategoryIsProductAndCategotyExistTest()
        {
            //add category to db
            unitOfWork.Categories.AddOrUpdate(new Category("Mobile phone"));
            unitOfWork.Save();

            ProductDTO productDTO = productService.GetProducts().FirstOrDefault();
            productService.AssignCategory(productDTO, new CategoryDTO("Mobile phone"));

            //check of test
            Product productInDb = unitOfWork.Products.Get(productDTO.Id);
            Assert.AreEqual(productInDb.CategoryId, unitOfWork.Categories.FindBy(c => c.Name == "Mobile phone").FirstOrDefault().Id);
            DeleteData();
        }

        [TestMethod()]
        public void AssignCategoryIsOnlyProductExistTest()
        {          
            ProductDTO productDTO = productService.GetProducts().FirstOrDefault();
            productService.AssignCategory(productDTO, new CategoryDTO("IPad"));

            //check of test
            Product productInDb = unitOfWork.Products.Get(productDTO.Id);
            Assert.AreEqual(productInDb.CategoryId, unitOfWork.Categories.FindBy(c => c.Name == "IPad").FirstOrDefault().Id);
            DeleteData();
        }

       
        public void DeleteData()
        {
            foreach (var item in productService.GetProducts())
                productService.DeleteProduct(item.Id);
               
            foreach (var item in unitOfWork.Categories.GetAll())
                unitOfWork.Categories.Delete(item);

            unitOfWork.Save();
        }
    }
}
