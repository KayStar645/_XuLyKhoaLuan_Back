using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

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

        [HttpGet("maTbm")]
        public async Task<IActionResult> GetTruongbmById(int maTbm)
        {
            var Truongbm = await _TruongbmRepo.GetTruongbmByIDAsync(maTbm);
            return Truongbm == null ? BadRequest() : Ok(Truongbm);
        }


        [HttpGet("MaGV")]
        public async Task<IActionResult> CheckTruongBomonByMaGV(string MaGV)
        {
            var result = await _TruongbmRepo.CheckTruongBomonByMaGVAsync(MaGV);
            return Ok(result);
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

        [HttpPut("maTbm")]
        public async Task<IActionResult> UpdateTruongbm(int maTbm, TruongbmModel model)
        {

            try
            {
                await _TruongbmRepo.UpdateTruongbmsAsync(maTbm, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("maTbm")]
        public async Task<IActionResult> DeleteTruongbm(int maTbm)
        {
            await _TruongbmRepo.DeleteTruongbmsAsync(maTbm);
            return Ok();
        }
    }
}
