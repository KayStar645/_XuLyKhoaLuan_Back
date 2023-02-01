using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IKehoachRepository
    {
        public Task<List<KehoachModel>> GetAllKehoachesAsync();
        public Task<KehoachModel> GetKehoachByIDAsync(int ma);
        public Task<string> AddKehoachesAsync(KehoachModel model);
        public Task UpdateKehoachesAsync(int ma, KehoachModel model);
        public Task DeleteKehoachesAsync(int ma);
    }
}
