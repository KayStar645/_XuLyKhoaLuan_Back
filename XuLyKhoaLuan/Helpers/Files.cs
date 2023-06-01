using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public bool UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine("files", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return true;
            }

            return false;
        }

        //public async Task<byte[]> DownloadFile(string fileName, string folderPath)
        //{
        //    var uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, folderPath);
        //    var filePath = Path.Combine(uploadsFolder, fileName);

        //    if (!File.Exists(filePath))
        //    {
        //        return null;
        //    }

        //    using (var stream = new FileStream(filePath, FileMode.Open))
        //    {
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            await stream.CopyToAsync(memoryStream);
        //            return memoryStream.ToArray();
        //        }
        //    }
        //}
    }
}
