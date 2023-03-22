using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Models
{
    public  class TruongkhoaModel
    {
        public int MaTk { get; set; }
        public string MaKhoa { get; set; } = null!;
        public string MaGv { get; set; } = null!;
        public DateTime NgayNhanChuc { get; set; }
        public DateTime? NgayNghi { get; set; }

    }
}
