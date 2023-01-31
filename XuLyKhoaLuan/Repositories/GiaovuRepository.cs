
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class GiaovuRepository : IGiaovuRepository
    {
        Task<string> IGiaovuRepository.AddGiaovusAsync(GiaovuModel model)
        {
            throw new NotImplementedException();
        }

        Task IGiaovuRepository.DeleteGiaovusAsync(string ma)
        {
            throw new NotImplementedException();
        }

        Task<List<GiaovuModel>> IGiaovuRepository.GetAllGiaovusAsync()
        {
            throw new NotImplementedException();
        }

        Task<GiaovuModel> IGiaovuRepository.GetGiaovuByIDAsync(string ma)
        {
            throw new NotImplementedException();
        }

        Task IGiaovuRepository.UpdateGiaovusAsync(string ma, GiaovuModel model)
        {
            throw new NotImplementedException();
        }
    }
}
