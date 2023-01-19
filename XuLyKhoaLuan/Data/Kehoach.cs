using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Kehoach
    {
        public int MaKh { get; set; }
        public string TenKh { get; set; } = null!;
        public int SoLuongDt { get; set; }
        public DateTime? ThoiGianBd { get; set; }
        public DateTime? ThoiGianKt { get; set; }
        public string? HinhAnh { get; set; }
        public string? FileKh { get; set; }
        public string? MaKhoa { get; set; }
        public string? MaBm { get; set; }

        public virtual Bomon? MaBmNavigation { get; set; }
        public virtual Khoa? MaKhoaNavigation { get; set; }
    }
}
