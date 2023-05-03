namespace XuLyKhoaLuan.Models.VirtualModel
{
    public class DetaiVTModel
    {
        private string ma;
        private string ten;
        private int? min;
        private int? max;
        private bool? trangThai;
        private string nam;

        public string MaDT { get; set; } = null!;

        public string TenDT { get; set; } = null!;

        public string TomTat { get; set; } = null!;

        public int? SLMin { get; set; }

        public int? SLMax { get; set; }

        public bool TrangThai { get; set; }
        public string? NamHoc { get; set; }
        public int? Dot { get; set; }

        // Thêm nè
        public List<string> CnPhuHop { get; set; } = null!;
        public List<string> GVRD { get; set; } = null!;
        public List<string> GVHD { get; set; } = null!;
        public List<string> GVPB { get; set; } = null!;


        public DetaiVTModel() { }

        public DetaiVTModel(string maDt, string tenDt, string tomTat, int min, int max, bool trangThai, string namHoc, int dot) 
        {
            this.MaDT = maDt;
            this.TenDT = tenDt;
            this.TomTat = tomTat;
            this.SLMin = min;
            this.SLMax = max;
            this.TrangThai = trangThai;
            this.NamHoc = namHoc;
            this.Dot = dot;
        }

        public DetaiVTModel(string ma, string ten, string tomtat, int? min, int? max, bool? trangThai, string nam, int? dot)
        {
            this.ma = ma;
            this.ten = ten;
            this.TomTat = tomtat;
            this.min = min;
            this.max = max;
            this.trangThai = trangThai;
            this.nam = nam;
            this.Dot = dot;
        }
    }
}
