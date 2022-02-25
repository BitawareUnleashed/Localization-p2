using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.SignalR;

namespace BlazorLocalization.Server.HubSignalR
{
    public class UiCommunicationHub : Hub
    {
        public async Task MessageAvailable(string e)
        {
            await Clients.All.SendAsync("MessageAvailable", e);
        }
    }
}
