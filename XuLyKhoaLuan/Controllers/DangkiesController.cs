using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DangkysController : ControllerBase
    {
        private readonly IDangkyRepository _DangkyRepo;

        public DangkysController(IDangkyRepository repo)
        {
            _DangkyRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDangkys()
        {
            try
            {
                return Ok(await _DangkyRepo.GetAllDangkiesAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maDT, maNhom")]
        public async Task<IActionResult> GetDangkyByMaCN(string maDT, int maNhom)
        {
            DangkyModel dangKyM= new()
            {
                MaDt = maDT,
                MaNhom = maNhom
            };
            var Dangky = await _DangkyRepo.GetDangkyByIDAsync(dangKyM);
            return Dangky == null ? BadRequest() : Ok(Dangky);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewDangky(DangkyModel model)
        {
            try
            {
                var newDangky = await _DangkyRepo.AddDangkiesAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("maDT, maNhom")]
        public async Task<IActionResult> UpdateDangky(string maDT, int maNhom, DangkyModel model)
        {

            try
            {
                DangkyModel dangKyM = new()
                {
                    MaDt = maDT,
                    MaNhom = maNhom
                };
                await _DangkyRepo.UpdateDangkiesAsync(dangKyM, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("maDT, maNhom")]
        public async Task<IActionResult> DeleteDangky(string maDT, int maNhom)
        {
            DangkyModel dangKyM = new()
            {
                MaDt = maDT,
                MaNhom = maNhom
            };
            await _DangkyRepo.DeleteDangkiesAsync(dangKyM);
            return Ok();
        }
    }
}
