using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface ITruongkhoaRepository
    {
        public Task<List<TruongkhoaModel>> GetAllTruongkhoasAsync();
        public Task<TruongkhoaModel> GetTruongkhoaByIDAsync(TruongkhoaModel truongKhoa);
        public Task<string> AddTruongkhoasAsync(TruongkhoaModel model);
        public Task UpdateTruongkhoasAsync(TruongkhoaModel truongKhoa, TruongkhoaModel model);
        public Task DeleteTruongkhoasAsync(TruongkhoaModel truongKhoa);
    }
}
