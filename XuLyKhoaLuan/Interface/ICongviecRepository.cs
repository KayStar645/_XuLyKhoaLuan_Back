using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface ICongviecRepository
    {
        public Task<List<CongviecModel>> GetAllCongviecsAsync();
        public Task<CongviecModel> GetCongviecByIDAsync(string maCV);
        public Task<string> AddCongviecsAsync(CongviecModel model);
        public Task UpdateCongviecsAsync(string maCV, CongviecModel model);
        public Task DeleteCongviecsAsync(string maCV);
    }
}
