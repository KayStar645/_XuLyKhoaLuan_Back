using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Phanbien
    {
        public Phanbien()
        {
            Pbchams = new HashSet<Pbcham>();
            Pbnhanxets = new HashSet<Pbnhanxet>();
        }

        public string MaGv { get; set; } = null!;
        public string MaDt { get; set; } = null!;
        public DateTime? ThoiGianBd { get; set; }
        public DateTime? ThoiGianKt { get; set; }
        public string? DiaDiem { get; set; }
        public bool? DuaRaHd { get; set; }

        public virtual Detai MaDtNavigation { get; set; } = null!;
        public virtual Giangvien MaGvNavigation { get; set; } = null!;
        public virtual ICollection<Pbcham> Pbchams { get; set; }
        public virtual ICollection<Pbnhanxet> Pbnhanxets { get; set; }
    }
}
