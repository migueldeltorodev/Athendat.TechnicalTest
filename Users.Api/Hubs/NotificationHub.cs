using Microsoft.AspNetCore.SignalR;

namespace Users.Api.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendOperationNotification(string username, string operation)
        {
            await Clients.All.SendAsync("ReceiveOperationNotification", username, operation);
        }
    }
}