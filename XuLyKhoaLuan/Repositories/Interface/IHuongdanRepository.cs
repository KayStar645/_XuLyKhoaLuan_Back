using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IHuongdanRepository
    {
        public Task<List<HuongdanModel>> GetAllHuongdansAsync();
        public Task<HuongdanModel> GetHuongdanByIDAsync(HuongdanModel hdpbNhanXet);
        public Task<string> AddHuongdansAsync(HuongdanModel model);
        public Task UpdateHuongdansAsync(HuongdanModel hdpbNhanXet, HuongdanModel model);
        public Task DeleteHuongdansAsync(HuongdanModel hdpbNhanXet);
    }
}
