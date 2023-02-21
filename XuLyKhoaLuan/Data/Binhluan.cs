﻿using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Binhluan
    {
        public int Id { get; set; }
        public DateTime? ThoiGian { get; set; }
        public string? NoiDung { get; set; }
        public string? MaCv { get; set; }
        public string? MaSv { get; set; }
        public string? NamHoc { get; set; }
        public int? Dot { get; set; }

        public virtual Congviec? MaCvNavigation { get; set; }
        public virtual Thamgium? Thamgium { get; set; }
    }
}
