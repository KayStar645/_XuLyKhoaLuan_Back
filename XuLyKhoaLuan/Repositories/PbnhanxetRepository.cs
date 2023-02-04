using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class PbnhanxetRepository : IPbnhanxetRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public PbnhanxetRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddPbnhanxetsAsync(PbnhanxetModel model)
        {
            var newPbnhanxet = _mapper.Map<Pbnhanxet>(model);
            _context.Pbnhanxets!.Add(newPbnhanxet);
            await _context.SaveChangesAsync();
            return newPbnhanxet.Id.ToString();
        }

        public async Task DeletePbnhanxetsAsync(int ma)
        {
            var deletePbnhanxet = _context.Pbnhanxets!.SingleOrDefault(
                pbNhanXet => pbNhanXet.Id == ma);
            if (deletePbnhanxet != null)
            {
                _context.Pbnhanxets!.Remove(deletePbnhanxet);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<PbnhanxetModel>> GetAllPbnhanxetsAsync()
        {
            var Pbnhanxets = await _context.Pbnhanxets.ToListAsync();
            return _mapper.Map<List<PbnhanxetModel>>(Pbnhanxets);
        }

        public async Task<PbnhanxetModel> GetPbnhanxetByIDAsync(int ma)
        {
            var Pbnhanxet = await _context.Pbnhanxets.FindAsync(ma);
            return _mapper.Map<PbnhanxetModel>(Pbnhanxet);
        }

        public async Task UpdatePbnhanxetsAsync(int ma, PbnhanxetModel model)
        {
            if (model.Id == ma)
            {
                var updatePbnhanxet = _mapper.Map<Pbnhanxet>(model);
                _context.Pbnhanxets.Update(updatePbnhanxet);
                await _context.SaveChangesAsync();
            }
        }
    }
}
