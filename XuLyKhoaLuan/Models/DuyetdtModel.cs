namespace XuLyKhoaLuan.Models
{
    public class DuyetdtModel
    {
        public string MaGv { get; set; } = null!;
        public string MaDt { get; set; } = null!;
        public int LanDuyet { get; set; }
        public DateTime NgayDuyet { get; set; }
        public string? NhanXet { get; set; }
    }
}
