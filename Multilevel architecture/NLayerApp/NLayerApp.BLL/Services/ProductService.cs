﻿using NLayerApp.BLL.Interfaces;
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
using NLayerApp.DAL.Repositories;
using AutoMapper.Configuration;

namespace NLayerApp.BLL.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork Database { get; set; }
        IMapper mapper;

        public ProductService(IUnitOfWork database)
        {
            this.Database = database;
        }

        public void CreateProduct(ProductDTO productDTO)
        {
            //assign discount
            productDTO.Price = new Discount(0.1m).GetDiscountedPrice(productDTO.Price);

            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()));
            Product product = mapper.Map<ProductDTO, Product>(productDTO);

            Database.Products.AddOrUpdate(product);
            Database.Save();
        }

        public void AssignCategory(ProductDTO productDTO, CategoryDTO categoryDTO)
        {
            Product product = Database.Products.Get(productDTO.Id);
            if (product == null)
                throw new ValidationException("Product not found", "");

            Category category = (Database.Categories as CategoryRepository).FindByName(categoryDTO.Name);         
            if (category == null)
            {
                IMapper categoryMapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, Category>()));
                category = categoryMapper.Map<CategoryDTO, Category>(categoryDTO);
                Database.Categories.AddOrUpdate(category);
            }
                
            product.Category = category;
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

            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()));
            return mapper.Map<Product, ProductDTO>(product); ;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()));
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(Database.Products.GetAll()); ;
        }

        public void DeleteProduct(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set 'id' of product", "");

            var product = Database.Products.Get(id.Value);
            if (product == null)
                throw new ValidationException("Product not found", "");

            Database.Products.Delete(product);
            Database.Save();
        }
    }
}