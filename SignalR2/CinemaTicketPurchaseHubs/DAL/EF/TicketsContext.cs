using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CinemaTicketPurchaseHubs.DAL.EF
{
    public class TicketsContext : DbContext
    {
        public TicketsContext(string strConnection) : base(strConnection)
        {
        }
        
        public virtual DbSet<Ticket> Tickets { get; set; }
    }
}