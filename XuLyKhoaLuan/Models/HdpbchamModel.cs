using System.ComponentModel.DataAnnotations;

namespace XuLyKhoaLuan.Models
{
    public class HdpbchamModel
    {
        [Key]
        public string MaGv { get; set; } = null!;
        [Key]
        public string MaHd { get; set; } = null!;
        [Key]
        public string MaDt { get; set; } = null!;
        [Key]
        public string MaSv { get; set; } = null!;
        [Key]
        public string NamHoc { get; set; } = null!;
        [Key]
        public int Dot { get; set; }
        public double? Diem { get; set; }
        public double? HeSo { get; set; }
    }
}
