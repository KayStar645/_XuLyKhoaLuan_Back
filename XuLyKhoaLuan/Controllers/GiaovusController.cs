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
        private readonly IAccountRepository accountRepo;
        public GiaovusController(IGiaovuRepository repo, IAccountRepository repoAccount)
        {
            _GiaovuRepo = repo;
            accountRepo = repoAccount;
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
                var user = new SigUpModel
                {
                    Id = model.MaGv,
                    Password = model.MaGv

                };
                await accountRepo.SigUpAsync(user);
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
            await accountRepo.DeleteAsync(MaGV);
            return Ok();
        }
    }
}
