using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Interface
{
    public interface IHoidongRepository
    {
        public Task<List<HoidongModel>> GetAllHoidongsAsync();
        public Task<HoidongModel> GetHoidongByIDAsync(string ma);
        public Task<string> AddHoidongsAsync(HoidongModel model);
        public Task UpdateHoidongsAsync(string ma, HoidongModel model);
        public Task DeleteHoidongsAsync(string ma);
        public Task<List<HoiDongVTModel>> GetHoidongsByBomonAsync(string maBm);
        public Task<List<HoiDongVTModel>> GetHoidongsByGiangvienAsync(string maGv);
        public Task<string> ThanhLapHoiDongAsync(HoiDongVT hoiDongVT);
    }
}
