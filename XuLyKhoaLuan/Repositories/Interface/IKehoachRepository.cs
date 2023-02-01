using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IKehoachRepository
    {
        public Task<List<HoidongModel>> GetAllHoidongsAsync();
        public Task<HoidongModel> GetHoidongByIDAsync(string ma);
        public Task<string> AddHoidongsAsync(string model);
        public Task UpdateHoidongsAsync(string ma, HoidongModel model);
        public Task DeleteHoidongsAsync(string ma);
    }
}
