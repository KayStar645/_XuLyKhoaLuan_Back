using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface INhiemvuRepository
    {
        public Task<List<NhiemvuModel>> GetAllNhiemvusAsync();
        public Task<NhiemvuModel> GetNhiemvuByIDAsync(int ma);
        public Task<string> AddNhiemvusAsync(NhiemvuModel model);
        public Task UpdateNhiemvusAsync(int ma, NhiemvuModel model);
        public Task DeleteNhiemvusAsync(int ma);
    }
}
