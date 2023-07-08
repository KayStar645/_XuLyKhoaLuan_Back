using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace XuLyKhoaLuan.Models
{
    public class DetaiModel
    {
        public string MaDT { get; set; } = null!;

        public string? TenDT { get; set; } = null!;

        public string? TomTat { get; set; } = null!;

        public int? SLMin { get; set; }

        public int? SLMax { get; set; }

        public bool? TrangThai { get; set; }
        public string? NamHoc { get; set; }
        public int? Dot { get; set; }
        public bool isDangKy { get; set; }
        public string noteDangKy { get; set; }

    }
}
