namespace XuLyKhoaLuan.Models.VirtualModel
{
    public class GiangVienVTModel
    {
        public string MaGv { get; set; }
        public string TenGv { get; set; }

        /*
            0: Ra đề
            1: Hướng dẫn
            2: Phản biện
            3: Hội đồng
         */
        public int VaiTro { get; set; }
        /*
            C: Chủ tịch
            T: Thư ký
            U: Ủy viên
         */
        public string MaChucVu { get; set; }
        public string? ChucVu { get; set; }
        public int duaRaHoiDong { get; set; }
    }
}
