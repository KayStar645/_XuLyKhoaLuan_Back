using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface.NghiepVu;
using XuLyKhoaLuan.Interface.TraoDoi;
using XuLyKhoaLuan.Models.VirtualModel;
using XuLyKhoaLuan.Repositories.BinhLuan;

namespace XuLyKhoaLuan.Controllers.NghiepVu
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichPhanBienController : ControllerBase
    {
        private readonly ILichPhanBienRepo _LichphanbienRepo;

        public LichPhanBienController(ILichPhanBienRepo repo)
        {
            this._LichphanbienRepo = repo;
        }

        [HttpGet("maGv")]
        public async Task<IActionResult> GetLichPhanBienByGvAsync(string maGv)
        {
            try
            {
                return Ok(await _LichphanbienRepo.GetLichPhanBienByGvAsync(maGv));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
