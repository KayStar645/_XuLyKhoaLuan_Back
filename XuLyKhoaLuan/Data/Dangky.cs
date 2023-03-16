using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Dangky
    {
        public string MaNhom { get; set; } = null!;
        public string MaDt { get; set; } = null!;
        public DateTime NgayDk { get; set; }
        public DateTime? NgayGiao { get; set; }
        public DateTime? NgayBd { get; set; }
        public DateTime? NgayKt { get; set; }

        public virtual Detai MaDtNavigation { get; set; } = null!;
        public virtual Nhom MaNhomNavigation { get; set; } = null!;
    }
}
