using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Vaitro
    {
        public Vaitro()
        {
            Thamgiahds = new HashSet<Thamgiahd>();
        }

        public string MaVt { get; set; } = null!;
        public string? TenVaiTro { get; set; }

        public virtual ICollection<Thamgiahd> Thamgiahds { get; set; }
    }
}
