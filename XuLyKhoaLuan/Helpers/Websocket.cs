using Microsoft.AspNetCore.SignalR;

namespace XuLyKhoaLuan.Helpers
{
    public class Websocket : Hub
    {
        // Thông báo
        public async Task SendForThongBao(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromThongBao", dataChange);
        }

        // Kế hoạch
        public async Task SendForKeHoach(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromKeHoach", dataChange);
        }

        // Nhiệm vụ
        public async Task SendForNhiemVu(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromNhiemVu", dataChange);
        }

        // Đề tài
        public async Task SendForDeTai(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromDeTai", dataChange);
        }

        // Sinh viên
        public async Task SendForSinhVien(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromSinhVien", dataChange);
        }

        // Giảng viên
        public async Task SendForGiangVien(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromGiangVien", dataChange);
        }

        // Tham gia
        public async Task SendForThamGia(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromThamGia", dataChange);
        }

        // Duyệt đề tài
        public async Task SendForDuyetDT(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromDuyetDT", dataChange);
        }
    }
}
