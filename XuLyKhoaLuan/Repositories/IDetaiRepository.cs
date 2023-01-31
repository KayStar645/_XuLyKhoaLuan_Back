using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public interface IDetaiRepository
    {
        public Task<List<DetaiModel>> GetAllDeTaisAsync();
        public Task<DetaiModel> GetDeTaiByIDAsync(string maDT);
        public Task<string> AddDeTaisAsync(DetaiModel model);
        public Task UpdateDeTaisAsync(string maDT, DetaiModel model);
        public Task DeleteDeTaisAsync(string maDT);
    }
}
