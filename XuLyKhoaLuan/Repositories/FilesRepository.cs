using System.IO;
using System.Threading.Tasks;
using XuLyKhoaLuan.Helpers;
using XuLyKhoaLuan.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class FilesRepository : IFilesRepository
    {
        private readonly Files _filesHelper;

        public FilesRepository(Files filesHelper)
        {
            _filesHelper = filesHelper;
        }

        public async Task<string> UploadFile(Stream fileStream, string fileName, string folderPath)
        {
            
            return null;
        }

        public async Task<Stream> DownloadFile(string fileName, string folderPath)
        {
            return null;
        }

        public async Task<string> test(string a, bool b)
        {
            return "test";
        }
    }
}
