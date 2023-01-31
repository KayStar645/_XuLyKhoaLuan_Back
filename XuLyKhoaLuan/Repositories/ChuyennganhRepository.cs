using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class ChuyennganhRepository : IChuyennganhRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public ChuyennganhRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddChuyennganhsAsync(ChuyennganhModel model)
        {
            var newChuyennganh = _mapper.Map<Chuyennganh>(model);
            _context.Chuyennganhs!.Add(newChuyennganh);
            await _context.SaveChangesAsync();
            return newChuyennganh.MaCn;
        }

        public async Task DeleteChuyennganhsAsync(string ma)
        {
            var deleteChuyennganh = _context.Chuyennganhs!.SingleOrDefault(dt => dt.MaCn.Equals(ma));
            if (deleteChuyennganh != null)
            {
                _context.Chuyennganhs!.Remove(deleteChuyennganh);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ChuyennganhModel>> GetAllChuyennganhsAsync()
        {
            var Chuyennganhs = await _context.Chuyennganhs.ToListAsync();
            return _mapper.Map<List<ChuyennganhModel>>(Chuyennganhs);
        }

        public async Task<ChuyennganhModel> GetChuyennganhByIDAsync(string ma)
        {
            var Chuyennganh = await _context.Chuyennganhs.FindAsync(ma);
            return _mapper.Map<ChuyennganhModel>(Chuyennganh);
        }

        public async Task UpdateChuyennganhsAsync(string ma, ChuyennganhModel model)
        {
            if (ma.Equals(model.MaCn))
            {
                var updateChuyennganh = _mapper.Map<Chuyennganh>(model);
                _context.Chuyennganhs.Update(updateChuyennganh);
                await _context.SaveChangesAsync();
            }
        }
    }
}
