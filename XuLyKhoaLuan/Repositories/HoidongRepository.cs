using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class HoidongRepository : IHoidongRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public HoidongRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddHoidongsAsync(HoidongModel model)
        {
            var newHoidong = _mapper.Map<Hoidong>(model);
            _context.Hoidongs!.Add(newHoidong);
            await _context.SaveChangesAsync();
            return newHoidong.MaHd;
        }

        public async Task DeleteHoidongsAsync(string MaHd)
        {
            var deleteHoidong = _context.Hoidongs!.SingleOrDefault(dt => dt.MaHd.Equals(MaHd));
            if (deleteHoidong != null)
            {
                _context.Hoidongs!.Remove(deleteHoidong);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<HoidongModel>> GetAllHoidongsAsync()
        {
            var Hoidongs = await _context.Hoidongs.ToListAsync();
            return _mapper.Map<List<HoidongModel>>(Hoidongs);
        }

        public async Task<HoidongModel> GetHoidongByIDAsync(string MaHd)
        {
            var Hoidong = await _context.Hoidongs.FindAsync(MaHd);
            return _mapper.Map<HoidongModel>(Hoidong);

        }

        public async Task UpdateHoidongsAsync(string MaHd, HoidongModel model)
        {
            if (MaHd.Equals(model.MaHd))
            {
                var updateHoidong = _mapper.Map<Hoidong>(model);
                _context.Hoidongs.Update(updateHoidong);
                await _context.SaveChangesAsync();
            }
        }
    }
}
