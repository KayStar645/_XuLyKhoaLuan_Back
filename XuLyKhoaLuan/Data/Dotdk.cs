using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Dotdk
    {
        public Dotdk()
        {
            Detais = new HashSet<Detai>();
            Thamgia = new HashSet<Thamgium>();
        }

        public string NamHoc { get; set; } = null!;
        public int Dot { get; set; }
        public DateTime? NgayBd { get; set; }
        public DateTime? NgayKt { get; set; }
        public DateTime? Tgbddk { get; set; }
        public DateTime? Tgktdk { get; set; }

        public virtual ICollection<Detai> Detais { get; set; }
        public virtual ICollection<Thamgium> Thamgia { get; set; }
    }
}
