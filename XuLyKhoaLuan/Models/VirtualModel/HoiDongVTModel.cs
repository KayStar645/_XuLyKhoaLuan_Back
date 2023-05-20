namespace XuLyKhoaLuan.Models.VirtualModel
{
    public class HoiDongVTModel
    {
        public string MaHD { get; set; } = null!;
        public string TenHD { get; set; } = null!;
        public DateTime? NgayLap { get; set; }
        public DateTime? ThoiGianBD { get; set; }
        public DateTime? ThoiGianKT { get; set; }
        public string? DiaDiem { get; set; }
        public string? MaBm { get; set; }
        public GiangVienVTModel ChuTich { get; set; }
        public GiangVienVTModel ThuKy { get; set; }
        public List<GiangVienVTModel> UyViens { get; set; }

    }
}
