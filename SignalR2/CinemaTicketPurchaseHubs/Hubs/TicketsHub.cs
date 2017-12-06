using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace CinemaTicketPurchaseHubs.Hubs
{
    public class TicketsHub : Hub
    {
        public void Send(object Ticket)
        {
            Clients.All.addData(Ticket);
        }

    }
}