using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Rade
    {
        public string MaGv { get; set; } = null!;
        public string MaDt { get; set; } = null!;
        public DateTime? NgayRa { get; set; }

        public virtual Detai MaDtNavigation { get; set; } = null!;
        public virtual Giangvien MaGvNavigation { get; set; } = null!;
    }
}
