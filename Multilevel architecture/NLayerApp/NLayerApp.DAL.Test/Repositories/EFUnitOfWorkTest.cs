using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLayerApp.DAL.Repositories;
using System.Collections.Generic;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System.Linq;
using System.Diagnostics;
using NLayerApp.DataForTesting;

namespace NLayerApp.DAL.Test.Repositories
{
    [TestClass]
    public class EFUnitOfWorkTest
    {
        private string connectionString = "name=NLayerContext";
        private EFUnitOfWork unitOfwork;

        //data
        private IList<Store> stores = StoreCollection.Stores as IList<Store>;
        private IList<Product> products = ProductsCollection.Products as IList<Product>;
        private IList<Category> categories = CategoriesCollection.Categories as IList<Category>;

        private UserRepository userRepo;
        private StoreRepository storeRepo;
        private ProductRepository productRepo;
        private CategoryRepository categoryRepo;

        [TestInitialize]
        public void Init()
        {
            unitOfwork = new EFUnitOfWork(connectionString);
            userRepo = unitOfwork.Users as UserRepository;
            storeRepo = unitOfwork.Stores as StoreRepository;
            productRepo = unitOfwork.Products as ProductRepository;
            categoryRepo = unitOfwork.Categories as CategoryRepository;
        }

        [TestMethod]
        public void TestAddOrUpdate()
        {
            //add
            DateTime dtRegistration = DateTime.Now;
            User user = new User("Jake", 27, dtRegistration);
            userRepo.AddOrUpdate(user);
            unitOfwork.Save();
            User userInDb = userRepo.FindByName("Jake");
            Assert.AreEqual(user.Name, userInDb.Name);

            //update
            userInDb.Age = 29;
            userRepo.AddOrUpdate(userInDb);


            //add categories to db
            foreach (var item in categories)
                categoryRepo.AddOrUpdate(item);
            unitOfwork.Save();

            //assign the category to products and add to db
            foreach (var item in products)
            {
                if (item.Name.Contains("Sumsung"))
                    item.Category = categories[1];
                else
                    item.Category = categories[0];

                productRepo.AddOrUpdate(item);
            }
            unitOfwork.Save();

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
            unitOfwork.Save();

            unitOfwork.Dispose();
        }



        [TestMethod]
        public void TestFindByProductOfStore()
        {
            Product product = products[0];
            List<Store> stores = storeRepo.FindByProduct(product.Name) as List<Store>;
            foreach (var item in stores)
                Trace.WriteLine(item.Name);

            unitOfwork.Dispose();
        }

        [TestMethod]
        public void TestFindByCategoryOfProduct()
        {
            List<Product> products = productRepo.FindByCategory(categories[0].Name) as List<Product>;
            foreach (var item in products)
                Trace.WriteLine(item.Name);

            unitOfwork.Dispose();
        }

        [TestMethod]
        public void TestDelete()
        {
            foreach (var item in productRepo.GetAll())
                productRepo.Delete(item);

            foreach (var item in categoryRepo.GetAll())
                categoryRepo.Delete(item);

            foreach (var item in storeRepo.GetAll())
                storeRepo.Delete(item);

            foreach (var item in userRepo.GetAll())
                userRepo.Delete(item);

            unitOfwork.Save();
            unitOfwork.Dispose();
        }
    }
}
