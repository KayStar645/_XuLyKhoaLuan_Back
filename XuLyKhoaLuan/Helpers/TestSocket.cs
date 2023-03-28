using Microsoft.AspNetCore.SignalR;

namespace XuLyKhoaLuan.Helpers
{
    public class TestSocket : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
