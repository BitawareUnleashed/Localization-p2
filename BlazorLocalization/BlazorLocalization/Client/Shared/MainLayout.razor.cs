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
        private HubConnection hubConnection = null!;

        public string Message { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            // SignalR Hub
            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/communicationhub"))
                .WithAutomaticReconnect(new[] { TimeSpan.FromSeconds(1) })
                .Build();

            hubConnection.On<string>("MessageAvailable", (e) =>
            {
                Message = e;
                StateHasChanged();
            });

            await hubConnection.StartAsync();
        }
    }
}
