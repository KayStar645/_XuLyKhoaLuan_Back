using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Bomon
    {
        public Bomon()
        {
            Giangviens = new HashSet<Giangvien>();
            Hoidongs = new HashSet<Hoidong>();
            Kehoaches = new HashSet<Kehoach>();
            Nhiemvus = new HashSet<Nhiemvu>();
            Truongbms = new HashSet<Truongbm>();
        }

        public string MaBm { get; set; } = null!;
        public string TenBm { get; set; } = null!;
        public string? Sdt { get; set; }
        public string? Email { get; set; }
        public string? MaKhoa { get; set; }

        public virtual Khoa? MaKhoaNavigation { get; set; }
        public virtual ICollection<Giangvien> Giangviens { get; set; }
        public virtual ICollection<Hoidong> Hoidongs { get; set; }
        public virtual ICollection<Kehoach> Kehoaches { get; set; }
        public virtual ICollection<Nhiemvu> Nhiemvus { get; set; }
        public virtual ICollection<Truongbm> Truongbms { get; set; }
    }
}
