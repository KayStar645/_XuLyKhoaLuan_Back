using Microsoft.AspNetCore.SignalR;

namespace XuLyKhoaLuan.Helpers
{
    public class Websocket : Hub
    {
        public async Task SendMessage(bool message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
