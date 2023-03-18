using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IThongbaoRepository
    {
        public Task<List<ThongbaoModel>> GetAllThongbaosAsync();
        public Task<ThongbaoModel> GetThongbaoByIDAsync(int ma);
        public Task<string> AddThongbaosAsync(ThongbaoModel model);
        public Task UpdateThongbaosAsync(int ma, ThongbaoModel model);
        public Task DeleteThongbaosAsync(int ma);
    }
}
