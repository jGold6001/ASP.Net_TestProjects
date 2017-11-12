using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using OnionApp.Infrastructure.Data.Repositories;
using OnionApp.Infrastructure.Data.EF;
using OnionApp.Domain.Core;

namespace OnionApp.Infrastructure.Data.Test.Repositories
{
   
    [TestClass]
    public class UserRepositoryTest
    {
        UserRepository userRepo = new UserRepository(new MyContext());

        [TestMethod]
        public void TestAddOrUpdateUser()
        {
            //add
            User user = new User("Jake", 27);
            userRepo.AddOrUpdate(user);
            userRepo.Save();
            User userInDb = userRepo.FindByName("Jake");
            Assert.AreEqual(user.Name, userInDb.Name);

            //update
            userInDb.Age = 29;
            userRepo.AddOrUpdate(userInDb);
            userRepo.Save();
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            User userInDb = userRepo.FindByName("Jake");
            userRepo.Delete(userInDb);
            userRepo.Save();
        }
    }
}
