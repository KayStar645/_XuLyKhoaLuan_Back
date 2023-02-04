using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface ITruongbmRepository
    {
        public Task<List<TruongbmModel>> GetAllTruongbmsAsync();
        public Task<TruongbmModel> GetTruongbmByIDAsync(TruongbmModel truongBM);
        public Task<string> AddTruongbmsAsync(TruongbmModel model);
        public Task UpdateTruongbmsAsync(TruongbmModel truongBM, TruongbmModel model);
        public Task DeleteTruongbmsAsync(TruongbmModel truongBM);
    }
}
