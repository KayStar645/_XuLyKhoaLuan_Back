using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace XuLyKhoaLuan.Models
{
    public class DetaiModel
    {
        public string MaDT { get; set; }

        public string TenDT { get; set; }

        public string TomTat { get; set; }
       
        public int SLMin { get; set; }

        public int SLMax { get; set; }

        public bool TrangThai { get; set; }

    }
}
