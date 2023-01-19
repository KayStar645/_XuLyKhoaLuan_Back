using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class Thamgiahd
    {
        public Thamgiahd()
        {
            Hdphanbiens = new HashSet<Hdphanbien>();
        }

        public string MaHd { get; set; } = null!;
        public string MaGv { get; set; } = null!;
        public string MaVt { get; set; } = null!;

        public virtual Giangvien MaGvNavigation { get; set; } = null!;
        public virtual Hoidong MaHdNavigation { get; set; } = null!;
        public virtual Vaitro MaVtNavigation { get; set; } = null!;
        public virtual ICollection<Hdphanbien> Hdphanbiens { get; set; }
    }
}
