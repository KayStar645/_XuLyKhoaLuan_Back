using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Nhom
    {
        public Nhom()
        {
            Congviecs = new HashSet<Congviec>();
            Dangkies = new HashSet<Dangky>();
            Loimois = new HashSet<Loimoi>();
        }

        public string MaNhom { get; set; } = null!;
        public string TenNhom { get; set; } = null!;

        public virtual ICollection<Congviec> Congviecs { get; set; }
        public virtual ICollection<Dangky> Dangkies { get; set; }
        public virtual ICollection<Loimoi> Loimois { get; set; }
    }
}
