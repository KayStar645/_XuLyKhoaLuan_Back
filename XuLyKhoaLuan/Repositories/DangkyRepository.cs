using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class DangkyRepository : IDangkyRepository
    {
        Task<string> IDangkyRepository.AddDangkysAsync(DangkyModel model)
        {
            throw new NotImplementedException();
        }

        Task IDangkyRepository.DeleteDangkysAsync(DangkyModel dk)
        {
            throw new NotImplementedException();
        }

        Task<List<DangkyModel>> IDangkyRepository.GetAllDangkysAsync()
        {
            throw new NotImplementedException();
        }

        Task<DangkyModel> IDangkyRepository.GetDangkyByIDAsync(DangkyModel dk)
        {
            throw new NotImplementedException();
        }

        Task IDangkyRepository.UpdateDangkysAsync(DangkyModel dk, DangkyModel model)
        {
            throw new NotImplementedException();
        }
    }
}
