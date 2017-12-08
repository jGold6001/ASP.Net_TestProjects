using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTicketPurchaseHubs.DAL.EF
{
    public class Purchase
    {
        public long Id { get; set; }
        public string Movie { get; set; }
        public string Cinema { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public decimal Sum { get; set; }
        public Purchase()
        {
            Tickets = new List<Ticket>();
        }
    }
}