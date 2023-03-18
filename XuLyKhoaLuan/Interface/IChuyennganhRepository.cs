using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IChuyennganhRepository
    {
        public Task<List<ChuyennganhModel>> GetAllChuyennganhsAsync();
        public Task<ChuyennganhModel> GetChuyennganhByIDAsync(string ma);
        public Task<string> AddChuyennganhsAsync(ChuyennganhModel model);
        public Task UpdateChuyennganhsAsync(string ma, ChuyennganhModel model);
        public Task DeleteChuyennganhsAsync(string ma);
    }
}
