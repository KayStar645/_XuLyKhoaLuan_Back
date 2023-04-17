using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Models
{
    public  class HuongdanModel
    {

        public string MaGv { get; set; } = null!;
        public string MaDt { get; set; } = null!;
        public DateTime? ThoiGianBd { get; set; }
        public DateTime? ThoiGianKt { get; set; }
        public string? DiaDiem { get; set; }
        public bool? DuaRaHd { get; set; }

    }
}
