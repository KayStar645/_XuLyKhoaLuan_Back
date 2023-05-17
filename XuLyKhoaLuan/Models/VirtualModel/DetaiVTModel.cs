namespace XuLyKhoaLuan.Models.VirtualModel
{
    public class DetaiVTModel
    {
        public string MaDT { get; set; } = null!;

        public string TenDT { get; set; } = null!;

        public string TomTat { get; set; } = null!;

        public int? SLMin { get; set; }

        public int? SLMax { get; set; }

        public bool? TrangThai { get; set; }
        public string? NamHoc { get; set; }
        public int? Dot { get; set; }
        public int duyetDT { get; set; } // -1: Chưa duyệt; 0: Chưa đạt; 1: Đạt
        public DateTime? ngayDuyet { get; set; }

        // Thêm nè
        public List<string> CnPhuHop { get; set; } = null!;
        public List<string> GVRD { get; set; } = null!;
        public List<string> GVHD { get; set; } = null!;
        public List<string> GVPB { get; set; } = null!;
    }
}
