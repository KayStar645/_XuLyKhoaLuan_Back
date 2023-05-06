namespace XuLyKhoaLuan.Models.VirtualModel
{
    public class DeTaiDiemVTModel
    {

        public string MaDT { get; set; } = null!;
        public string TenDT { get; set; } = null!;
        public List<SinhVienVTModel> SinhViens { get; set; }
        public List<GiangVienVTModel> GVHDs { get; set; }
        public List<GiangVienVTModel> GVPBs { get; set; }
        public List<GiangVienVTModel> HoiDongs { get; set; }

    }
}
