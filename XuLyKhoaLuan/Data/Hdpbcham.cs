using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Hdpbcham
    {
        public string MaGv { get; set; } = null!;
        public string MaHd { get; set; } = null!;
        public string MaDt { get; set; } = null!;
        public string MaSv { get; set; } = null!;
        public string NamHoc { get; set; } = null!;
        public int Dot { get; set; }
        public double? Diem { get; set; }
        public double? HeSo { get; set; }

        public virtual Hdphanbien Ma { get; set; } = null!;
        public virtual Thamgium Thamgium { get; set; } = null!;
    }
}
