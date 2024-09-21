using Microsoft.AspNetCore.SignalR;
using WebApiSignalR.Helpers;

namespace WebApiSignalR.Hubs
{
    public class MessageHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveConnectInfo", "User Connected");
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.Others.SendAsync("DisconnectInfo", "User disconnected");
        }
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message + "'s Offer is ", FileHelper.Read());
        }
        public async Task SendTime()
        {
            await Clients.Others.SendAsync("ReceiveTime", "stop");
        }

        public async Task SendStop()
        {
            await Clients.All.SendAsync("ReceiveStop", "stop");
        }

        public async Task SendWinner(string message)
        {
            await Clients.All.SendAsync("ReceiveWinner", message + $" is Winner.{message} gives ", FileHelper.Read());
        }
    }
}