using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Detai
    {
        public Detai()
        {
            Dangkies = new HashSet<Dangky>();
            Duyetdts = new HashSet<Duyetdt>();
            Hdphanbiens = new HashSet<Hdphanbien>();
            Huongdans = new HashSet<Huongdan>();
            Phanbiens = new HashSet<Phanbien>();
            Xacnhans = new HashSet<Xacnhan>();
            MaCns = new HashSet<Chuyennganh>();
            MaGvs = new HashSet<Giangvien>();
        }

        public string MaDt { get; set; } = null!;
        public string TenDt { get; set; } = null!;
        public string? TomTat { get; set; }
        public int? Slmin { get; set; }
        public int? Slmax { get; set; }
        public bool? TrangThai { get; set; }

        public virtual ICollection<Dangky> Dangkies { get; set; }
        public virtual ICollection<Duyetdt> Duyetdts { get; set; }
        public virtual ICollection<Hdphanbien> Hdphanbiens { get; set; }
        public virtual ICollection<Huongdan> Huongdans { get; set; }
        public virtual ICollection<Phanbien> Phanbiens { get; set; }
        public virtual ICollection<Xacnhan> Xacnhans { get; set; }

        public virtual ICollection<Chuyennganh> MaCns { get; set; }
        public virtual ICollection<Giangvien> MaGvs { get; set; }
    }
}
