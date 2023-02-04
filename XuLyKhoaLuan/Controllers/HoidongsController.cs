using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

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

        [HttpPost]
        public async Task<IActionResult> AddNewHoidong(HoidongModel model)
        {
            try
            {
                var newHoidong = await _HoidongRepo.AddHoidongsAsync(model);
                return CreatedAtAction(nameof(GetHoidongByID), new { Controller = "Hoidongs", newHoidong }, newHoidong);
                //var Hoidong = await _detaiRepo.GetHoidongByMaDTsAsync(newHoidong);
                //return Hoidong == null ? BadRequest() : Ok(Hoidong);
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

        [HttpDelete("MaHD")]
        public async Task<IActionResult> DeleteHoidong(string MaHD)
        {
            await _HoidongRepo.DeleteHoidongsAsync(MaHD);
            return Ok();
        }
    }
}
