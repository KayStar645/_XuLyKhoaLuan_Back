using Microsoft.AspNetCore.Mvc;

namespace XuLyKhoaLuan.Interface
{
    public interface IFilesRepository
    {
        public Task<string> UploadFileAsync(IFormFile file);
        public Task<byte[]> DownloadFileAsync(string fileName);
    }
}
