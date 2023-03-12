using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Helpers;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadeController : ControllerBase
    {
        private readonly IRadeRepository _repo;

        public RadeController(IRadeRepository repo) 
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRades()
        {
            try
            {
                return Ok(await _repo.GetAllRadesAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maGV, maDT")]
        public async Task<IActionResult> GetRadeByMaGV(string? maGV, string? maDT)
        {
            try
            {
                var result = await _repo.GetRadeByMaGVMaDTAsync(maGV, maDT);
                return result == null ? BadRequest() : Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRades(RadeModel model)
        {
            try
            {
                await _repo.AddRadesAsync(model);
                return Ok(model);
            }
            catch(Exception e)
            {
                switch(e)
                {
                    case errorMessage:
                        return StatusCode(409, e.Message);
                    default:
                        return StatusCode(500, e.Message);
                }    
            }
        }

        [HttpDelete("MaGV, maDT")]
        public async Task<IActionResult> DeleteRade(string maGV, string maDT)
        {
            RadeModel delete = new RadeModel()
            {
                MaDt = maDT,
                MaGv = maGV,
            };
            await _repo.DeleteRadeAsync(delete);
            return Ok();
        }

    }
}
