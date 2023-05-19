namespace XuLyKhoaLuan.Models.VirtualModel
{
    public class DetaiVTModel
    {
        public string MaBm { get; set; } = null!;
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
        public List<ChuyennganhModel> CnPhuHop { get; set; } = null!;
        public List<GiangVienVTModel> GVRD { get; set; } = null!;
        public List<GiangVienVTModel> GVHD { get; set; } = null!;
        public List<GiangVienVTModel> GVPB { get; set; } = null!;
    }
}
