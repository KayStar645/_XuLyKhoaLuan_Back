using System.ComponentModel.DataAnnotations;

namespace XuLyKhoaLuan.Models
{
    public class HdchamModel
    {
        [Key]
        public string MaGv { get; set; } = null!;
        [Key]
        public string MaDt { get; set; } = null!;
        public string MaSv { get; set; } = null!;
        public string NamHoc { get; set; } = null!;
        public int Dot { get; set; }
        public double? Diem { get; set; }
        public double? HeSo { get; set; }
    }
}
