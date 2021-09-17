using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace UI.WebMvcCore.Utilities
{
    public class SignalRServer : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}