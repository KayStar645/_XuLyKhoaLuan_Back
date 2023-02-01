using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IHdgopyRepository
    {
        public Task<List<HdgopyModel>> GetAllHdgopysAsync();
        public Task<HdgopyModel> GetHdgopyByIDAsync(int ma);
        public Task<string> AddHdgopysAsync(HdgopyModel model);
        public Task UpdateHdgopysAsync(int ma, HdgopyModel model);
        public Task DeleteHdgopysAsync(int ma);
    }
}
