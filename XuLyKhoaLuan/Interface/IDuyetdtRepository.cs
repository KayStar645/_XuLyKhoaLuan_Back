using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IDuyetdtRepository
    {
        public Task<List<DuyetdtModel>> GetAllDuyetdtsAsync();
        public Task<DuyetdtModel> GetDuyetdtByIDAsync(DuyetdtModel duyetDT);
        public Task<string> AddDuyetdtsAsync(DuyetdtModel model);
        public Task UpdateDuyetdtsAsync(DuyetdtModel duyetDT, DuyetdtModel model);
        public Task DeleteDuyetdtsAsync(DuyetdtModel duyetDT);
        public Task<List<DuyetdtModel>> GetDuyetdtByMaDT(string maDt);
    }
}
