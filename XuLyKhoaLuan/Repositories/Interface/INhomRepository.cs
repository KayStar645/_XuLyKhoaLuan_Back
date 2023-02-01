using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface INhomRepository
    {
        public Task<List<NhomModel>> GetAllNhomsAsync();
        public Task<NhomModel> GetNhomByIDAsync(int ma);
        public Task<string> AddNhomsAsync(NhomModel model);
        public Task UpdateNhomsAsync(int ma, NhomModel model);
        public Task DeleteNhomsAsync(int ma);
    }
}
