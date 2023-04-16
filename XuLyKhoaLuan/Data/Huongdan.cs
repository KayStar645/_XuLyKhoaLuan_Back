using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Huongdan
    {
        public Huongdan()
        {
            Congviecs = new HashSet<Congviec>();
            Hdgopies = new HashSet<Hdgopy>();
        }

        public string MaGv { get; set; } = null!;
        public string MaDt { get; set; } = null!;
        public DateTime? ThoiGianBd { get; set; }
        public DateTime? ThoiGianKt { get; set; }
        public string? DiaDiem { get; set; }
        public bool? DuaRaHd { get; set; }

        public virtual Detai MaDtNavigation { get; set; } = null!;
        public virtual Giangvien MaGvNavigation { get; set; } = null!;
        public virtual Hdcham? Hdcham { get; set; }
        public virtual ICollection<Congviec> Congviecs { get; set; }
        public virtual ICollection<Hdgopy> Hdgopies { get; set; }
    }
}
