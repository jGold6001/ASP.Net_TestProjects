using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTicketPurchaseHubs.Models
{
    public class PurchaseViewModel
    {
        public long Id { get; set; }
        public ICollection<TicketViewModel> Tickets { get; set; }
        public decimal Sum { get; set; }
    }
}