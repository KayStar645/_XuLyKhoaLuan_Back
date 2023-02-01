using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IHdchamRepository
    {
        public Task<List<HdchamModel>> GetAllHdchamsAsync();
        public Task<HdchamModel> GetHdchamByIDAsync(HdchamModel hdCham);
        public Task<string> AddHdchamsAsync(HdchamModel model);
        public Task UpdateHdchamsAsync(HdchamModel hdCham, HdchamModel model);
        public Task DeleteHdchamsAsync(HdchamModel hdCham);
    }
}
