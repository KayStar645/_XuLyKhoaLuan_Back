using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface ILoimoiRepository
    {
        public Task<List<LoimoiModel>> GetAllLoimoisAsync();
        public Task<LoimoiModel> GetLoimoiByIDAsync(LoimoiModel loiMoi);
        public Task<string> AddLoimoisAsync(LoimoiModel model);
        public Task UpdateLoimoisAsync(LoimoiModel loiMoi, LoimoiModel model);
        public Task DeleteLoimoisAsync(LoimoiModel loiMoi);
    }
}
