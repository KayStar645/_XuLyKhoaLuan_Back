using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IDotdkRepository
    {
        public Task<List<DotdkModel>> GetAllDotdksAsync();
        public Task<DotdkModel> GetDotdkByIDAsync(DotdkModel dotDK);
        public Task<string> AddDotdksAsync(DotdkModel model);
        public Task DeleteDotdksAsync(DotdkModel dotDK);
    }
}
