namespace XuLyKhoaLuan.Models
{
    public class GiangvienModel
    {
        public string MaGv { get; set; } = null!;
        public string TenGv { get; set; } = null!;
        public DateTime? NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public string? Email { get; set; }
        public string? Sdt { get; set; }
        public string? HocHam { get; set; }
        public string? HocVi { get; set; }
        public DateTime? NgayNhanViec { get; set; }
        public DateTime? NgayNghi { get; set; }
        public string? MaBm { get; set; }
        public List<int> slnv { get; set; }

    }
}
