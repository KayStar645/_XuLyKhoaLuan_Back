using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class DotdkRepository : IDotdkRepository
    {
        Task<string> IDotdkRepository.AddDotdksAsync(DotdkModel model)
        {
            throw new NotImplementedException();
        }

        Task IDotdkRepository.DeleteDotdksAsync(DotdkModel dotDK)
        {
            throw new NotImplementedException();
        }

        Task<List<DotdkModel>> IDotdkRepository.GetAllDotdksAsync()
        {
            throw new NotImplementedException();
        }

        Task<DotdkModel> IDotdkRepository.GetDotdkByIDAsync(DotdkModel dotDK)
        {
            throw new NotImplementedException();
        }

        Task IDotdkRepository.UpdateDotdksAsync(DotdkModel dotDK, DotdkModel model)
        {
            throw new NotImplementedException();
        }
    }
}
