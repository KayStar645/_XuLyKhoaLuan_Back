using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public class PbchamModel
    {
        public string MaGv { get; set; } = null!;
        public string MaDt { get; set; } = null!;
        public string MaSv { get; set; } = null!;
        public string NamHoc { get; set; } = null!;
        public int Dot { get; set; }
        public double? Diem { get; set; }

    }
}
