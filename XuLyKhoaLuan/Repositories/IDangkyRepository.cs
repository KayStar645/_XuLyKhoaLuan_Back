using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public interface IDangkyRepository
    {
        public Task<List<DangkyModel>> GetAllDangkiesAsync();
        public Task<DangkyModel> GetDangkyByIDAsync(DangkyModel dk);
        public Task<string> AddDangkiesAsync(DangkyModel model);
        public Task UpdateDangkiesAsync(DangkyModel dk, DangkyModel model);
        public Task DeleteDangkiesAsync(DangkyModel dk);
    }
}
