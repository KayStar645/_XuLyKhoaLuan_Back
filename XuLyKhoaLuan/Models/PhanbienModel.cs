using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Models
{
    public  class PhanbienModel
    {
        public string MaGv { get; set; } = null!;
        public string MaDt { get; set; } = null!;
        public DateTime ThoiGianBD { get; set; }
        public DateTime ThoiGianKT { get; set; }
        public string DiaDiem { get; set; }
        public bool? DuaRaHd { get; set; }

    }
}
