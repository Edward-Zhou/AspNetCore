using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer.Hubs
{
    public class TimeHub: Hub
    {
        public async Task UpdateTime(string message)
        {
            if (Clients != null)
            {
                await Clients?.All.SendAsync("ReceiveMessage", message);
            }
        }
    }
}
