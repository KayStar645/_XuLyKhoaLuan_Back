using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Interface
{
    public interface IRadeRepository
    {
        public Task<List<RadeModel>> GetAllRadesAsync();
        public Task<List<RadeModel>> GetRadeByMaGVMaDTAsync(string? maGV, string? maDT);
        public Task<string> AddRadesAsync(RadeModel model);
        public Task DeleteRadeAsync(RadeModel delete);
    }
}
