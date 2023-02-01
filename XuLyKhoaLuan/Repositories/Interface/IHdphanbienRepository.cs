using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IHdphanbienRepository
    {
        public Task<List<HdphanbienModel>> GetAllHdphanbiensAsync();
        public Task<HdphanbienModel> GetHdphanbienByIDAsync(HdphanbienModel hdpbNhanXet);
        public Task<string> AddHdphanbiensAsync(HdphanbienModel model);
        public Task UpdateHdphanbiensAsync(HdphanbienModel hdpbNhanXet, HdphanbienModel model);
        public Task DeleteHdphanbiensAsync(HdphanbienModel hdpbNhanXet);
    }
}
