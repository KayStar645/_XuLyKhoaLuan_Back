using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IHdgopyRepository
    {
        public Task<List<HdgopyModel>> GetAllHdgopiesAsync();
        public Task<HdgopyModel> GetHdgopyByIDAsync(int ma);
        public Task<string> AddHdgopiesAsync(HdgopyModel model);
        public Task UpdateHdgopiesAsync(int ma, HdgopyModel model);
        public Task DeleteHdgopiesAsync(int ma);
    }
}
