using OnionApp.Domain.Core;
using OnionApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnionApp.Controllers
{
    public class UserController : Controller
    {
        IGenericRepository<User> userRepo;
 
        // GET: User
        public ActionResult Index()
        {
            return View("Index");
        }

        public UserController(IGenericRepository<User> userRepo)
        {
            this.userRepo = userRepo;
        }

        public ActionResult GetUser(int id)
        {
            User user = userRepo.Get(id);
            return View();
        }
    }
}