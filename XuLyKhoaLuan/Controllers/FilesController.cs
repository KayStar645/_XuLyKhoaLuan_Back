using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFilesRepository _FilesRepo;

        public FilesController(IFilesRepository repo) 
        {
            this._FilesRepo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile()
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> DownloadFile()
        {
            try
            {

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("a,b")]
        public async Task<IActionResult> test(string a, bool b)
        {
            try
            {
                return Ok(await _FilesRepo.test(a, b));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
