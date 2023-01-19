using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Truongkhoa
    {
        public string MaKhoa { get; set; } = null!;
        public string MaGv { get; set; } = null!;
        public DateTime NgayNhanChuc { get; set; }
        public DateTime? NgayNghi { get; set; }

        public virtual Giangvien MaGvNavigation { get; set; } = null!;
        public virtual Khoa MaKhoaNavigation { get; set; } = null!;
    }
}
