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
        private string GetFileDownloadLink(string fileName, string folder)
        {
            return Url.Action("DownloadFile", "Files", new { fileName, folder }, Request.Scheme);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is required");
            }

            var fileName = await _repo.UploadFileAsync(file, folder);

            return Ok(new { fileName });
        }

        [HttpGet("download/{fileName}")]
        public async Task<IActionResult> DownloadFile(string fileName, string folder)
        {
            var fileData = await _repo.DownloadFileAsync(fileName, folder);

            if (fileData == null)
            {
                return NotFound();
            }

            return File(fileData, "application/octet-stream", fileName);
        }
    }

}