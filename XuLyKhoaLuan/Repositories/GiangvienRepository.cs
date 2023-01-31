
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class GiangvienRepository : IGiangvienRepository
    {
        Task<string> IGiangvienRepository.AddGiangviensAsync(GiangvienModel model)
        {
            throw new NotImplementedException();
        }

        Task IGiangvienRepository.DeleteGiangviensAsync(string ma)
        {
            throw new NotImplementedException();
        }

        Task<List<GiangvienModel>> IGiangvienRepository.GetAllGiangviensAsync()
        {
            throw new NotImplementedException();
        }

        Task<GiangvienModel> IGiangvienRepository.GetGiangvienByIDAsync(string ma)
        {
            throw new NotImplementedException();
        }

        Task IGiangvienRepository.UpdateGiangviensAsync(string ma, GiangvienModel model)
        {
            throw new NotImplementedException();
        }
    }
}
