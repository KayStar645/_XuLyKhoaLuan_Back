using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhomsController : ControllerBase
    {
        private readonly INhomRepository _NhomRepo;

        public NhomsController(INhomRepository repo)
        {
            _NhomRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNhoms()
        {
            try
            {
                return Ok(await _NhomRepo.GetAllNhomsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaNhom")]
        public async Task<IActionResult> GetNhomByID(string MaNhom)
        {
            var Nhom = await _NhomRepo.GetNhomByIDAsync(MaNhom);
            return Nhom == null ? BadRequest() : Ok(Nhom);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewNhom(NhomModel model)
        {
            try
            {
                // Nếu nhóm đủ 3 thành viên rồi thì không cho thêm
                var newNhom = await _NhomRepo.AddNhomsAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaNhom")]
        public async Task<IActionResult> UpdateNhom(string MaNhom, NhomModel model)
        {

            try
            {
                await _NhomRepo.UpdateNhomsAsync(MaNhom, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaNhom")]
        public async Task<IActionResult> DeleteNhom(string MaNhom)
        {
            await _NhomRepo.DeleteNhomsAsync(MaNhom);
            return Ok();
        }

        [HttpGet("ma")]
        public async Task<IActionResult> CountThanhVienNhom(string ma)
        {
            return Ok(await _NhomRepo.CountThanhVienNhomAsync(ma));
        }

        [HttpGet("maDT")]
        public async Task<IActionResult> GetNhomByMadtAsync(string maDT)
        {
            var Nhom = await _NhomRepo.GetNhomByMadtAsync(maDT);
            return Nhom == null ? BadRequest() : Ok(Nhom);
        }

        [HttpGet("maSV, namHoc, dot, maNhom")]
        public async Task<IActionResult> isTruongNhomByMasvAsync(string maSV, string namHoc, int dot, string maNhom)
        {
            try
            {
                return Ok(await _NhomRepo.isTruongNhomByMasvAsync(maSV, namHoc, dot, maNhom));
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
