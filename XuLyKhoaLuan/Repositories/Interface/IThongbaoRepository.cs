using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IThongbaoRepository
    {
        public Task<List<ThongbaoModel>> GetAllThongbaosAsync();
        public Task<ThongbaoModel> GetThongbaoByIDAsync(string ma);
        public Task<string> AddThongbaosAsync(ThongbaoModel model);
        public Task UpdateThongbaosAsync(string ma, ThongbaoModel model);
        public Task DeleteThongbaosAsync(string ma);
    }
}
