using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class BinhluanRepository : IBinhluanRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public BinhluanRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddBinhluansAsync(BinhluanModel model)
        {
            var newBinhluan = _mapper.Map<Binhluan>(model);
            _context.Binhluans!.Add(newBinhluan);
            await _context.SaveChangesAsync();
            return newBinhluan.Id.ToString();
        }

        public async Task DeleteBinhluansAsync(int maBL)
        {
            var deleteBinhluan = _context.Binhluans!.SingleOrDefault(dt => dt.Id == maBL);
            if (deleteBinhluan != null)
            {
                _context.Binhluans!.Remove(deleteBinhluan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<BinhluanModel>> GetAllBinhluansAsync()
        {
            var Binhluans = await _context.Binhluans.ToListAsync();
            return _mapper.Map<List<BinhluanModel>>(Binhluans);
        }

        public async Task<BinhluanModel> GetBinhluanByIDAsync(int maBL)
        {
            var Binhluan = await _context.Binhluans.FindAsync(maBL);
            return _mapper.Map<BinhluanModel>(Binhluan);

        }

        public async Task UpdateBinhluansAsync(int maBL, BinhluanModel model)
        {
            if (maBL == model.Id)
            {
                var updateBinhluan = _mapper.Map<Binhluan>(model);
                _context.Binhluans.Update(updateBinhluan);
                await _context.SaveChangesAsync();
            }
        }
    }
}
