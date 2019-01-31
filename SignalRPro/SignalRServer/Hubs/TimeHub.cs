using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer.Hubs
{
    [Authorize]
    public class TimeHub: Hub
    {
        public async Task UpdateTime(string message)
        {
            if (Clients != null)
            {
                await Clients?.All.SendAsync("ReceiveMessage", message);
            }
        }
        public Task SendMessage(Message message)
        {
            // ... some logic
            return Task.CompletedTask;
        }
    }
}
