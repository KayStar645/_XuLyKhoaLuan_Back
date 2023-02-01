using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IPbnhanxetRepository
    {
        public Task<List<PbnhanxetModel>> GetAllPbnhanxetsAsync();
        public Task<PbnhanxetModel> GetPbnhanxetByIDAsync(string ma);
        public Task<string> AddPbnhanxetsAsync(PbnhanxetModel model);
        public Task UpdatePbnhanxetsAsync(string ma, PbnhanxetModel model);
        public Task DeletePbnhanxetsAsync(string ma);
    }
}
