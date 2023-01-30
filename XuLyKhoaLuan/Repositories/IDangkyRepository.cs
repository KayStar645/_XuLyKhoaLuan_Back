using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public interface IDangkyRepository
    {
        public Task<List<DangkyModel>> GetAllDangkysAsync();
        public Task<DangkyModel> GetDangkyByIDAsync(DangkyModel dk);
        public Task<string> AddDangkysAsync(DangkyModel model);
        public Task UpdateDangkysAsync(DangkyModel dk, DangkyModel model);
        public Task DeleteDangkysAsync(DangkyModel dk);
    }
}
