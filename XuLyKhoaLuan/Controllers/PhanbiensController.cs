using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhanbiensController : ControllerBase
    {
        private readonly IPhanbienRepository _PhanbienRepo;

        public PhanbiensController(IPhanbienRepository repo)
        {
            _PhanbienRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPhanbiens()
        {
            try
            {
                return Ok(await _PhanbienRepo.GetAllPhanbiensAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaGV, MaDT")]
        public async Task<IActionResult> GetPhanbienByMaCN(string MaGV, string MaDT)
        {
            PhanbienModel phanBien = new()
            {
                MaGv = MaGV,
                MaDt = MaDT
            };
            var Phanbien = await _PhanbienRepo.GetPhanbienByIDAsync(phanBien);
            return Phanbien == null ? BadRequest() : Ok(Phanbien);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewPhanbien(PhanbienModel model)
        {
            try
            {
                var newPhanbien = await _PhanbienRepo.AddPhanbiensAsync(model);
                return CreatedAtAction(nameof(GetPhanbienByMaCN), new { Controller = "Phanbiens", newPhanbien }, newPhanbien);
                //var Phanbien = await _detaiRepo.GetPhanbienByMaDTsAsync(newPhanbien);
                //return Phanbien == null ? BadRequest() : Ok(Phanbien);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaGV, MaDT")]
        public async Task<IActionResult> UpdatePhanbien(string MaGV, string MaDT, PhanbienModel model)
        {

            try
            {
                PhanbienModel phanBien = new()
                {
                    MaGv = MaGV,
                    MaDt = MaDT
                };
                await _PhanbienRepo.UpdatePhanbiensAsync(phanBien, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaGV, MaDT")]
        public async Task<IActionResult> DeletePhanbien(string MaGV, string MaDT)
        {
            PhanbienModel phanBien = new()
            {
                MaGv = MaGV,
                MaDt = MaDT
            };
            await _PhanbienRepo.DeletePhanbiensAsync(phanBien);
            return Ok();
        }
    }
}
