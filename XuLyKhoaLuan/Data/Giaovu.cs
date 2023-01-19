using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Giaovu
    {
        public string MaGv { get; set; } = null!;
        public string TenGv { get; set; } = null!;
        public DateTime? NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public string? Email { get; set; }
        public string? Sdt { get; set; }
        public DateTime? NgayNhanViec { get; set; }
        public DateTime? NgayNghi { get; set; }
        public string? MaKhoa { get; set; }

        public virtual Khoa? MaKhoaNavigation { get; set; }
    }
}
