using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFilesRepository _repo;

        public FilesController(IFilesRepository filesRepository)
        {
            _repo = filesRepository;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is required");
            }

            var fileName = await _repo.UploadFileAsync(file);

            return Ok(new { FileName = fileName });
        }

        [HttpGet("download/{fileName}")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var fileData = await _repo.DownloadFileAsync(fileName);

            if (fileData == null)
            {
                return NotFound();
            }

            return File(fileData, "application/octet-stream", fileName);
        }
    }

}