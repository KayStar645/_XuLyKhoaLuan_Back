using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiaovusController : ControllerBase
    {
        private readonly IGiaovuRepository _GiaovuRepo;

        public GiaovusController(IGiaovuRepository repo)
        {
            _GiaovuRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGiaovus()
        {
            try
            {
                return Ok(await _GiaovuRepo.GetAllGiaovusAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaGV")]
        public async Task<IActionResult> GetGiaovuByID(string MaGV)
        {
            var Giaovu = await _GiaovuRepo.GetGiaovuByIDAsync(MaGV);
            return Giaovu == null ? BadRequest() : Ok(Giaovu);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewGiaovu(GiaovuModel model)
        {
            try
            {
                var newGiaovu = await _GiaovuRepo.AddGiaovusAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaGV")]
        public async Task<IActionResult> UpdateGiaovu(string MaGV, GiaovuModel model)
        {

            try
            {
                await _GiaovuRepo.UpdateGiaovusAsync(MaGV, model);
                return Ok(/*await _GiaovuRepo.GetGiaovuByIDAsync(MaGV)*/);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaGV")]
        public async Task<IActionResult> DeleteGiaovu(string MaGV)
        {
            await _GiaovuRepo.DeleteGiaovusAsync(MaGV);
            return Ok();
        }
    }
}
