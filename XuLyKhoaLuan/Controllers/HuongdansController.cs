using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

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
                return Ok(model);
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
