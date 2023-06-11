using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GapMatHdController : ControllerBase
    {
        private readonly IGapMatHdRepository _GapMatRepo;

        public GapMatHdController(IGapMatHdRepository repo)
        {
            _GapMatRepo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewThongbao(GapMatHdModel model)
        {
            try
            {
                var newGapMat = await _GapMatRepo.AddGapMatAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateThongbao(int id, GapMatHdModel model)
        {

            try
            {
                await _GapMatRepo.UpdateGapMatAsync(id, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
