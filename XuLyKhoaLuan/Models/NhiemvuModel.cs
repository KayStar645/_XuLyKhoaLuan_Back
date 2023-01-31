using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public class NhiemvuModel
    {
        public int MaNv { get; set; }
        public string TenNv { get; set; } = null!;
        public int SoLuongDt { get; set; }
        public DateTime? ThoiGianBd { get; set; }
        public DateTime? ThoiGianKt { get; set; }
        public string? HinhAnh { get; set; }
        public string? FileNv { get; set; }
        public string? MaBm { get; set; }
        public string? MaGv { get; set; }

    }
}
