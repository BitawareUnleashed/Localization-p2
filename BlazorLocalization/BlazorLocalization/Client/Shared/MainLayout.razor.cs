using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLocalization.Client.Shared
{
    public partial class MainLayout
    {
        private HubConnection hubConnection;

        public string BackEndMessage { get; private set; }

        /// <summary>
        /// Reconnection timings policy
        /// </summary>
        private readonly TimeSpan[] reconnectionTimeouts =
        {
            TimeSpan.FromSeconds(0),
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(3),
            TimeSpan.FromSeconds(5),
            TimeSpan.FromSeconds(8),
            TimeSpan.FromSeconds(13),
            TimeSpan.FromSeconds(21),
            TimeSpan.FromSeconds(34)
        };

        protected override async Task OnInitializedAsync()
        {
            // SignalR Hub
            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/communicationhub"))
                .WithAutomaticReconnect(reconnectionTimeouts)
                .Build();

            hubConnection.On<string>("MessageAvailable", (e) =>
            {
                BackEndMessage = e;
                StateHasChanged();
            });

            await hubConnection.StartAsync();
        }
    }
}
