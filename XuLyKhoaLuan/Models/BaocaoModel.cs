using System.ComponentModel.DataAnnotations;

namespace XuLyKhoaLuan.Models
{
    public class BaocaoModel
    {
        [Key]
        public string MaCv { get; set; } = null!;
        public string MaSv { get; set; } = null!;


        public string NamHoc { get; set; } = null!;


        public int Dot { get; set; }
        public int LanNop { get; set; }
        public DateTime? ThoiGianNop { get; set; }
        public string? FileBc { get; set; }

    }
}
