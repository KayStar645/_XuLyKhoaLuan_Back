using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class CongviecRepository : ICongviecRepository
    {
        Task<string> ICongviecRepository.AddCongviecsAsync(CongviecModel model)
        {
            throw new NotImplementedException();
        }

        Task ICongviecRepository.DeleteCongviecsAsync(string maCV)
        {
            throw new NotImplementedException();
        }

        Task<List<CongviecModel>> ICongviecRepository.GetAllCongviecsAsync()
        {
            throw new NotImplementedException();
        }

        Task<CongviecModel> ICongviecRepository.GetCongviecByIDAsync(string maCV)
        {
            throw new NotImplementedException();
        }

        Task ICongviecRepository.UpdateCongviecsAsync(string maCV, CongviecModel model)
        {
            throw new NotImplementedException();
        }
    }
}
