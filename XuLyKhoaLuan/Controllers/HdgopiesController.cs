using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HdgopiesController : ControllerBase
    {
        private readonly IHdgopyRepository _HdgopyRepo;

        public HdgopiesController(IHdgopyRepository repo)
        {
            _HdgopyRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHdgopies()
        {
            try
            {
                return Ok(await _HdgopyRepo.GetAllHdgopiesAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetHdgopyByMaCN(int id)
        {
            var Hdgopy = await _HdgopyRepo.GetHdgopyByIDAsync(id);
            return Hdgopy == null ? BadRequest() : Ok(Hdgopy);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewHdgopy(HdgopyModel model)
        {
            try
            {
                var newHdgopy = await _HdgopyRepo.AddHdgopiesAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateHdgopy(int id, HdgopyModel model)
        {

            try
            {
                await _HdgopyRepo.UpdateHdgopiesAsync(id, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteHdgopy(int id)
        {
            await _HdgopyRepo.DeleteHdgopiesAsync(id);
            return Ok();
        }

        [HttpGet("maCv")]
        public async Task<IActionResult> GetHdGopyByMacv(string maCv)
        {
            try
            {
                return Ok(await _HdgopyRepo.GetHdGopyByMacv(maCv));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
