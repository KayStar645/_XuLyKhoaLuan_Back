using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DotdksController : ControllerBase
    {
        private readonly IDotdkRepository _DotdkRepo;
        // GET: api/<DotdksController>
        public DotdksController(IDotdkRepository repo)
        {
            _DotdkRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDotdks()
        {
            try
            {
                return Ok(await _DotdkRepo.GetAllDotdksAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<DotdksController>/5
        [HttpGet("NamHoc, Dot")]
        public async Task<IActionResult> GetDotdkById(string NamHoc, int Dot)
        {
            try
            {
                DotdkModel model = new()
                {
                    NamHoc = NamHoc,
                    Dot = Dot
                };
                var dotDK = await _DotdkRepo.GetDotdkByIDAsync(model);
                return dotDK == null ? NotFound() : Ok(dotDK);
            }
            catch
            {

                return BadRequest();
            }
        }

        // POST api/<DotdksController>
        [HttpPost]
        public async Task<IActionResult> AddNewDotdk(DotdkModel model)
        {
            try
            {
                var newDotdk = await _DotdkRepo.AddDotdksAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<DotdksController>/5
        [HttpDelete("NamHoc, Dot")]
        public async Task<IActionResult> Delete(string NamHoc, int Dot)
        {
            DotdkModel model = new()
            {
                NamHoc = NamHoc,
                Dot = Dot
            };
            await _DotdkRepo.DeleteDotdksAsync(model);
            return Ok();
        }
    }
}
