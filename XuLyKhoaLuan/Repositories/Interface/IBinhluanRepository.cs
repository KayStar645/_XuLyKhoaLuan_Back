using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IBinhluanRepository
    {
        public Task<List<BinhluanModel>> GetAllBinhluansAsync();
        public Task<BinhluanModel> GetBinhluanByIDAsync(string maBL);
        public Task<string> AddBinhluansAsync(BinhluanModel model);
        public Task UpdateBinhluansAsync(string maBL, BinhluanModel model);
        public Task DeleteBinhluansAsync(string maBL);
    }
}
