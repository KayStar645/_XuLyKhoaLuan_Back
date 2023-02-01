using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Models
{
    public class NhomModel
    {
        public int MaNhom { get; set; }
        public string TenNhom { get; set; } = null!;
        public int? SoLuong { get; set; }
        public int? Slmax { get; set; }
        public string TruongNhom { get; set; } = null!;

    }
}
