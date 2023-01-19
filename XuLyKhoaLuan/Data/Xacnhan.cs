using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Xacnhan
    {
        public string MaGv { get; set; } = null!;
        public string MaDt { get; set; } = null!;
        public bool? DuaRaHd { get; set; }

        public virtual Detai MaDtNavigation { get; set; } = null!;
        public virtual Giangvien MaGvNavigation { get; set; } = null!;
    }
}
