using Microsoft.Build.Framework;

namespace XuLyKhoaLuan.Models
{
    public class SigInModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
