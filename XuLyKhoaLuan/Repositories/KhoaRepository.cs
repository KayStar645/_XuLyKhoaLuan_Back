using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class KhoaRepository : IKhoaRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public KhoaRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<string> AddKhoasAsync(KhoaModel model)
        {
            var newKhoa = _mapper.Map<Khoa>(model);
            _context.Khoas!.Add(newKhoa);
            await _context.SaveChangesAsync();
            return newKhoa.MaKhoa;
        }

        public async Task DeleteKhoasAsync(string ma)
        {
            var deleteKhoa = _context.Khoas!.SingleOrDefault(dt => dt.MaKhoa.Equals(ma));
            if (deleteKhoa != null)
            {
                _context.Khoas!.Remove(deleteKhoa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<KhoaModel>> GetAllKhoasAsync()
        {
            var Khoas = await _context.Khoas.ToListAsync();
            return _mapper.Map<List<KhoaModel>>(Khoas);
        }

        public async Task<KhoaModel> GetKhoaByIDAsync(string ma)
        {
            var Khoa = await _context.Khoas.FindAsync(ma);
            return _mapper.Map<KhoaModel>(Khoa);
        }

        public async Task UpdateKhoasAsync(string ma, KhoaModel model)
        {
            if (ma.Equals(model.MaKhoa))
            {
                var updateKhoa = _mapper.Map<Khoa>(model);
                _context.Khoas.Update(updateKhoa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
