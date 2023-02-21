using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Thamgium
    {
        public Thamgium()
        {
            Baocaos = new HashSet<Baocao>();
            Binhluans = new HashSet<Binhluan>();
            Hdchams = new HashSet<Hdcham>();
            Hdpbchams = new HashSet<Hdpbcham>();
            Loimois = new HashSet<Loimoi>();
            Pbchams = new HashSet<Pbcham>();
        }

        public string MaSv { get; set; } = null!;
        public string NamHoc { get; set; } = null!;
        public int Dot { get; set; }
        public int? MaNhom { get; set; }
        public double? DiemTb { get; set; }

        public virtual Dotdk Dotdk { get; set; } = null!;
        public virtual Sinhvien MaSvNavigation { get; set; } = null!;
        public virtual ICollection<Baocao> Baocaos { get; set; }
        public virtual ICollection<Binhluan> Binhluans { get; set; }
        public virtual ICollection<Hdcham> Hdchams { get; set; }
        public virtual ICollection<Hdpbcham> Hdpbchams { get; set; }
        public virtual ICollection<Loimoi> Loimois { get; set; }
        public virtual ICollection<Pbcham> Pbchams { get; set; }
    }
}
