using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhviensController : ControllerBase
    {
        private readonly ISinhvienRepository _sinhvienRepo;

        public SinhviensController(ISinhvienRepository repo)
        {
            _sinhvienRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSinhviens()
        {
            try
            {
                return Ok(await _sinhvienRepo.GetAllSinhViensAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maSV")]
        public async Task<IActionResult> GetSinhvienByMaSV(string maSV)
        {
            var SinhVien = await _sinhvienRepo.GetSinhVienByIDAsync(maSV);
            return SinhVien == null ? BadRequest() : Ok(SinhVien);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewSinhvien(SinhvienModel model)
        {
            try
            {
                var newSinhvien = await _sinhvienRepo.AddSinhViensAsync(model);
                return CreatedAtAction(nameof(GetSinhvienByMaSV), new { Controller = "Sinhviens", newSinhvien }, newSinhvien);
                //var SinhVien = await _detaiRepo.GetSinhVienByMaDTsAsync(newSinhvien);
                //return SinhVien == null ? BadRequest() : Ok(SinhVien);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("maSV")]
        public async Task<IActionResult> UpdateSinhvien(string maSV, SinhvienModel model)
        {

            try
            {
                await _sinhvienRepo.UpdateSinhViensAsync(maSV, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("maSV")]
        public async Task<IActionResult> DeleteSinhvien(string maSV)
        {
            await _sinhvienRepo.DeleteSinhViensAsync(maSV);
            return Ok();
        }
    }
}
