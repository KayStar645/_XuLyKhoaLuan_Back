using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongviecsController : ControllerBase
    {
        private readonly ICongviecRepository _CongviecRepo;

        public CongviecsController(ICongviecRepository repo)
        {
            _CongviecRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCongviecs()
        {
            try
            {
                return Ok(await _CongviecRepo.GetAllCongviecsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maCV")]
        public async Task<IActionResult> GetCongviecByMaCN(string maCV)
        {
            var Congviec = await _CongviecRepo.GetCongviecByIDAsync(maCV);
            return Congviec == null ? BadRequest() : Ok(Congviec);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCongviec(CongviecModel model)
        {
            try
            {
                var newCongviec = await _CongviecRepo.AddCongviecsAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("maCV")]
        public async Task<IActionResult> UpdateCongviec(string maCV, CongviecModel model)
        {

            try
            {
                await _CongviecRepo.UpdateCongviecsAsync(maCV, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("maCV")]
        public async Task<IActionResult> DeleteCongviec(string maCV)
        {
            await _CongviecRepo.DeleteCongviecsAsync(maCV);
            return Ok();
        }
    }
}
