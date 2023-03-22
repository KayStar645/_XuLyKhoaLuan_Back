using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Thongbao
    {
        public int MaTb { get; set; }
        public string TenTb { get; set; } = null!;
        public string? NoiDung { get; set; }
        public string? HinhAnh { get; set; }
        public string? FileTb { get; set; }
        public DateTime? NgayTb { get; set; }
        public string? MaKhoa { get; set; }

        public virtual Khoa? MaKhoaNavigation { get; set; }
    }
}
