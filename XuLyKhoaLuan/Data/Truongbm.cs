using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Truongbm
    {
        public string MaBm { get; set; } = null!;
        public string MaGv { get; set; } = null!;
        public DateTime? NgayNhanChuc { get; set; }
        public DateTime? NgayNghi { get; set; }

        public virtual Bomon MaBmNavigation { get; set; } = null!;
        public virtual Giangvien MaGvNavigation { get; set; } = null!;
    }
}
