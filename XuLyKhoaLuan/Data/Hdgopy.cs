using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Hdgopy
    {
        public int Id { get; set; }
        public DateTime? ThoiGian { get; set; }
        public string? NoiDung { get; set; }
        public string? MaCv { get; set; }
        public string? MaGv { get; set; }
        public string? MaDt { get; set; }

        public virtual Huongdan? Ma { get; set; }
        public virtual Congviec? MaCvNavigation { get; set; }
    }
}
