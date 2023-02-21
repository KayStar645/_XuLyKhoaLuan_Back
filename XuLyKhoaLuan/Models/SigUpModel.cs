using System.ComponentModel.DataAnnotations;

namespace XuLyKhoaLuan.Models
{
    public class SigUpModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
