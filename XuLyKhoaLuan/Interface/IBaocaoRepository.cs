using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IBaocaoRepository
    {
        public Task<List<BaocaoModel>> GetAllBaoCaosAsync();
        public Task<BaocaoModel> GetBaoCaoByIDAsync(BaocaoModel bc);
        public Task<string> AddBaoCaosAsync(BaocaoModel model);
        public Task UpdateBaoCaosAsync(BaocaoModel bc, BaocaoModel model);
        public Task DeleteBaoCaosAsync(BaocaoModel bc);
        public Task<int> createLanNop(string maCv, string maSv, string namHoc, int dot);
        public Task<List<BaocaoModel>> GetBaocaoByMacv(string maCv);
    }
}
