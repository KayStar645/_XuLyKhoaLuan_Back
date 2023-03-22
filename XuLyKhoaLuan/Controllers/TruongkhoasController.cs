using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruongkhoasController : ControllerBase
    {
        private readonly ITruongkhoaRepository _TruongkhoaRepo;

        public TruongkhoasController(ITruongkhoaRepository repo)
        {
            _TruongkhoaRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTruongkhoas()
        {
            try
            {
                return Ok(await _TruongkhoaRepo.GetAllTruongkhoasAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maTk")]
        public async Task<IActionResult> GetTruongkhoaById(int maTk)
        {
            var Truongkhoa = await _TruongkhoaRepo.GetTruongkhoaByIDAsync(maTk);
            return Truongkhoa == null ? BadRequest() : Ok(Truongkhoa);
        }

        [HttpGet("maGV")]
        public async Task<IActionResult> CheckTruongKhoaByMaGV(string maGV)
        {
            var result = await _TruongkhoaRepo.CheckTruongKhoaByMaGVAsync(maGV);
            return Ok(result);
        }




        [HttpPost]
        public async Task<IActionResult> AddNewTruongkhoa(TruongkhoaModel model)
        {
            try
            {
                var newTruongkhoa = await _TruongkhoaRepo.AddTruongkhoasAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("maTK")]
        public async Task<IActionResult> UpdateTruongkhoa(int maTK, TruongkhoaModel model)
        {

            try
            {
                await _TruongkhoaRepo.UpdateTruongkhoasAsync(maTK, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("maTK")]
        public async Task<IActionResult> DeleteTruongkhoa(int maTK)
        {
            await _TruongkhoaRepo.DeleteTruongkhoasAsync(maTK);
            return Ok();
        }
    }
}
