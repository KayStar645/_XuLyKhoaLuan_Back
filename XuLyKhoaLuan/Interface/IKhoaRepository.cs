using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IKhoaRepository
    {
        public Task<List<KhoaModel>> GetAllKhoasAsync();
        public Task<KhoaModel> GetKhoaByIDAsync(string ma);
        public Task<string> AddKhoasAsync(KhoaModel model);
        public Task UpdateKhoasAsync(string ma, KhoaModel model);
        public Task DeleteKhoasAsync(string ma);
    }
}
