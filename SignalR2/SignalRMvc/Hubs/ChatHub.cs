using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRMvc.Models;
using System.Threading.Tasks;

namespace SignalRMvc.Hubs
{
    public class ChatHub : Hub
    {
        static List<User> Users = new List<User>();

        // Sending messages
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }

        // Connect a new user
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;


            if (!Users.Any(x => x.ConnectionId == id))
            {
                Users.Add(new User { ConnectionId = id, Name = userName });

                // Send the message to the current user
                Clients.Caller.onConnected(id, userName, Users);

                // We send a message to all users except the current one
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }

        // Disconnect the user
        public override Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.Name);
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}