using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinhluansController : ControllerBase
    {
        private readonly IBinhluanRepository _BinhluanRepo;

        public BinhluansController(IBinhluanRepository repo)
        {
            _BinhluanRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBinhluans()
        {
            try
            {
                return Ok(await _BinhluanRepo.GetAllBinhluansAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maBL")]
        public async Task<IActionResult> GetBinhluanByMaBL(int maBL)
        {
            var Binhluan = await _BinhluanRepo.GetBinhluanByIDAsync(maBL);
            return Binhluan == null ? BadRequest() : Ok(Binhluan);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBinhluan(BinhluanModel model)
        {
            try
            {
                var newBinhluan = await _BinhluanRepo.AddBinhluansAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("maBL")]
        public async Task<IActionResult> UpdateBinhluan(int maBL, BinhluanModel model)
        {

            try
            {
                await _BinhluanRepo.UpdateBinhluansAsync(maBL, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("maBL")]
        public async Task<IActionResult> DeleteBinhluan(int maBL)
        {
            await _BinhluanRepo.DeleteBinhluansAsync(maBL);
            return Ok();
        }
    }
}
