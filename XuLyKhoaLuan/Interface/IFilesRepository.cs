using Microsoft.AspNetCore.Mvc;

namespace XuLyKhoaLuan.Interface
{
    public interface IFilesRepository
    {
        public Task<string> UploadFileAsync(IFormFile file, string folder);
        public Task<byte[]> DownloadFileAsync(string fileName, string folder);
    }
}
