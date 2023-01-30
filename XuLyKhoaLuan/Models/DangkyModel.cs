namespace XuLyKhoaLuan.Models
{
    public class DangkyModel
    {
        public int MaNhom { get; set; }
        public string MaDt { get; set; } = null!;
        public DateTime NgayDk { get; set; }
        public DateTime? NgayGiao { get; set; }
        public DateTime? NgayBd { get; set; }
        public DateTime? NgayKt { get; set; }
    }
}
