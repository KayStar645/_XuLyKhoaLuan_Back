using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public interface ISinhvienRepository
    {
        public Task<List<SinhvienModel>> GetAllSinhViensAsync();
        public Task<SinhvienModel> GetSinhVienByIDAsync(string ma);
        public Task<string> AddSinhViensAsync(SinhvienModel model);
        public Task UpdateSinhViensAsync(string ma, SinhvienModel model);
        public Task DeleteSinhViensAsync(string ma);
    }
}
