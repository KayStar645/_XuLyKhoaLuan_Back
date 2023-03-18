using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface ITruongkhoaRepository
    {
        public Task<List<TruongkhoaModel>> GetAllTruongkhoasAsync();
        public Task<TruongkhoaModel> GetTruongkhoaByMaKhoaMaGVAsync(TruongkhoaModel truongKhoa);
        public Task<TruongkhoaModel> GetTruongkhoaByMaGVAsync(string maGV);
        public Task<string> AddTruongkhoasAsync(TruongkhoaModel model);
        public Task UpdateTruongkhoasAsync(TruongkhoaModel truongKhoa, TruongkhoaModel model);
        public Task DeleteTruongkhoasAsync(TruongkhoaModel truongKhoa);
    }
}
