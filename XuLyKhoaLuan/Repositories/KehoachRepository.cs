using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class KehoachRepository : IKehoachRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public KehoachRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddKehoachesAsync(KehoachModel model)
        {
            var newKehoach = _mapper.Map<Kehoach>(model);
            _context.Kehoaches!.Add(newKehoach);
            await _context.SaveChangesAsync();
            return newKehoach.MaKh.ToString();
        }

        public async Task DeleteKehoachesAsync(int ma)
        {
            var deleteKehoach = _context.Kehoaches!.SingleOrDefault(
                dKehoach => dKehoach.MaKh == ma);
            if (deleteKehoach != null)
            {
                _context.Kehoaches!.Remove(deleteKehoach);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<KehoachModel>> GetAllKehoachesAsync()
        {
            var Kehoaches = await _context.Kehoaches.ToListAsync();
            return _mapper.Map<List<KehoachModel>>(Kehoaches);
        }

        public async Task<KehoachModel> GetKehoachByIDAsync(int ma)
        {
            var keHoach = await _context.Kehoaches.FindAsync(ma);
            return _mapper.Map<KehoachModel>(keHoach);
        }

        public async Task UpdateKehoachesAsync(int ma, KehoachModel model)
        {
            if (model.MaKh == ma)
            {
                var updateKehoach = _mapper.Map<Kehoach>(model);
                _context.Kehoaches.Update(updateKehoach);
                await _context.SaveChangesAsync();
            }
        }
    }
}
