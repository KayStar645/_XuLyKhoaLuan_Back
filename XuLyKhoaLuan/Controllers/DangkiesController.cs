using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

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
        public async Task<IActionResult> GetDangkyByMaCN(string maDT, string maNhom)
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
        public async Task<IActionResult> UpdateDangky(string maDT, string maNhom, DangkyModel model)
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
        public async Task<IActionResult> DeleteDangky(string maDT, string maNhom)
        {
            DangkyModel dangKyM = new()
            {
                MaDt = maDT,
                MaNhom = maNhom
            };
            await _DangkyRepo.DeleteDangkiesAsync(dangKyM);
            return Ok();
        }

        [HttpGet("namHoc, dot, maNhom")]
        public async Task<IActionResult> GetAllDetaiDangkyAsync(string namHoc, int dot, string maNhom)
        {
            try
            {
                return Ok(await _DangkyRepo.GetAllDetaiDangkyAsync(namHoc, dot, maNhom));
            }
            catch
            {
                return BadRequest();
            }
        }

        // Chỉ kiểm tra trong đợt đó thôi
        [HttpGet("maNhom")]
        public async Task<IActionResult> isNhomDangkyDetaiAsyc(string maNhom)
        {
            return Ok(await _DangkyRepo.isNhomDangkyDetaiAsyc(maNhom));
        }


        [HttpGet("nhom, namHoc, dot")]
        public async Task<IActionResult> GetDetaiDangkyAsync(string nhom, string namHoc, int dot)
        {
            try
            {
                return Ok(await _DangkyRepo.GetDetaiDangkyAsync(nhom, namHoc, dot));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
