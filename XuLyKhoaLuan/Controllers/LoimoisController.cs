using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoimoisController : ControllerBase
    {
        private readonly ILoimoiRepository _LoimoiRepo;

        public LoimoisController(ILoimoiRepository repo)
        {
            _LoimoiRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoimois()
        {
            try
            {
                return Ok(await _LoimoiRepo.GetAllLoimoisAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaNhom, MaSV, NamHoc, Dot")]
        public async Task<IActionResult> GetLoimoiByID(string MaNhom, string MaSV, string NamHoc, int Dot)
        {
            LoimoiModel loiMoi = new()
            {
                MaNhom = MaNhom,
                MaSv = MaSV,
                NamHoc = NamHoc,
                Dot = Dot
            };
            var Loimoi = await _LoimoiRepo.GetLoimoiByIDAsync(loiMoi);
            return Loimoi == null ? BadRequest() : Ok(Loimoi);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewLoimoi(LoimoiModel model)
        {
            try
            {
                var newLoimoi = await _LoimoiRepo.AddLoimoisAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaNhom, MaSV, NamHoc, Dot")]
        public async Task<IActionResult> UpdateLoimoi(string MaNhom, string MaSV, string NamHoc, int Dot, LoimoiModel model)
        {

            try
            {
                LoimoiModel loiMoi = new()
                {
                    MaNhom = MaNhom,
                    MaSv = MaSV,
                    NamHoc = NamHoc,
                    Dot = Dot
                };
                await _LoimoiRepo.UpdateLoimoisAsync(loiMoi, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaNhom, MaSV, NamHoc, Dot")]
        public async Task<IActionResult> DeleteLoimoi(string MaNhom, string MaSV, string NamHoc, int Dot)
        {
            LoimoiModel loiMoi = new()
            {
                MaNhom = MaNhom,
                MaSv = MaSV,
                NamHoc = NamHoc,
                Dot = Dot
            };
            await _LoimoiRepo.DeleteLoimoisAsync(loiMoi);
            return Ok();
        }
    }
}
