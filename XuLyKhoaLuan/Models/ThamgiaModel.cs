using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Models
{
    public  class ThamgiaModel
    {

        public string MaSv { get; set; } = null!;
        public string NamHoc { get; set; } = null!;
        public int Dot { get; set; }
        public int? MaNhom { get; set; }
        public double? DiemTb { get; set; }
    }
}
