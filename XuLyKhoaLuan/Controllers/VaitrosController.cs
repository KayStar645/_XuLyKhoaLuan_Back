using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaitrosController : ControllerBase
    {
        private readonly IVaitroRepository _VaitroRepo;

        public VaitrosController(IVaitroRepository repo)
        {
            _VaitroRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVaitros()
        {
            try
            {
                return Ok(await _VaitroRepo.GetAllVaitrosAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaVT")]
        public async Task<IActionResult> GetVaitroByID(string MaVT)
        {
            var Vaitro = await _VaitroRepo.GetVaitroByIDAsync(MaVT);
            return Vaitro == null ? BadRequest() : Ok(Vaitro);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewVaitro(VaitroModel model)
        {
            try
            {
                var newVaitro = await _VaitroRepo.AddVaitrosAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaVT")]
        public async Task<IActionResult> UpdateVaitro(string MaVT, VaitroModel model)
        {

            try
            {
                await _VaitroRepo.UpdateVaitrosAsync(MaVT, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaVT")]
        public async Task<IActionResult> DeleteVaitro(string MaVT)
        {
            await _VaitroRepo.DeleteVaitrosAsync(MaVT);
            return Ok();
        }
    }
}
