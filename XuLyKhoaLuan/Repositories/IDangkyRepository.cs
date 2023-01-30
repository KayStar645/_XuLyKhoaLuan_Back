using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public interface IDangkyRepository
    {
        public Task<List<DangkyModel>> GetAllDangkysAsync();
        public Task<DangkyModel> GetDangkyByIDAsync(DangkyModel ma);
        public Task<string> AddDangkysAsync(DangkyModel model);
        public Task UpdateDangkysAsync(DangkyModel ma, DangkyModel model);
        public Task DeleteDangkysAsync(DangkyModel ma);
    }
}
