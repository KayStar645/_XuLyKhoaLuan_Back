using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface INhiemvuRepository
    {
        public Task<List<NhiemvuModel>> GetAllNhiemvusAsync();
        public Task<NhiemvuModel> GetNhiemvuByIDAsync(string ma);
        public Task<string> AddNhiemvusAsync(NhiemvuModel model);
        public Task UpdateNhiemvusAsync(string ma, NhiemvuModel model);
        public Task DeleteNhiemvusAsync(string ma);
    }
}
