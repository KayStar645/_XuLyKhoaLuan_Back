using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IGiangvienRepository
    {
        public Task<List<GiangvienModel>> GetAllGiangviensAsync();
        public Task<GiangvienModel> GetGiangvienByIDAsync(string ma);
        public Task<string> AddGiangviensAsync(GiangvienModel model);
        public Task UpdateGiangviensAsync(string ma, GiangvienModel model);
        public Task DeleteGiangviensAsync(string ma);
    }
}
