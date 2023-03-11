using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Chuyennganh
    {
        public Chuyennganh()
        {
            DetaiChuyennganhs = new HashSet<DetaiChuyennganh>();
            Sinhviens = new HashSet<Sinhvien>();
        }

        public string MaCn { get; set; } = null!;
        public string TenCn { get; set; } = null!;
        public string? MaKhoa { get; set; }

        public virtual Khoa? MaKhoaNavigation { get; set; }
        public virtual ICollection<DetaiChuyennganh> DetaiChuyennganhs { get; set; }
        public virtual ICollection<Sinhvien> Sinhviens { get; set; }
    }
}
