using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HuongdansController : ControllerBase
    {
        private readonly IHuongdanRepository _HuongdanRepo;

        public HuongdansController(IHuongdanRepository repo)
        {
            _HuongdanRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHuongdans()
        {
            try
            {
                return Ok(await _HuongdanRepo.GetAllHuongdansAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaGV, MaDT")]
        public async Task<IActionResult> GetHuongdanByMaCN(string MaGV, string MaDT)
        {
            HuongdanModel huongDan = new()
            {
                MaGv = MaGV,
                MaDt = MaDT
            };
            var Huongdan = await _HuongdanRepo.GetHuongdanByIDAsync(huongDan);
            return Huongdan == null ? BadRequest() : Ok(Huongdan);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewHuongdan(HuongdanModel model)
        {
            try
            {
                var newHuongdan = await _HuongdanRepo.AddHuongdansAsync(model);
                return CreatedAtAction(nameof(GetHuongdanByMaCN), new { Controller = "Huongdans", newHuongdan }, newHuongdan);
                //var Huongdan = await _detaiRepo.GetHuongdanByMaDTsAsync(newHuongdan);
                //return Huongdan == null ? BadRequest() : Ok(Huongdan);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaGV, MaDT")]
        public async Task<IActionResult> UpdateHuongdan(string MaGV, string MaDT, HuongdanModel model)
        {

            try
            {
                HuongdanModel huongDan = new()
                {
                    MaGv = MaGV,
                    MaDt = MaDT
                };
                await _HuongdanRepo.UpdateHuongdansAsync(huongDan, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaGV, MaDT")]
        public async Task<IActionResult> DeleteHuongdan(string MaGV, string MaDT)
        {
            HuongdanModel huongDan = new()
            {
                MaGv = MaGV,
                MaDt = MaDT
            };
            await _HuongdanRepo.DeleteHuongdansAsync(huongDan);
            return Ok();
        }
    }
}
