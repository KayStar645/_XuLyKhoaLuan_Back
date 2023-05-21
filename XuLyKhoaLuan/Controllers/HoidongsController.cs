using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoidongsController : ControllerBase
    {
        private readonly IHoidongRepository _HoidongRepo;

        public HoidongsController(IHoidongRepository repo)
        {
            _HoidongRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHoidongs()
        {
            try
            {
                return Ok(await _HoidongRepo.GetAllHoidongsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaHD")]
        public async Task<IActionResult> GetHoidongByID(string MaHD)
        {
            var Hoidong = await _HoidongRepo.GetHoidongByIDAsync(MaHD);
            return Hoidong == null ? BadRequest() : Ok(Hoidong);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddNewHoidong(HoidongModel model)
        //{
        //    var newHoidong = await _HoidongRepo.AddHoidongsAsync(model);
        //    return Ok(model);
        //}

        [HttpPost]
        public async Task<IActionResult> ThanhLapHoiDongAsync(HoiDongVT hoiDongVT)
        {
            try
            {
                await _HoidongRepo.ThanhLapHoiDongAsync(hoiDongVT);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaHD")]
        public async Task<IActionResult> UpdateHoidong(string MaHD, HoidongModel model)
        {

            try
            {
                await _HoidongRepo.UpdateHoidongsAsync(MaHD, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut()]
        public async Task<IActionResult> CapNhatHoiDongAsync(HoiDongVT hoiDongVT)
        {
            try
            {
                await _HoidongRepo.CapNhatHoiDongAsync(hoiDongVT);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaHD")]
        public async Task<IActionResult> DeleteHoidong(string MaHD)
        {
            await _HoidongRepo.DeleteHoidongsAsync(MaHD);
            return Ok();
        }

        [HttpGet("maBm")]
        public async Task<IActionResult> GetHoidongsByBomonAsync(string maBm)
        {
            try
            {
                return Ok(await _HoidongRepo.GetHoidongsByBomonAsync(maBm));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maGv")]
        public async Task<IActionResult> GetHoidongsByGiangvienAsync(string maGv)
        {
            try
            {
                return Ok(await _HoidongRepo.GetHoidongsByGiangvienAsync(maGv));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
