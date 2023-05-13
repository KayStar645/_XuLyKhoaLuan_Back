using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Interface.NghiepVu
{
    public interface ILichPhanBienRepo
    {
        public Task<List<LichPhanBienVTModel>> GetLichPhanBienByGvAsync(string maGv);
        public Task<List<LichPhanBienVTModel>> GetLichPhanBienBySvAsync(string maSv);
        public Task<List<DetaiModel>> GetSelectDetaiByGiangVienAsync(string maGv, string namHoc, int dot, int loaiLich);
    }
}
