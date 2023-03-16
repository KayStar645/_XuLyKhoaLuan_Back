using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Congviec
    {
        public Congviec()
        {
            Baocaos = new HashSet<Baocao>();
            Binhluans = new HashSet<Binhluan>();
            Hdgopies = new HashSet<Hdgopy>();
        }

        public string MaCv { get; set; } = null!;
        public string? TenCv { get; set; }
        public string? YeuCau { get; set; }
        public string? MoTa { get; set; }
        public DateTime? HanChot { get; set; }
        public double? MucDoHoanThanh { get; set; }
        public string? MaGv { get; set; }
        public string? MaDt { get; set; }
        public string? MaNhom { get; set; }

        public virtual Huongdan? Ma { get; set; }
        public virtual Nhom? MaNhomNavigation { get; set; }
        public virtual ICollection<Baocao> Baocaos { get; set; }
        public virtual ICollection<Binhluan> Binhluans { get; set; }
        public virtual ICollection<Hdgopy> Hdgopies { get; set; }
    }
}
