namespace XuLyKhoaLuan.Models.VirtualModel
{
    public class DiemSVVTModel
    {
        public string maSv { get; set; } = null!;
        public string namHoc { get; set; } = null!;
        public int dot { get; set; }
        public string tenSv { set;get; } = null!;
        public string lop { get; set; } = null!;
        public string maCn { get; set; } = null!;
        public string chuyenNganh { get; set; } = null!;
        public double diemHd { get; set; }
        public double diemPb { get; set; }
        public double diemHdpb { get; set; }
        public double diemTb { get; set; }
    }
}
