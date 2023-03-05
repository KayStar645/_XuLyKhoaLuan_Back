using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongbaosController : ControllerBase
    {
        private readonly IThongbaoRepository _ThongbaoRepo;

        public ThongbaosController(IThongbaoRepository repo)
        {
            _ThongbaoRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllThongbaos()
        {
            try
            {
                return Ok(await _ThongbaoRepo.GetAllThongbaosAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaTB")]
        public async Task<IActionResult> GetThongbaoByID(int MaTB)
        {
            var Thongbao = await _ThongbaoRepo.GetThongbaoByIDAsync(MaTB);
            return Thongbao == null ? BadRequest() : Ok(Thongbao);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewThongbao(ThongbaoModel model)
        {
            try
            {
                var newThongbao = await _ThongbaoRepo.AddThongbaosAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaTB")]
        public async Task<IActionResult> UpdateThongbao(int MaTB, ThongbaoModel model)
        {

            try
            {
                await _ThongbaoRepo.UpdateThongbaosAsync(MaTB, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaTB")]
        public async Task<IActionResult> DeleteThongbao(int MaTB)
        {
            await _ThongbaoRepo.DeleteThongbaosAsync(MaTB);
            return Ok();
        }
    }
}
