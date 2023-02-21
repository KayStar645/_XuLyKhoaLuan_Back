using Microsoft.AspNetCore.Identity;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SigUpAsync(SigUpModel model);
        public Task<string> SigInAsync(SigInModel model);
    }
}
