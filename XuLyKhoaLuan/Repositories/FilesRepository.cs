using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using XuLyKhoaLuan.Helpers;
using XuLyKhoaLuan.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class FilesRepository : IFilesRepository
    {
        private readonly string _uploadPath;

        public FilesRepository(IWebHostEnvironment webHostEnvironment)
        {
            _uploadPath = Path.Combine(webHostEnvironment.ContentRootPath, "Files");
        }

        public async Task<string> UploadFileAsync(IFormFile file, string folder)
        {
            var fileName = Guid.NewGuid().ToString() + "__" +  file.FileName;
            var filePath = Path.Combine(_uploadPath, folder + "/"+ fileName);
            var directoryPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public async Task<byte[]> DownloadFileAsync(string fileName, string folder)
        {
            var filePath = Path.Combine(_uploadPath, folder + "/" + fileName);

            if (File.Exists(filePath))
            {
                return await File.ReadAllBytesAsync(filePath);
            }

            return null;
        }
    }
}
