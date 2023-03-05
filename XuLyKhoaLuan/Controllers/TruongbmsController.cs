using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruongbmsController : ControllerBase
    {
        private readonly ITruongbmRepository _TruongbmRepo;

        public TruongbmsController(ITruongbmRepository repo)
        {
            _TruongbmRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTruongbms()
        {
            try
            {
                return Ok(await _TruongbmRepo.GetAllTruongbmsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaGV, MaBM")]
        public async Task<IActionResult> GetTruongbmByMaCN(string MaGV, string MaBM)
        {
            TruongbmModel truongBM = new()
            {
                MaGv = MaGV,
                MaBm = MaBM
            };
            var Truongbm = await _TruongbmRepo.GetTruongbmByIDAsync(truongBM);
            return Truongbm == null ? BadRequest() : Ok(Truongbm);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTruongbm(TruongbmModel model)
        {
            try
            {
                var newTruongbm = await _TruongbmRepo.AddTruongbmsAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaGV, MaBM")]
        public async Task<IActionResult> UpdateTruongbm(string MaGV, string MaBM, TruongbmModel model)
        {

            try
            {
                TruongbmModel truongBM = new()
                {
                    MaGv = MaGV,
                    MaBm = MaBM
                };
                await _TruongbmRepo.UpdateTruongbmsAsync(truongBM, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaGV, MaBM")]
        public async Task<IActionResult> DeleteTruongbm(string MaGV, string MaBM)
        {
            TruongbmModel truongBM = new()
            {
                MaGv = MaGV,
                MaBm = MaBM
            };
            await _TruongbmRepo.DeleteTruongbmsAsync(truongBM);
            return Ok();
        }
    }
}
