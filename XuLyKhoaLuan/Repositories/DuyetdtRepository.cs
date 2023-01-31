using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class DuyetdtRepository : IDuyetdtRepository
    {
        Task<string> IDuyetdtRepository.AddDuyetdtsAsync(DuyetdtModel model)
        {
            throw new NotImplementedException();
        }

        Task IDuyetdtRepository.DeleteDuyetdtsAsync(DuyetdtModel duyetDT)
        {
            throw new NotImplementedException();
        }

        Task<List<DuyetdtModel>> IDuyetdtRepository.GetAllDuyetdtsAsync()
        {
            throw new NotImplementedException();
        }

        Task<DuyetdtModel> IDuyetdtRepository.GetDuyetdtByIDAsync(DuyetdtModel duyetDT)
        {
            throw new NotImplementedException();
        }

        Task IDuyetdtRepository.UpdateDuyetdtsAsync(DuyetdtModel duyetDT, DuyetdtModel model)
        {
            throw new NotImplementedException();
        }
    }
}
