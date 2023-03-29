using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IThamgiaRepository
    {
        public Task<List<ThamgiaModel>> GetAllThamgiasAsync();
        public Task<ThamgiaModel> GetThamgiaByIDAsync(string maSV, string namHoc, int dot);
        public Task<List<ThamgiaModel>> GetThamgiaByMacnAsync(string maCn);
        public Task<string> AddThamgiasAsync(ThamgiaModel model);
        public Task<List<ThamgiaModel>> SearchThamgiaByNameAsync(string name);
        public Task UpdateThamgiasAsync(ThamgiaModel thamGia, ThamgiaModel model);
        public Task DeleteThamgiasAsync(string maSV, string namHoc, int dot);
    }
}
