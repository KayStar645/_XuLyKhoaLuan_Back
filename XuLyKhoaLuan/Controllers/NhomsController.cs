using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

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
        public async Task<IActionResult> GetNhomByID(int MaNhom)
        {
            var Nhom = await _NhomRepo.GetNhomByIDAsync(MaNhom);
            return Nhom == null ? BadRequest() : Ok(Nhom);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewNhom(NhomModel model)
        {
            try
            {
                var newNhom = await _NhomRepo.AddNhomsAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaNhom")]
        public async Task<IActionResult> UpdateNhom(int MaNhom, NhomModel model)
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
        public async Task<IActionResult> DeleteNhom(int MaNhom)
        {
            await _NhomRepo.DeleteNhomsAsync(MaNhom);
            return Ok();
        }
    }
}
