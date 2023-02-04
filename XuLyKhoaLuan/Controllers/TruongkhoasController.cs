using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

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

        [HttpGet("MaKhoa, MaGV")]
        public async Task<IActionResult> GetTruongkhoaByMaCN(string MaKhoa, string MaGV)
        {
            TruongkhoaModel truongKhoa = new()
            {
                MaKhoa = MaKhoa,
                MaGv = MaGV

            };
            var Truongkhoa = await _TruongkhoaRepo.GetTruongkhoaByIDAsync(truongKhoa);
            return Truongkhoa == null ? BadRequest() : Ok(Truongkhoa);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTruongkhoa(TruongkhoaModel model)
        {
            try
            {
                var newTruongkhoa = await _TruongkhoaRepo.AddTruongkhoasAsync(model);
                return CreatedAtAction(nameof(GetTruongkhoaByMaCN), new { Controller = "Truongkhoas", newTruongkhoa }, newTruongkhoa);
                //var Truongkhoa = await _detaiRepo.GetTruongkhoaByMaDTsAsync(newTruongkhoa);
                //return Truongkhoa == null ? BadRequest() : Ok(Truongkhoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaKhoa, MaGV")]
        public async Task<IActionResult> UpdateTruongkhoa(string MaKhoa, string MaGV, TruongkhoaModel model)
        {

            try
            {
                TruongkhoaModel truongKhoa = new()
                {
                    MaKhoa = MaKhoa,
                    MaGv = MaGV,
    
                };
                await _TruongkhoaRepo.UpdateTruongkhoasAsync(truongKhoa, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaKhoa, MaGV")]
        public async Task<IActionResult> DeleteTruongkhoa(string MaKhoa, string MaGV)
        {
            TruongkhoaModel truongKhoa = new()
            {
                MaKhoa = MaKhoa,
                MaGv = MaGV,

            };
            await _TruongkhoaRepo.DeleteTruongkhoasAsync(truongKhoa);
            return Ok();
        }
    }
}
