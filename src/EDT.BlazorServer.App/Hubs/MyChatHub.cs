using Microsoft.AspNetCore.SignalR;

namespace EDT.BlazorServer.App.Hubs;

public class MyChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
