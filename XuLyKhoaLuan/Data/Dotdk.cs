using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Dotdk
    {
        public Dotdk()
        {
            Thamgia = new HashSet<Thamgium>();
        }

        public string NamHoc { get; set; } = null!;
        public int Dot { get; set; }

        public virtual ICollection<Thamgium> Thamgia { get; set; }
    }
}
