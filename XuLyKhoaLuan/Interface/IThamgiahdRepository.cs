using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IThamgiahdRepository
    {
        public Task<List<ThamgiahdModel>> GetAllThamgiahdsAsync();
        public Task<ThamgiahdModel> GetThamgiahdByIDAsync(ThamgiahdModel thamGia);
        public Task<string> AddThamgiahdsAsync(ThamgiahdModel model);
        public Task UpdateThamgiahdsAsync(ThamgiahdModel thamGia, ThamgiahdModel model);
        public Task DeleteThamgiahdsAsync(ThamgiahdModel thamGia);
    }
}
