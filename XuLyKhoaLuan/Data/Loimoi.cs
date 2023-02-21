using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Loimoi
    {
        public string MaSv { get; set; } = null!;
        public string NamHoc { get; set; } = null!;
        public int Dot { get; set; }
        public int MaNhom { get; set; }
        public string? LoiNhan { get; set; }
        public DateTime? ThoiGian { get; set; }
        public bool? TrangThai { get; set; }

        public virtual Nhom MaNhomNavigation { get; set; } = null!;
        public virtual Thamgium Thamgium { get; set; } = null!;
    }
}
