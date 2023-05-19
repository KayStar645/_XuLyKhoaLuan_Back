namespace XuLyKhoaLuan.Models.VirtualModel
{
    public class GiangVienVTModel
    {
        public string MaGV { get; set; }
        public string TenGV { get; set; }

        /*
            0: Ra đề
            1: Hướng dẫn
            2: Phản biện
            3: Hội đồng
         */
        public int VaiTro { get; set; }

        public string? ChucVu { get; set; }
        public int duaRaHoiDong { get; set; }
    }
}
