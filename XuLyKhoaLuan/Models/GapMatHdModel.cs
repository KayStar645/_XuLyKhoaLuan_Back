namespace XuLyKhoaLuan.Models
{
    public class GapMatHdModel
    {
        public int Id { get; set; }
        public string MaGv { get; set; } = null!;
        public string MaDt { get; set; } = null!;
        public DateTime? ThoiGianBd { get; set; }
        public DateTime? ThoiGianKt { get; set; }
        public string? DiaDiem { get; set; }
    }
}
