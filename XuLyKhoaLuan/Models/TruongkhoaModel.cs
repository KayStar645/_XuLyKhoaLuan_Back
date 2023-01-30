using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public  class TruongkhoaModel
    {
        public string MaKhoa { get; set; } = null!;
        public string MaGv { get; set; } = null!;
        public DateTime NgayNhanChuc { get; set; }
        public DateTime? NgayNghi { get; set; }

    }
}
