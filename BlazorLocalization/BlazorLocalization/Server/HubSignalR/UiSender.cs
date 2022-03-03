using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorLocalization.Server.HubSignalR
{
    public class UiSender
    {
        private HubConnection? hubConnection;
        
        public UiSender()
        {
            Init();
        }

        void Init()
        {
            try
            {
                if (hubConnection != null) return;
                hubConnection = new HubConnectionBuilder()
                    .WithUrl(new Uri("https://localhost:7117/communicationhub"))
                    .WithAutomaticReconnect(new[] { TimeSpan.FromSeconds(1) })
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
                await hubConnection!.SendAsync("MessageAvailable", s);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
