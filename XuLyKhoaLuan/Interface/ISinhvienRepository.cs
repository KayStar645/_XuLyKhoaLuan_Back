using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface ISinhvienRepository
    {
        public Task<List<SinhvienModel>> GetAllSinhViensAsync();
        public Task<SinhvienModel> GetSinhVienByIDAsync(string ma);
        public Task<List<SinhvienModel>> GetSinhvienByChuyenNganhAsync(string maCN);
        public Task<List<SinhvienModel>> GetSinhvienByKhoaAsync(string maKhoa);
        public Task<List<SinhvienModel>> GetSinhvienByDotDkAsync(string namHoc, int dot);
        public Task<List<SinhvienModel>> SearchSinhvienByNameAsync(string name);
        public Task<string> AddSinhViensAsync(SinhvienModel model);
        public Task UpdateSinhViensAsync(string ma, SinhvienModel model);
        public Task DeleteSinhViensAsync(string ma);
    }
}
