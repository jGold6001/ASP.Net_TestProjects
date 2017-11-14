using NLayerApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.BLL.DTO;
using NLayerApp.DAL.Interfaces;
using AutoMapper;
using NLayerApp.DAL.Entities;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.BLL.BusinessModels;

namespace NLayerApp.BLL.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork Database { get; set; }

        public ProductService(IUnitOfWork database)
        {
            this.Database = database;
        }

        public void CreateProduct(ProductDTO productDTO)
        {
            //assign discount
            productDTO.Price = new Discount(0.1m).GetDiscountedPrice(productDTO.Price);

            Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, Product>());
            Product product = Mapper.Map<ProductDTO, Product>(productDTO);

            Database.Products.AddOrUpdate(product);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set 'id' of product", "");

            var product = Database.Products.Get(id.Value);
            if(product == null)
                throw new ValidationException("Product not found", "");

            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDTO>());
            return Mapper.Map<Product, ProductDTO>(product); ;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDTO>());
            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll()); ;
        }

        public void AssignCategory(ProductDTO productDTO, CategoryDTO categoryDTO)
        {
            Product product = Database.Products.Get(productDTO.Id);
            if (product == null)
                throw new ValidationException("Product not found", "");

            //GOTO

        }
    }
}
