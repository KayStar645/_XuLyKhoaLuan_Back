using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XuLyKhoaLuan.Models
{
    public  class LoimoiModel
    {
        [Key]
        public string MaSv { get; set; } = null!;
        [Key]
        public string NamHoc { get; set; } = null!;
        [Key]
        public int Dot { get; set; }
        [Key]
        public int MaNhom { get; set; }
        public string? LoiNhan { get; set; }
        public DateTime? ThoiGian { get; set; }
        public bool? TrangThai { get; set; }

    }
}
