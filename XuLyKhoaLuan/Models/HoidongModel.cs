using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Models
{
    public  class HoidongModel
    {

        public string MaHd { get; set; } = null!;
        public string TenHd { get; set; } = null!;
        public DateTime? NgayLap { get; set; }
        public DateTime? ThoiGianBd { get; set; }
        public DateTime? ThoiGianKt { get; set; }
        public string? DiaDiem { get; set; }
        public string? MaBm { get; set; }

    }
}
