using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IPbnhanxetRepository
    {
        public Task<List<PbnhanxetModel>> GetAllPbnhanxetsAsync();
        public Task<PbnhanxetModel> GetPbnhanxetByIDAsync(int ma);
        public Task<string> AddPbnhanxetsAsync(PbnhanxetModel model);
        public Task UpdatePbnhanxetsAsync(int ma, PbnhanxetModel model);
        public Task DeletePbnhanxetsAsync(int ma);
    }
}
