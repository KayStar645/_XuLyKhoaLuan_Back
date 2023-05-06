using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Interface.NghiepVu
{
    public interface ILichPhanBienRepo
    {
        public Task<List<LichPhanBienVTModel>> GetLichPhanBienByGvAsync(string maGv);
    }
}
