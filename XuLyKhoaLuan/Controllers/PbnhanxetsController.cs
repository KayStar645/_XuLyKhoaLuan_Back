using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PbnhanxetsController : ControllerBase
    {
        private readonly IPbnhanxetRepository _PbnhanxetRepo;

        public PbnhanxetsController(IPbnhanxetRepository repo)
        {
            _PbnhanxetRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPbnhanxets()
        {
            try
            {
                return Ok(await _PbnhanxetRepo.GetAllPbnhanxetsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPbnhanxetByMaCN(int id)
        {
            var Pbnhanxet = await _PbnhanxetRepo.GetPbnhanxetByIDAsync(id);
            return Pbnhanxet == null ? BadRequest() : Ok(Pbnhanxet);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewPbnhanxet(PbnhanxetModel model)
        {
            try
            {
                var newPbnhanxet = await _PbnhanxetRepo.AddPbnhanxetsAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdatePbnhanxet(int id, PbnhanxetModel model)
        {

            try
            {
                await _PbnhanxetRepo.UpdatePbnhanxetsAsync(id, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeletePbnhanxet(int id)
        {
            await _PbnhanxetRepo.DeletePbnhanxetsAsync(id);
            return Ok();
        }
    }
}
