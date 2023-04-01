using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class NhiemvuRepository:INhiemvuRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public NhiemvuRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddNhiemvusAsync(NhiemvuModel model)
        {
            var newNhiemvu = _mapper.Map<Nhiemvu>(model);
            _context.Nhiemvus!.Add(newNhiemvu);
            await _context.SaveChangesAsync();
            return newNhiemvu.MaNv.ToString();
        }

        public async Task DeleteNhiemvusAsync(int ma)
        {
            var deleteNhiemvu = _context.Nhiemvus!.SingleOrDefault(
                dNhiemvu => dNhiemvu.MaNv == ma);
            if (deleteNhiemvu != null)
            {
                _context.Nhiemvus!.Remove(deleteNhiemvu);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<NhiemvuModel>> GetAllNhiemvusAsync()
        {
            var Nhiemvus = await _context.Nhiemvus.OrderByDescending(n => n.ThoiGianKt).ToListAsync();
            return _mapper.Map<List<NhiemvuModel>>(Nhiemvus);
        }

        public async Task<NhiemvuModel> GetNhiemvuByIDAsync(int ma)
        {
            var hdgy = await _context.Nhiemvus.FindAsync(ma);
            return _mapper.Map<NhiemvuModel>(hdgy);
        }

        public async Task UpdateNhiemvusAsync(int ma, NhiemvuModel model)
        {
            if (model.MaNv == ma)
            {
                var updateNhiemvu = _mapper.Map<Nhiemvu>(model);
                _context.Nhiemvus.Update(updateNhiemvu);
                await _context.SaveChangesAsync();
            }
        }
    }
}
