using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThamgiahdsController : ControllerBase
    {
        private readonly IThamgiahdRepository _ThamgiahdRepo;

        public ThamgiahdsController(IThamgiahdRepository repo)
        {
            _ThamgiahdRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllThamgiahds()
        {
            try
            {
                return Ok(await _ThamgiahdRepo.GetAllThamgiahdsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaGV, MaHD")]
        public async Task<IActionResult> GetThamgiahdByMaCN(string MaGV, string MaHD)
        {
            ThamgiahdModel thamGiaHD = new()
            {
                MaGv = MaGV,
                MaHd = MaHD
            };
            var Thamgiahd = await _ThamgiahdRepo.GetThamgiahdByIDAsync(thamGiaHD);
            return Thamgiahd == null ? BadRequest() : Ok(Thamgiahd);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewThamgiahd(ThamgiahdModel model)
        {
            try
            {
                var newThamgiahd = await _ThamgiahdRepo.AddThamgiahdsAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaGV, MaHD")]
        public async Task<IActionResult> UpdateThamgiahd(string MaGV, string MaHD, ThamgiahdModel model)
        {

            try
            {
                ThamgiahdModel thamGiaHD = new()
                {
                    MaGv = MaGV,
                    MaHd = MaHD
                };
                await _ThamgiahdRepo.UpdateThamgiahdsAsync(thamGiaHD, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaGV, MaHD")]
        public async Task<IActionResult> DeleteThamgiahd(string MaGV, string MaHD)
        {
            ThamgiahdModel thamGiaHD = new()
            {
                MaGv = MaGV,
                MaHd = MaHD
            };
            await _ThamgiahdRepo.DeleteThamgiahdsAsync(thamGiaHD);
            return Ok();
        }
    }
}
