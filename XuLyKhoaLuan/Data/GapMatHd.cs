using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class GapMatHd
    {
        public int Id { get; set; }
        public string MaGv { get; set; } = null!;
        public string MaDt { get; set; } = null!;
        public DateTime? ThoiGianBd { get; set; }
        public DateTime? ThoiGianKt { get; set; }
        public string? DiaDiem { get; set; }
    }
}
