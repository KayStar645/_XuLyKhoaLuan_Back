namespace XuLyKhoaLuan.Models.VirtualModel
{
    public class LichPhanBienVTModel
    {
        public string MaDt { get; set; } = null!;
        public List<GiangVienVTModel> giangViens { get; set; }
        public string TenDeTai { get; set; } = null!;
        public DateTime ThoiGianBD { get; set; }
        public DateTime ThoiGianKT { get; set; }

        public string DiaDiem { get; set; } = null!;


        /*
            0: Hàng tuần
            1: Hướng dẫn
            2: Phản biện
            3: Hội đồng
         */
        public int LoaiLich { get; set; }
    }
}
