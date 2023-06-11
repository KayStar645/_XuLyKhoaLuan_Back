using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IGapMatHdRepository
    {
        public Task<string> AddGapMatAsync(GapMatHdModel model);
        public Task UpdateGapMatAsync(int id, GapMatHdModel model);
        //public Task DeleteThongbaosAsync(int ma);
    }
}
