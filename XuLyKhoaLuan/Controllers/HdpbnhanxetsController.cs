using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HdpbnhanxetsController : ControllerBase
    {
        private readonly IHdpbnhanxetRepository _HdpbnhanxetRepo;

        public HdpbnhanxetsController(IHdpbnhanxetRepository repo)
        {
            _HdpbnhanxetRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHdpbnhanxets()
        {
            try
            {
                return Ok(await _HdpbnhanxetRepo.GetAllHdpbnhanxetsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetHdpbnhanxetByMaCN(int id)
        {
            var Hdpbnhanxet = await _HdpbnhanxetRepo.GetHdpbnhanxetByIDAsync(id);
            return Hdpbnhanxet == null ? BadRequest() : Ok(Hdpbnhanxet);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewHdpbnhanxet(HdpbnhanxetModel model)
        {
            try
            {
                var newHdpbnhanxet = await _HdpbnhanxetRepo.AddHdpbnhanxetsAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateHdpbnhanxet(int id, HdpbnhanxetModel model)
        {

            try
            {
                await _HdpbnhanxetRepo.UpdateHdpbnhanxetsAsync(id, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteHdpbnhanxet(int id)
        {
            await _HdpbnhanxetRepo.DeleteHdpbnhanxetsAsync(id);
            return Ok();
        }
    }
}
