using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IHdpbnhanxetRepository
    {
        public Task<List<HdpbnhanxetModel>> GetAllHdpbnhanxetsAsync();
        public Task<HdpbnhanxetModel> GetHdpbnhanxetByIDAsync(HdpbnhanxetModel hdpbNhanXet);
        public Task<string> AddHdpbnhanxetsAsync(HdpbnhanxetModel model);
        public Task UpdateHdpbnhanxetsAsync(HdpbnhanxetModel hdpbNhanXet, HdpbnhanxetModel model);
        public Task DeleteHdpbnhanxetsAsync(HdpbnhanxetModel hdpbNhanXet);
    }
}
