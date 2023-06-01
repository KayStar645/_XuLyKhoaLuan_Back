namespace XuLyKhoaLuan.Interface
{
    public interface IFilesRepository
    {
        public Task<string> UploadFile(Stream fileStream, string fileName, string folderPath);
        public Task<Stream> DownloadFile(string fileName, string folderPath);
        public Task<string> test(string a, bool b);
    }
}
