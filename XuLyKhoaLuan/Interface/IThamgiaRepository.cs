using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Interface
{
    public interface IThamgiaRepository
    {
        public Task<List<ThamgiaModel>> GetAllThamgiasAsync();
        public Task<List<ThamgiaModel>> GetAllThamgiaDotdkNotmesAsync(string maSV, string namHoc, int dot);
        public Task<ThamgiaModel> GetThamgiaByIDAsync(string maSV, string namHoc, int dot);
        public Task<List<ThamgiaModel>> GetThamgiaByMacnAsync(string maCn);
        public Task<string> AddThamgiasAsync(ThamgiaModel model);
        public Task<List<ThamgiaModel>> SearchThamgiaByNameAsync(string name);
        public Task UpdateThamgiasAsync(ThamgiaModel thamGia, ThamgiaModel model);
        public Task DeleteThamgiasAsync(string maSV, string namHoc, int dot);
        public Task<List<SinhvienModel>> GetSinhvienByNhomAsync(string maNhom, bool flag);
        public Task<List<ThamgiaModel>> GetThamgiaByDotdk(string namHoc, int dot);
        public Task<List<ThamgiaModel>> GetThamgiaByChuyennganhDotdk(string maCn, string namHoc, int dot);
        public Task<List<ThamgiaModel>> Search(string? tenSv, string? maCn, string? namHoc, int? dot);
        public Task<List<ThamGiaVTModel>> GetAllThamgiaInfDotdkNotmesAsync(string maSv, string namHoc, int dot);
        public Task<List<SinhVienVTModel>> SearchInfo(string? search, string? maCn, bool isAdd, string? namHoc, int? dot = 0);
    }
}
