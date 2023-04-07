using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KehoachesController : ControllerBase
    {
        private readonly IKehoachRepository _KehoachRepo;

        public KehoachesController(IKehoachRepository repo)
        {
            _KehoachRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKehoaches()
        {
            try
            {
                return Ok(await _KehoachRepo.GetAllKehoachesAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaKH")]
        public async Task<IActionResult> GetKehoachByID(int MaKH)
        {
            var Kehoach = await _KehoachRepo.GetKehoachByIDAsync(MaKH);
            return Kehoach == null ? BadRequest() : Ok(Kehoach);
        }

        [HttpGet("maKhoa")]
        public async Task<IActionResult> GetKehoachesByMakhoaAsync(string maKhoa)
        {
            try
            {
                return Ok(await _KehoachRepo.GetKehoachesByMakhoaAsync(maKhoa));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maBM")]
        public async Task<IActionResult> GetKehoachesByMabmAsync(string maBM)
        {
            try
            {
                return Ok(await _KehoachRepo.GetKehoachesByMabmAsync(maBM));
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddNewKehoach(KehoachModel model)
        {
            try
            {
                var newKehoach = await _KehoachRepo.AddKehoachesAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaKH")]
        public async Task<IActionResult> UpdateKehoach(int MaKH, KehoachModel model)
        {

            try
            {
                await _KehoachRepo.UpdateKehoachesAsync(MaKH, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaKH")]
        public async Task<IActionResult> DeleteKehoach(int MaKH)
        {
            await _KehoachRepo.DeleteKehoachesAsync(MaKH);
            return Ok();
        }
    }
}
