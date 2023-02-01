using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IHdgopyRepository
    {
        public Task<List<HdgopyModel>> GetAllHdgopysAsync();
        public Task<HdgopyModel> GetHdgopyByIDAsync(HdgopyModel hdGopY);
        public Task<string> AddHdgopysAsync(HdgopyModel model);
        public Task UpdateHdgopysAsync(HdgopyModel hdGopY, HdgopyModel model);
        public Task DeleteHdgopysAsync(HdgopyModel hdGopY);
    }
}
