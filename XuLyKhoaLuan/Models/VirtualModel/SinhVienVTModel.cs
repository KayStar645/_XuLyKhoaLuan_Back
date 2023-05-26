namespace XuLyKhoaLuan.Models.VirtualModel
{
    public class SinhVienVTModel
    {
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public string Lop { get; set; }
        public string NamHoc { get; set; }
        public int Dot { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public string MaCN { get; set; }
        public string ChuyenNganh { get; set; }
        public List<DiemSoVTModel> Diems { get; set; }
    }
}
