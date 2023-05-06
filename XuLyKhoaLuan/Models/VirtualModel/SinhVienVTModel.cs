namespace XuLyKhoaLuan.Models.VirtualModel
{
    public class SinhVienVTModel
    {
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public string Lop { get; set; }
        public string NamHoc { get; set; }
        public int Dot { get; set; }
        public List<DiemSoVTModel> Diems { get; set; }
    }
}
