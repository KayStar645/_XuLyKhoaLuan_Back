using System.ComponentModel.DataAnnotations;

namespace XuLyKhoaLuan.Models
{
    public class HdpbnhanxetModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime? ThoiGian { get; set; }
        public string? NoiDung { get; set; }
        public string? MaGv { get; set; }
        public string? MaHd { get; set; }
        public string? MaDt { get; set; }
    }
}
