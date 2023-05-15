namespace XuLyKhoaLuan.Models.VirtualModel
{
    public class GiangVienDtVTModel
    {
        public string maDt { get; set; }
        public string tenDt { get; set; }
        public List<GiangVienVTModel> gvhds { get; set; }
        public List<GiangVienVTModel> gvpbs { get; set; }
    }
}
