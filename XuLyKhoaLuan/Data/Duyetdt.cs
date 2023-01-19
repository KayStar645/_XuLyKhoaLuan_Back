using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Duyetdt
    {
        public string MaGv { get; set; } = null!;
        public string MaDt { get; set; } = null!;
        public int LanDuyet { get; set; }
        public DateTime NgayDuyet { get; set; }
        public string? NhanXet { get; set; }

        public virtual Detai MaDtNavigation { get; set; } = null!;
        public virtual Giangvien MaGvNavigation { get; set; } = null!;
    }
}
