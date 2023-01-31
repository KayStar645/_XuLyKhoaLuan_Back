using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public interface IDuyetdtRepository
    {
        public Task<List<DuyetdtModel>> GetAllDuyetdtsAsync();
        public Task<DuyetdtModel> GetDuyetdtByIDAsync(DuyetdtModel duyetDT);
        public Task<string> AddDuyetdtsAsync(DuyetdtModel model);
        public Task UpdateDuyetdtsAsync(DuyetdtModel duyetDT, DuyetdtModel model);
        public Task DeleteDuyetdtsAsync(DuyetdtModel duyetDT);
    }
}
