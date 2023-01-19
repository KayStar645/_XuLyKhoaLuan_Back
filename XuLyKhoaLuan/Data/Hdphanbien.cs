using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Hdphanbien
    {
        public Hdphanbien()
        {
            Hdpbchams = new HashSet<Hdpbcham>();
            Hdpbnhanxets = new HashSet<Hdpbnhanxet>();
        }

        public string MaGv { get; set; } = null!;
        public string MaHd { get; set; } = null!;
        public string MaDt { get; set; } = null!;
        public double? Diem { get; set; }

        public virtual Thamgiahd Ma { get; set; } = null!;
        public virtual Detai MaDtNavigation { get; set; } = null!;
        public virtual ICollection<Hdpbcham> Hdpbchams { get; set; }
        public virtual ICollection<Hdpbnhanxet> Hdpbnhanxets { get; set; }
    }
}
