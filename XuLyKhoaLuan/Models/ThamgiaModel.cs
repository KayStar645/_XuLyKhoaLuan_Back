using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Models
{
    public  class ThamgiaModel
    {

        public string MaSv { get; set; } = null!;
        public string NamHoc { get; set; } = null!;
        public int Dot { get; set; }
        public string MaNhom { get; set; } = null!;
        public double? DiemTb { get; set; }
        public bool? TruongNhom { get; set; }
    }
}
