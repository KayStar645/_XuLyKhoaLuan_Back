using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IPhanbienRepository
    {
        public Task<List<PhanbienModel>> GetAllPhanbiensAsync();
        public Task<PhanbienModel> GetPhanbienByIDAsync(PhanbienModel thamGia);
        public Task<string> AddPhanbiensAsync(PhanbienModel model);
        public Task UpdatePhanbiensAsync(PhanbienModel thamGia, PhanbienModel model);
        public Task DeletePhanbiensAsync(PhanbienModel thamGia);
        public Task<List<GiangvienModel>> GetGiangvienByDetaiAsync(string maDT);
    }
}
