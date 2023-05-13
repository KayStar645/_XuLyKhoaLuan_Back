using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface.NghiepVu;
using XuLyKhoaLuan.Interface.TraoDoi;
using XuLyKhoaLuan.Models;
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

        [HttpGet("maSv")]
        public async Task<IActionResult> GetLichPhanBienBySvAsync(string maSv)
        {
            try
            {
                return Ok(await _LichphanbienRepo.GetLichPhanBienBySvAsync(maSv));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maGv,namHoc,dot,loaiLich")]
        public async Task<IActionResult> GetSelectDetaiByGiangVienAsync(string maGv, string namHoc, int dot, int loaiLich)
        {
            try
            {
                return Ok(await _LichphanbienRepo.GetSelectDetaiByGiangVienAsync(maGv, namHoc, dot, loaiLich));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
