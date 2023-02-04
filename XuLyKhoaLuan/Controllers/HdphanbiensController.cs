using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HdphanbiensController : ControllerBase
    {
        private readonly IHdphanbienRepository _HdphanbienRepo;

        public HdphanbiensController(IHdphanbienRepository repo)
        {
            _HdphanbienRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHdphanbiens()
        {
            try
            {
                return Ok(await _HdphanbienRepo.GetAllHdphanbiensAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaGV, MaHD, MaDT")]
        public async Task<IActionResult> GetHdphanbienByMaCN(string MaGV, string MaHD, string MaDT)
        {
            HdphanbienModel hdpbCham = new()
            {
                MaGv = MaGV,
                MaHd = MaHD,
                MaDt = MaDT
            };
            var Hdphanbien = await _HdphanbienRepo.GetHdphanbienByIDAsync(hdpbCham);
            return Hdphanbien == null ? BadRequest() : Ok(Hdphanbien);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewHdphanbien(HdphanbienModel model)
        {
            try
            {
                var newHdphanbien = await _HdphanbienRepo.AddHdphanbiensAsync(model);
                return CreatedAtAction(nameof(GetHdphanbienByMaCN), new { Controller = "Hdphanbiens", newHdphanbien }, newHdphanbien);
                //var Hdphanbien = await _detaiRepo.GetHdphanbienByMaDTsAsync(newHdphanbien);
                //return Hdphanbien == null ? BadRequest() : Ok(Hdphanbien);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaGV, MaHD, MaDT")]
        public async Task<IActionResult> UpdateHdphanbien(string MaGV, string MaHD, string MaDT, HdphanbienModel model)
        {

            try
            {
                HdphanbienModel hdpbCham = new()
                {
                    MaGv = MaGV,
                    MaHd = MaHD,
                    MaDt = MaDT
                };
                await _HdphanbienRepo.UpdateHdphanbiensAsync(hdpbCham, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaGV, MaHD, MaDT")]
        public async Task<IActionResult> DeleteHdphanbien(string MaGV, string MaHD, string MaDT)
        {
            HdphanbienModel hdpbCham = new()
            {
                MaGv = MaGV,
                MaHd = MaHD,
                MaDt = MaDT
            };
            await _HdphanbienRepo.DeleteHdphanbiensAsync(hdpbCham);
            return Ok();
        }
    }
}
