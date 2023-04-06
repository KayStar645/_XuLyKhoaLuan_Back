using Microsoft.AspNetCore.SignalR;

namespace XuLyKhoaLuan.Helpers
{
    public class Websocket : Hub
    {
        // 1. Báo cáo
        public async Task SendForBaoCao(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromBaoCao", dataChange);
        }

        // 2. Bình luận
        public async Task SendForBinhLuan(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromBinhLuan", dataChange);
        }

        // 3. Bộ môn
        public async Task SendForBoMon(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromBoMon", dataChange);
        }

        // 4. Chuyên ngành
        public async Task SendForChuyenNganh(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromChuyenNganh", dataChange);
        }

        // 5. Công việc
        public async Task SendForCongViec(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromCongViec", dataChange);
        }

        // 6. Đăng ký
        public async Task SendForDangKy(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromDangKy", dataChange);
        }

        // 7. Đề tài - Chuyên ngành
        public async Task SendForDeTai_ChuyenNganh(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromDeTai_ChuyenNganh", dataChange);
        }

        // 8. Đề tài
        public async Task SendForDeTai(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromDeTai", dataChange);
        }

        // 9. Đợt đăng ký
        public async Task SendForDotDangKy(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromDotDangKy", dataChange);
        }

        // 10. Duyệt đề tài
        public async Task SendForDuyetDT(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromDuyetDT", dataChange);
        }

        // 11. Giảng viên
        public async Task SendForGiangVien(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromGiangVien", dataChange);
        }

        // 12. Giáo vụ
        public async Task SendForGiaoVu(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromGiaoVu", dataChange);
        }

        // 13. Hướng dẫn chấm
        public async Task SendForHuongDanCham(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromHuongDanCham", dataChange);
        }

        // 14. Hướng dẫn góp ý
        public async Task SendForHuongDanGopY(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromHuongDanGopY", dataChange);
        }

        // 15. Hội đồng phản biện chấm
        public async Task SendForHoiDongPhanBienCham(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromHoiDongPhanBienCham", dataChange);
        }

        // 16. Hội đồng phản biện nhận xét
        public async Task SendForHoiDongPhanBienNhanXet(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromHoiDongPhanBienNhanXet", dataChange);
        }

        // 17. Hội đồng phản biện
        public async Task SendForHoiDongPhanBien(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromHoiDongPhanBien", dataChange);
        }

        // 18. Hội đồng
        public async Task SendForHoiDong(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromHoiDong", dataChange);
        }

        // 19. Hướng dẫn
        public async Task SendForHuongDan(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromHuongDan", dataChange);
        }

        // 20. Kế hoạch
        public async Task SendForKeHoach(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromKeHoach", dataChange);
        }

        // 21. Khoa
        public async Task SendForKhoa(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromKhoa", dataChange);
        }

        // 22. Lời mời
        public async Task SendForLoiMoi(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromLoiMoi", dataChange);
        }

        // 23. Nhiệm vụ
        public async Task SendForNhiemVu(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromNhiemVu", dataChange);
        }

        // 24. Nhóm
        public async Task SendForNhom(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromNhom", dataChange);
        }

        // 25. Phản biện chấm
        public async Task SendForPhanBienCham(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromPhanBienCham", dataChange);
        }

        // 26. Phản biện nhận xét
        public async Task SendForPhanBienNhanXet(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromPhanBienNhanXet", dataChange);
        }

        // 27. Phản biện
        public async Task SendForPhanBien(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromPhanBien", dataChange);
        }

        // 28. Ra đề
        public async Task SendForRaDe(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromRaDe", dataChange);
        }

        // 29. Sinh viên
        public async Task SendForSinhVien(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromSinhVien", dataChange);
        }

        // 30. Tham gia hội đồng
        public async Task SendForThamGiaHoiDong(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromThamGiaHoiDong", dataChange);
        }

        // 31.Tham gia 
        public async Task SendForThamGia(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromThamGia", dataChange);
        }

        // 32. Thông báo
        public async Task SendForThongBao(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromThongBao", dataChange);
        }

        // 33. Trưởng bộ môn
        public async Task SendForTruongBoMon(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromTruongBoMon", dataChange);
        }

        // 34. Trưởng khoa
        public async Task SendForTruongKhoa(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromTruongKhoa", dataChange);
        }

        // 35. Vai trò
        public async Task SendForVaiTro(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromVaiTro", dataChange);
        }

        // 36. Xác nhận
        public async Task SendForXacNhan(bool dataChange)
        {
            await Clients.All.SendAsync("ReceiveFromXacNhan", dataChange);
        }
    }
}
