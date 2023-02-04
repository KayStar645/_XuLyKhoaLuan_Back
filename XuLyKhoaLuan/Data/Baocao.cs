using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Baocao
    {
        public Baocao() { 
        
        }

        public string MaCv { get; set; } = null!;
        public string MaSv { get; set; } = null!;
        public string NamHoc { get; set; } = null!;
        public int Dot { get; set; }
        public int LanNop { get; set; }
        public DateTime? ThoiGianNop { get; set; }
        public string? FileBc { get; set; }

        public virtual Congviec MaCvNavigation { get; set; } = null!;
        public virtual Thamgia Thamgia { get; set; } = null!;
    }
}
