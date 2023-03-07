using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Chuyennganh
    {
        public Chuyennganh()
        {
            Sinhviens = new HashSet<Sinhvien>();
            MaDts = new HashSet<Detai>();
        }

        public string MaCn { get; set; } = null!;
        public string? TenCn { get; set; }
        public string? MaKhoa { get; set; }

        public virtual Khoa? MaKhoaNavigation { get; set; }
        public virtual ICollection<Sinhvien> Sinhviens { get; set; }

        public virtual ICollection<Detai> MaDts { get; set; }
    }
}
