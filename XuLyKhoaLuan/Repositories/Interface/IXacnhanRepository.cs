using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IXacnhanRepository
    {
        public Task<List<XacnhanModel>> GetAllXacnhansAsync();
        public Task<XacnhanModel> GetXacnhanByIDAsync(XacnhanModel xacNhan);
        public Task<string> AddXacnhansAsync(XacnhanModel model);
        public Task UpdateXacnhansAsync(XacnhanModel xacNhan, XacnhanModel model);
        public Task DeleteXacnhansAsync(XacnhanModel xacNhan);
    }
}
