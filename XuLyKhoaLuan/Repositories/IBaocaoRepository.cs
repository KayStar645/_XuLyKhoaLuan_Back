using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public interface IBaocaoRepository
    {
        public Task<List<BaocaoModel>> GetAllBaoCaosAsync();
        public Task<BaocaoModel> GetBaoCaoByIDAsync(BaocaoModel bc);
        public Task<string> AddBaoCaosAsync(BaocaoModel model);
        public Task UpdateBaoCaosAsync(BaocaoModel bc, BaocaoModel model);
        public Task DeleteBaoCaosAsync(BaocaoModel bc);
    }
}
