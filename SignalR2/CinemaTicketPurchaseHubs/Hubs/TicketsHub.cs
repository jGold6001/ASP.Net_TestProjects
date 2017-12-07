using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using CinemaTicketPurchaseHubs.Models;

namespace CinemaTicketPurchaseHubs.Hubs
{
    public class TicketsHub : Hub
    {
        public void Send(object[] places)
        {
            Clients.AllExcept(Context.ConnectionId).addData(places);
        }

    }
}