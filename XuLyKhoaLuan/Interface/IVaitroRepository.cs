using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IVaitroRepository
    {
        public Task<List<VaitroModel>> GetAllVaitrosAsync();
        public Task<VaitroModel> GetVaitroByIDAsync(string vaiTro);
        public Task<string> AddVaitrosAsync(VaitroModel model);
        public Task UpdateVaitrosAsync(string vaiTro, VaitroModel model);
        public Task DeleteVaitrosAsync(string vaiTro);
    }
}
