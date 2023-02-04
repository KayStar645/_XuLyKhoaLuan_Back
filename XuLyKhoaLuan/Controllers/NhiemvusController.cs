using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhiemvusController : ControllerBase
    {
        private readonly INhiemvuRepository _NhiemvuRepo;

        public NhiemvusController(INhiemvuRepository repo)
        {
            _NhiemvuRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNhiemvus()
        {
            try
            {
                return Ok(await _NhiemvuRepo.GetAllNhiemvusAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaNV")]
        public async Task<IActionResult> GetNhiemvuByID(int MaNV)
        {
            var Nhiemvu = await _NhiemvuRepo.GetNhiemvuByIDAsync(MaNV);
            return Nhiemvu == null ? BadRequest() : Ok(Nhiemvu);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewNhiemvu(NhiemvuModel model)
        {
            try
            {
                var newNhiemvu = await _NhiemvuRepo.AddNhiemvusAsync(model);
                return CreatedAtAction(nameof(GetNhiemvuByID), new { Controller = "Nhiemvus", newNhiemvu }, newNhiemvu);
                //var Nhiemvu = await _detaiRepo.GetNhiemvuByMaDTsAsync(newNhiemvu);
                //return Nhiemvu == null ? BadRequest() : Ok(Nhiemvu);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaNV")]
        public async Task<IActionResult> UpdateNhiemvu(int MaNV, NhiemvuModel model)
        {

            try
            {
                await _NhiemvuRepo.UpdateNhiemvusAsync(MaNV, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaNV")]
        public async Task<IActionResult> DeleteNhiemvu(int MaNV)
        {
            await _NhiemvuRepo.DeleteNhiemvusAsync(MaNV);
            return Ok();
        }
    }
}
