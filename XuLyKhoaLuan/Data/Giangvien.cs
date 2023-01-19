using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Giangvien
    {
        public Giangvien()
        {
            Duyetdts = new HashSet<Duyetdt>();
            Huongdans = new HashSet<Huongdan>();
            Nhiemvus = new HashSet<Nhiemvu>();
            Phanbiens = new HashSet<Phanbien>();
            Thamgiahds = new HashSet<Thamgiahd>();
            Truongbms = new HashSet<Truongbm>();
            Truongkhoas = new HashSet<Truongkhoa>();
            Xacnhans = new HashSet<Xacnhan>();
            MaDts = new HashSet<Detai>();
        }

        public string MaGv { get; set; } = null!;
        public string TenGv { get; set; } = null!;
        public DateTime? NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public string? Email { get; set; }
        public string? Sdt { get; set; }
        public string? HocHam { get; set; }
        public string? HocVi { get; set; }
        public DateTime? NgayNhanViec { get; set; }
        public DateTime? NgayNghi { get; set; }
        public string? MaBm { get; set; }

        public virtual Bomon? MaBmNavigation { get; set; }
        public virtual ICollection<Duyetdt> Duyetdts { get; set; }
        public virtual ICollection<Huongdan> Huongdans { get; set; }
        public virtual ICollection<Nhiemvu> Nhiemvus { get; set; }
        public virtual ICollection<Phanbien> Phanbiens { get; set; }
        public virtual ICollection<Thamgiahd> Thamgiahds { get; set; }
        public virtual ICollection<Truongbm> Truongbms { get; set; }
        public virtual ICollection<Truongkhoa> Truongkhoas { get; set; }
        public virtual ICollection<Xacnhan> Xacnhans { get; set; }

        public virtual ICollection<Detai> MaDts { get; set; }
    }
}
