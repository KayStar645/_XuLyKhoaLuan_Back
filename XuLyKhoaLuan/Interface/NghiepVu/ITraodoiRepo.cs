using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Interface.TraoDoi
{

    public interface ITraodoiRepo
    {
        public Task<List<TraodoiModel>> GetAllTraoDoiMotCongViec(string maCv);
    }
}
