using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorLocalization.Server.HubSignalR
{
    public class UiSender
    {
        private HubConnection hubConnection;
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

        public UiSender()
        {
            Init();
        }

        public void Init()
        {
            try
            {
                if (hubConnection != null) return;
                hubConnection = new HubConnectionBuilder()
                    .WithUrl(new Uri("https://localhost:7117/communicationhub"))
                    .WithAutomaticReconnect(reconnectionTimeouts)
                    .Build();

                Task.Run(async () =>
                {
                    try
                    {
                        await hubConnection.StartAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("TASK-" + ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("INIT-" + ex.Message);
            }
        }


        public async void SendAsync(string s)
        {
            try
            {
                await hubConnection.SendAsync("MessageAvailable", s);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
