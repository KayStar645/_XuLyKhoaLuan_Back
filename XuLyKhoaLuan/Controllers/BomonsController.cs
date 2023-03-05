using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BomonsController : ControllerBase
    {
        private readonly IBomonRepository _BomonRepo;

        public BomonsController(IBomonRepository repo)
        {
            _BomonRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBomons()
        {
            try
            {
                return Ok(await _BomonRepo.GetAllBomonsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaBM")]
        public async Task<IActionResult> GetBomonByMaBM(string MaBM)
        {
            var Bomon = await _BomonRepo.GetBomonByIDAsync(MaBM);
            return Bomon == null ? BadRequest() : Ok(Bomon);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBomon(BomonModel model)
        {
            try
            {
                var newBomon = await _BomonRepo.AddBomonsAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaBM")]
        public async Task<IActionResult> UpdateBomon(string MaBM, BomonModel model)
        {

            try
            {
                await _BomonRepo.UpdateBomonsAsync(MaBM, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaBM")]
        public async Task<IActionResult> DeleteBomon(string MaBM)
        {
            await _BomonRepo.DeleteBomonsAsync(MaBM);
            return Ok();
        }
    }
}
