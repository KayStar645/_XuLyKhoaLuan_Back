using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public interface IBomonRepository
    {
        public Task<List<BomonModel>> GetAllBomonsAsync();
        public Task<BomonModel> GetBomonByIDAsync(string ma);
        public Task<string> AddBomonsAsync(BomonModel model);
        public Task UpdateBomonsAsync(string ma, BomonModel model);
        public Task DeleteBomonsAsync(string ma);
    }
}
