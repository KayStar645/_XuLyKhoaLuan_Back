using System;
using System.Collections.Generic;

namespace XuLyKhoaLuan.Data
{
    public partial class DetaiChuyennganh
    {
        public string MaCn { get; set; } = null!;
        public string MaDt { get; set; } = null!;
        public int? SoLuong { get; set; }

        public virtual Chuyennganh MaCnNavigation { get; set; } = null!;
        public virtual Detai MaDtNavigation { get; set; } = null!;
    }
}
