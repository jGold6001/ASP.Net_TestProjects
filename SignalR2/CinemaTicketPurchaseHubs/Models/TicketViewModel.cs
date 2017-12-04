using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTicketPurchaseHubs.Models
{
    public class TicketViewModel
    {
        public long Id { get; set; }
        public string Movie { get; set; }
        public string SeanceDate { get; set; }
        public string SeanceTime { get; set; }
        public string Hall { get; set; }
        public string Tariff { get; set; }
        public decimal Price { get; set; }
    }
}