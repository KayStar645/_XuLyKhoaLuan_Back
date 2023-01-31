using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public  class LoimoiModel
    {
        public string MaSv { get; set; } = null!;
        public string NamHoc { get; set; } = null!;
        public int Dot { get; set; }
        public int MaNhom { get; set; }
        public string? LoiNhan { get; set; }
        public DateTime? ThoiGian { get; set; }
        public bool? TrangThai { get; set; }

    }
}
