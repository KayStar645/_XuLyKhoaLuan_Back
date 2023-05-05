using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IGiangvienRepository
    {
        public Task<List<GiangvienModel>> GetAllGiangviensAsync();
        public Task<GiangvienModel> GetGiangvienByIDAsync(string ma);
        public Task<List<GiangvienModel>> GetGiangvienByBoMonAsync(string maBM);
        public Task<List<GiangvienModel>> GetGiangvienByKhoaAsync(string maKhoa);
        public Task<List<GiangvienModel>> SearchGiangvienByNameAsync(string name, string maBm);
        public Task<string> AddGiangviensAsync(GiangvienModel model);
        public Task UpdateGiangviensAsync(string ma, GiangvienModel model);
        public Task DeleteGiangviensAsync(string ma);
        public Task<List<GiangvienModel>> search(string? maBm, string? tenGv);
        public Task<List<int>> GetSoLuongNhiemVuAsync(string maGv, string namHoc, int dot);
    }
}
