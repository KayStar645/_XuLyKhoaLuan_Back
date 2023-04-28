using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuyennganhsController : ControllerBase
    {
        private readonly IChuyennganhRepository _ChuyennganhRepo;

        public ChuyennganhsController(IChuyennganhRepository repo)
        {
            _ChuyennganhRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChuyennganhs()
        {
            try
            {
                return Ok(await _ChuyennganhRepo.GetAllChuyennganhsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maCN")]
        public async Task<IActionResult> GetChuyennganhByMaCN(string maCN)
        {
            var Chuyennganh = await _ChuyennganhRepo.GetChuyennganhByIDAsync(maCN);
            return Chuyennganh == null ? BadRequest() : Ok(Chuyennganh);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewChuyennganh(ChuyennganhModel model)
        {
            try
            {
                var newChuyennganh = await _ChuyennganhRepo.AddChuyennganhsAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("maCN")]
        public async Task<IActionResult> UpdateChuyennganh(string maCN, ChuyennganhModel model)
        {

            try
            {
                await _ChuyennganhRepo.UpdateChuyennganhsAsync(maCN, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("maCN")]
        public async Task<IActionResult> DeleteChuyennganh(string maCN)
        {
            await _ChuyennganhRepo.DeleteChuyennganhsAsync(maCN);
            return Ok();
        }

        [HttpGet("tenCn")]
        public async Task<IActionResult> GetMaCnByTenAsync(string tenCn)
        {
            try
            {
                return Ok(await _ChuyennganhRepo.GetMaCnByTenAsync(tenCn));
            }
            catch
            {
                return BadRequest();
            }
        }    
    }
}
