using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Sinhvien
    {
        public Sinhvien()
        {
            Thamgia = new HashSet<Thamgium>();
        }

        public string MaSv { get; set; } = null!;
        public string TenSv { get; set; } = null!;
        public DateTime? NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public string? Lop { get; set; }
        public string? Sdt { get; set; }
        public string? Email { get; set; }
        public string? MaCn { get; set; }

        public virtual Chuyennganh? MaCnNavigation { get; set; }
        public virtual ICollection<Thamgium> Thamgia { get; set; }
    }
}
