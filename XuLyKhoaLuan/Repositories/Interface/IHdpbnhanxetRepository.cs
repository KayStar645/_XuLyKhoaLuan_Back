using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IHdpbnhanxetRepository
    {
        public Task<List<HdpbnhanxetModel>> GetAllHdpbnhanxetsAsync();
        public Task<HdpbnhanxetModel> GetHdpbnhanxetByIDAsync(int ma);
        public Task<string> AddHdpbnhanxetsAsync(HdpbnhanxetModel model);
        public Task UpdateHdpbnhanxetsAsync(int ma, HdpbnhanxetModel model);
        public Task DeleteHdpbnhanxetsAsync(int ma);
    }
}
