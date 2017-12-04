using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using ChatRoomMVCPersistentConnection.Connection;

[assembly: OwinStartup(typeof(ChatRoomMVCPersistentConnection.Startup))]
namespace ChatRoomMVCPersistentConnection
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR<ChatConnection>("/chat");
        }
    }
}
