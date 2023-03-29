using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface ITruongbmRepository
    {
        public Task<string> AddTruongbmsAsync(TruongbmModel model);
        public Task DeleteTruongbmsAsync(int maTbm);
        public Task<List<TruongbmModel>> GetAllTruongbmsAsync();
        public Task<TruongbmModel> CheckTruongBomonByMaGVAsync(string maGV);
        public Task<TruongbmModel> GetTruongbmByIDAsync(int maTbm);
        public Task UpdateTruongbmsAsync(int maTbm, TruongbmModel model);

    }
}
