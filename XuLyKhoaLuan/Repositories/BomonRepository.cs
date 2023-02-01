using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class BomonRepository : IBomonRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public BomonRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddBomonsAsync(BomonModel model)
        {
            var newBomon = _mapper.Map<Bomon>(model);
            _context.Bomons!.Add(newBomon);
            await _context.SaveChangesAsync();
            return newBomon.MaBm;
        }

        public async Task DeleteBomonsAsync(string maBM)
        {
            var deleteBomon = _context.Bomons!.SingleOrDefault(dt => dt.MaBm.Equals(maBM));
            if (deleteBomon != null)
            {
                _context.Bomons!.Remove(deleteBomon);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<BomonModel>> GetAllBomonsAsync()
        {
            var Bomons = await _context.Bomons.ToListAsync();
            return _mapper.Map<List<BomonModel>>(Bomons);
        }

        public async Task<BomonModel> GetBomonByIDAsync(string maBM)
        {
            var Bomon = await _context.Bomons.FindAsync(maBM);
            return _mapper.Map<BomonModel>(Bomon);

        }

        public async Task UpdateBomonsAsync(string maBM, BomonModel model)
        {
            if (maBM.Equals(model.MaBm))
            {
                var updateBomon = _mapper.Map<Bomon>(model);
                _context.Bomons.Update(updateBomon);
                await _context.SaveChangesAsync();
            }
        }
    }
}
