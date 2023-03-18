using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IBinhluanRepository
    {
        public Task<List<BinhluanModel>> GetAllBinhluansAsync();
        public Task<BinhluanModel> GetBinhluanByIDAsync(int maBL);
        public Task<string> AddBinhluansAsync(BinhluanModel model);
        public Task UpdateBinhluansAsync(int maBL, BinhluanModel model);
        public Task DeleteBinhluansAsync(int maBL);
    }
}
