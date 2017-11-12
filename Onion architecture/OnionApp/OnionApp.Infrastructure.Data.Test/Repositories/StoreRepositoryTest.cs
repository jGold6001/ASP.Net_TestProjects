using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using OnionApp.Infrastructure.Data.EF;
using OnionApp.Infrastructure.Data.Repositories;
using OnionApp.Domain.Core;
using OnionApp.Infrastructure.Data.Test.DataCollections;

namespace OnionApp.Infrastructure.Data.Test.Repositories
{
    [TestClass]
    public class StoreRepositoryTest
    {
        private DbContext context = new MyContext();

        private StoreRepository storeRepo;
        private ProductRepository productRepo;
        private CategoryRepository categoryRepo;

        private IList<Store> stores = StoreCollection.Stores as IList<Store>;
        private IList<Product> products = ProductsCollection.Products as IList<Product>;
        private IList<Category> categories = CategoriesCollection.Categories as IList<Category>;

        [TestInitialize]
        public void Init()
        {
            storeRepo = new StoreRepository(context);
            productRepo = new ProductRepository(context);
            categoryRepo = new CategoryRepository(context);
        }

        [TestMethod]
        public void TestAddOrUpdateStore()
        {
            //add categories to db
            foreach (var item in categories)
                categoryRepo.AddOrUpdate(item);
            categoryRepo.Save();

            //assign the category to products and add to db
            foreach (var item in products)
            {
                if (item.Name.Contains("Sumsung"))
                    item.Category = categories[1];
                else
                    item.Category = categories[0];

                productRepo.AddOrUpdate(item);
            }
            productRepo.Save();

            //add products to stores
            Store rozetkaStore = stores[0];
            rozetkaStore.Products.Add(products[0]);
            rozetkaStore.Products.Add(products[2]);
            rozetkaStore.Products.Add(products[1]);

            Store mobidickStore = stores[1];
            mobidickStore.Products.Add(products[0]);
            mobidickStore.Products.Add(products[3]);
            mobidickStore.Products.Add(products[2]);

            //add stores to db
            storeRepo.AddOrUpdate(rozetkaStore);
            storeRepo.AddOrUpdate(mobidickStore);
            storeRepo.Save();
        }


        [TestMethod]
        public void TestFindByProductStore()
        {
            Product product = products[0];
            List<Store> stores = storeRepo.FindByProduct(product.Name) as List<Store>;
            foreach (var item in stores)
                Trace.WriteLine(item.Name);
        }

        [TestMethod]
        public void TestDeleteStore()
        {
            foreach (var item in productRepo.GetAll())
                productRepo.Delete(item);
            productRepo.Save();


            foreach (var item in categoryRepo.GetAll())
                categoryRepo.Delete(item);           
            categoryRepo.Save();

            foreach (var item in storeRepo.GetAll())
                storeRepo.Delete(item);
            storeRepo.Save();
        }
    }
}
