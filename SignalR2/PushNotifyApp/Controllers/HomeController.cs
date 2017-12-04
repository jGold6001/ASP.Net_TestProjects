using Microsoft.AspNet.SignalR;
using PushNotifyApp.Hubs;
using PushNotifyApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PushNotifyApp.Controllers
{    
    public class HomeController : Controller
    {
        BookContext db = new BookContext("BookContext");
            
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            db.Books.AddOrUpdate(book);
            db.SaveChanges();
            SendMessage("Add new book");
            return RedirectToAction("Index");
        }

        private void SendMessage(string message)
        {
            // Get context hub
            var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

            // send messege
            context.Clients.All.displayMessage(message);
        }
    }
}