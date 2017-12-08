using AutoMapper;
using CinemaTicketPurchaseHubs.DAL.EF;
using CinemaTicketPurchaseHubs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTicketPurchaseHubs.Controllers
{
    public class HomeController : Controller
    {
        IMapper mapper;
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult GetPurchase(PurchaseViewModel purchaseVM)
        {
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PurchaseViewModel, Purchase>()));
            var purchase = mapper.Map<PurchaseViewModel, Purchase>(purchaseVM);
            return View("GetPurchase", purchase);
        }
    }
}