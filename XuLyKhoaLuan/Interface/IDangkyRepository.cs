using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IDangkyRepository
    {
        public Task<List<DangkyModel>> GetAllDangkiesAsync();
        public Task<DangkyModel> GetDangkyByIDAsync(DangkyModel dk);
        public Task<string> AddDangkiesAsync(DangkyModel model);
        public Task UpdateDangkiesAsync(DangkyModel dk, DangkyModel model);
        public Task DeleteDangkiesAsync(DangkyModel dk);
        public Task<List<DetaiModel>> GetAllDetaiDangkyAsync(string namHoc, int dot, string maNhom);
        public Task<bool> isNhomDangkyDetaiAsyc(string maNhom);
        public Task<DetaiModel> GetDetaiDangkyAsync(string maNhom, string namHoc, int dot);
    }
}
