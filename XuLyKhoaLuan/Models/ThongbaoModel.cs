﻿using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Models
{
    public  class ThongbaoModel
    {
        public int MaTb { get; set; }
        public string TenTb { get; set; } = null!;
        public string? MoTa { get; set; }
        public string? NoiDung { get; set; }
        public string? HinhAnh { get; set; }
        public string? FileTb { get; set; }
        public string? MaKhoa { get; set; }

    }
}