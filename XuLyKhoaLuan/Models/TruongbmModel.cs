using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Models
{
    public  class TruongbmModel
    {
        public string MaBm { get; set; } = null!;
        public string MaGv { get; set; } = null!;
        public DateTime? NgayNhanChuc { get; set; }
        public DateTime? NgayNghi { get; set; }

    }
}
