using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class NhomRepository:INhomRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public NhomRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddNhomsAsync(NhomModel model)
        {
            var newNhom = _mapper.Map<Nhom>(model);
            _context.Nhoms!.Add(newNhom);
            await _context.SaveChangesAsync();
            return newNhom.MaNhom.ToString();
        }

        public async Task DeleteNhomsAsync(string ma)
        {
            var deleteNhom = _context.Nhoms!.SingleOrDefault(
                dNhom => dNhom.MaNhom == ma);
            if (deleteNhom != null)
            {
                _context.Nhoms!.Remove(deleteNhom);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<NhomModel>> GetAllNhomsAsync()
        {
            var Nhoms = await _context.Nhoms.ToListAsync();
            return _mapper.Map<List<NhomModel>>(Nhoms);
        }

        public async Task<NhomModel> GetNhomByIDAsync(string ma)
        {
            var nhom = await _context.Nhoms.FindAsync(ma);
            return _mapper.Map<NhomModel>(nhom);
        }

        public async Task UpdateNhomsAsync(string ma, NhomModel model)
        {
            if (model.MaNhom == ma)
            {
                var updateNhom = _mapper.Map<Nhom>(model);
                _context.Nhoms.Update(updateNhom);
                await _context.SaveChangesAsync();
            }
        }
    }
}
