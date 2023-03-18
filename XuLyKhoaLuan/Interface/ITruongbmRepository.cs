using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface ITruongbmRepository
    {
        public Task<List<TruongbmModel>> GetAllTruongbmsAsync();
        public Task<TruongbmModel> GetTruongbmByIDAsync(TruongbmModel truongBM);
        public Task<TruongbmModel> GetTruongbmByMaGVAsync(string maGV);
        public Task<string> AddTruongbmsAsync(TruongbmModel model);
        public Task UpdateTruongbmsAsync(TruongbmModel truongBM, TruongbmModel model);
        public Task DeleteTruongbmsAsync(TruongbmModel truongBM);

        //public Task<bool> CheckTruongbmsNghiAsync(TruongbmModel truongBM);
    }
}
