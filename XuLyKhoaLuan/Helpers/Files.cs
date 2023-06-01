using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace XuLyKhoaLuan.Helpers
{
    public class Files
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Files(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFile(IFormFile file, string folderPath)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, folderPath);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public async Task<byte[]> DownloadFile(string fileName, string folderPath)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, folderPath);
            var filePath = Path.Combine(uploadsFolder, fileName);

            if (!File.Exists(filePath))
            {
                return null;
            }

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                using (var memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
