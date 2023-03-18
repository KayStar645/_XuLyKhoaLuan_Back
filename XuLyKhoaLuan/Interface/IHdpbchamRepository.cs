using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IHdpbchamRepository
    {
        public Task<List<HdpbchamModel>> GetAllHdpbchamsAsync();
        public Task<HdpbchamModel> GetHdpbchamByIDAsync(HdpbchamModel hdpbCham);
        public Task<string> AddHdpbchamsAsync(HdpbchamModel model);
        public Task UpdateHdpbchamsAsync(HdpbchamModel hdpbCham, HdpbchamModel model);
        public Task DeleteHdpbchamsAsync(HdpbchamModel hdpbCham);
    }
}
