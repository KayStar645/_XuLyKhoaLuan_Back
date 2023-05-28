using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IHuongdanRepository
    {
        public Task<List<HuongdanModel>> GetAllHuongdansAsync();
        public Task<HuongdanModel> GetHuongdanByIDAsync(HuongdanModel hdpbNhanXet);
        public Task<string> AddHuongdansAsync(HuongdanModel model);
        public Task UpdateHuongdansAsync(HuongdanModel hdpbNhanXet, HuongdanModel model);
        public Task DeleteHuongdansAsync(HuongdanModel hdpbNhanXet);
        public Task<List<GiangvienModel>> GetGiangvienByDetaiAsync(string maDT);
        public Task<List<DetaiModel>> GetDetaiByGVHDDotdkAsync(string maGV, string namHoc, int dot);
        public Task<int> CountDetaiHuongDanByGiangVienAsync(string maGv);
        public Task<int> CheckThoiGianUpdateLich(string maGv, DateTime? start, DateTime? end);
    }
}
