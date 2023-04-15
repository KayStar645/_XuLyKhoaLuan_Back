using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface INhomRepository
    {
        public Task<List<NhomModel>> GetAllNhomsAsync();
        public Task<NhomModel> GetNhomByIDAsync(string ma);
        public Task<string> AddNhomsAsync(NhomModel model);
        public Task UpdateNhomsAsync(string ma, NhomModel model);
        public Task DeleteNhomsAsync(string ma);
        public Task<int> CountThanhVienNhomAsync(string ma);
        public Task<List<ThamgiaModel>> GetThanhVienNhomAsync(string ma);
        public Task<NhomModel> GetNhomByMadtAsync(string maDT);
        public Task<bool> isTruongNhomByMasvAsync(string maSV, string namHoc, int dot, string maNhom);
    }
}
