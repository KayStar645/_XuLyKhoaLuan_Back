using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Pbnhanxet
    {
        public int Id { get; set; }
        public DateTime? ThoiGian { get; set; }
        public string? NoiDung { get; set; }
        public string? MaGv { get; set; }
        public string? MaDt { get; set; }

        public virtual Phanbien? Ma { get; set; }
    }
}
