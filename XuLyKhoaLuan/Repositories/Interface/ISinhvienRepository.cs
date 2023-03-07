using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface ISinhvienRepository
    {
        public Task<List<SinhvienModel>> GetAllSinhViensAsync();
        public Task<SinhvienModel> GetSinhVienByIDAsync(string ma);
        public Task<List<SinhvienModel>> GetSinhvienByChuyenNganhAsync(string maCN);
        public Task<List<SinhvienModel>> SearchSinhvienByNameAsync(string name);
        public Task<string> AddSinhViensAsync(SinhvienModel model);
        public Task UpdateSinhViensAsync(string ma, SinhvienModel model);
        public Task DeleteSinhViensAsync(string ma);
    }
}
