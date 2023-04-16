using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Hoidong
    {
        public Hoidong()
        {
            Thamgiahds = new HashSet<Thamgiahd>();
        }

        public string MaHd { get; set; } = null!;
        public string TenHd { get; set; } = null!;
        public DateTime? NgayLap { get; set; }
        public DateTime? ThoiGianBd { get; set; }
        public DateTime? ThoiGianKt { get; set; }
        public string? DiaDiem { get; set; }
        public string? MaBm { get; set; }

        public virtual Bomon? MaBmNavigation { get; set; }
        public virtual ICollection<Thamgiahd> Thamgiahds { get; set; }
    }
}
