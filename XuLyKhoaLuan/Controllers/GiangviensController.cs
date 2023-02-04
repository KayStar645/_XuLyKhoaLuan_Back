using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangviensController : ControllerBase
    {
        private readonly IGiangvienRepository _GiangvienRepo;

        public GiangviensController(IGiangvienRepository repo)
        {
            _GiangvienRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGiangviens()
        {
            try
            {
                return Ok(await _GiangvienRepo.GetAllGiangviensAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaGV")]
        public async Task<IActionResult> GetGiangvienByID(string MaGV)
        {
            var Giangvien = await _GiangvienRepo.GetGiangvienByIDAsync(MaGV);
            return Giangvien == null ? BadRequest() : Ok(Giangvien);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewGiangvien(GiangvienModel model)
        {
            try
            {
                var newGiangvien = await _GiangvienRepo.AddGiangviensAsync(model);
                return CreatedAtAction(nameof(GetGiangvienByID), new { Controller = "Giangviens", newGiangvien }, newGiangvien);
                //var Giangvien = await _detaiRepo.GetGiangvienByMaDTsAsync(newGiangvien);
                //return Giangvien == null ? BadRequest() : Ok(Giangvien);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaGV")]
        public async Task<IActionResult> UpdateGiangvien(string MaGV, GiangvienModel model)
        {

            try
            {
                await _GiangvienRepo.UpdateGiangviensAsync(MaGV, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaGV")]
        public async Task<IActionResult> DeleteGiangvien(string MaGV)
        {
            await _GiangvienRepo.DeleteGiangviensAsync(MaGV);
            return Ok();
        }
    }
}
