using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Khoa
    {
        public Khoa()
        {
            Bomons = new HashSet<Bomon>();
            Chuyennganhs = new HashSet<Chuyennganh>();
            Giaovus = new HashSet<Giaovu>();
            Kehoaches = new HashSet<Kehoach>();
            Thongbaos = new HashSet<Thongbao>();
            Truongkhoas = new HashSet<Truongkhoa>();
        }

        public string MaKhoa { get; set; } = null!;
        public string TenKhoa { get; set; } = null!;
        public string? Sdt { get; set; }
        public string? Email { get; set; }
        public string? Phong { get; set; }

        public virtual ICollection<Bomon> Bomons { get; set; }
        public virtual ICollection<Chuyennganh> Chuyennganhs { get; set; }
        public virtual ICollection<Giaovu> Giaovus { get; set; }
        public virtual ICollection<Kehoach> Kehoaches { get; set; }
        public virtual ICollection<Thongbao> Thongbaos { get; set; }
        public virtual ICollection<Truongkhoa> Truongkhoas { get; set; }
    }
}
