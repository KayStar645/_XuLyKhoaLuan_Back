using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface ITruongkhoaRepository
    {
        public Task<string> AddTruongkhoasAsync(TruongkhoaModel model);
        public Task DeleteTruongkhoasAsync(int maTk);
        public Task<List<TruongkhoaModel>> GetAllTruongkhoasAsync();
        public Task<TruongkhoaModel> CheckTruongKhoaByMaGVAsync(string maGV);
        public Task<TruongkhoaModel> GetTruongkhoaByIDAsync(int maTk);
        public Task UpdateTruongkhoasAsync(int maTk, TruongkhoaModel model);
        public Task<bool> isTruongKhoaByMaGVAsync(string isMaGV);
    }
}
