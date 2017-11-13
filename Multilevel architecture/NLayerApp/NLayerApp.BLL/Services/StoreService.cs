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

namespace NLayerApp.BLL.Services
{
    public class StoreService : IStoreService
    {
        IUnitOfWork Database { get; set; }

        public StoreService(IUnitOfWork database)
        {
            this.Database = database;
        }

        public void AddOrUpdateProduct(ProductDTO product)
        {
            //TODO
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
    }
}
