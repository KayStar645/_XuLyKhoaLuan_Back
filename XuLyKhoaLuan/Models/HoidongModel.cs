using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public  class HoidongModel
    {

        public string MaHd { get; set; } = null!;
        public string TenHd { get; set; } = null!;
        public DateTime? NgayLap { get; set; }
        public DateTime? NgayBaoVe { get; set; }
        public string? DiaDiem { get; set; }
        public string? MaBm { get; set; }

    }
}
