using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

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

        public async Task<int> CountThanhVienNhomAsync(string ma)
        {
            var result = await _context.Nhoms.CountAsync(n => n.MaNhom == ma);
            return result;
        }

        public async Task<List<ThamgiaModel>> GetThanhVienNhomAsync(string ma)
        {
            var result = await _context.Thamgia.Where(t => t.MaNhom == ma).ToListAsync();
            return _mapper.Map<List<ThamgiaModel>>(result);
        }

        public async Task<NhomModel> GetNhomByMadtAsync(string maDT)
        {
            var nhom = await _context.Detais
                        .Join(_context.Dangkies, dt => dt.MaDt, dk => dk.MaDt, (dt, dk) => new { dt = dt, dk = dk })
                        .Join(_context.Nhoms, dtk => dtk.dk.MaNhom, n => n.MaNhom, (dtk, n) => new { dtk = dtk, n = n })
                        .Where(re => re.dtk.dt.MaDt == maDT)
                        .Select(re => re.n)
                        .SingleAsync();
            return _mapper.Map<NhomModel>(nhom);
        }

        public async Task<bool> isTruongNhomByMasvAsync(string maSV, string namHoc, int dot, string maNhom)
        {
            var isTruongnhom = await _context.Thamgia
                .AnyAsync(t => t.MaSv == maSV && t.NamHoc == namHoc && t.Dot == dot && t.MaNhom == maNhom);
            return isTruongnhom;
        }
    }
}
