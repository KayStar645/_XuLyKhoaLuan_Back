using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Interface.NghiepVu
{
    public interface IDeTaiDiemRepo
    {
        public Task<List<DeTaiDiemVTModel>> GetDanhSachDiemByGv(string maGv);
    }
}
