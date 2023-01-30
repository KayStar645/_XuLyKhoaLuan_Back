using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class SinhvienRepository : ISinhvienRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public SinhvienRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddSinhViensAsync(SinhvienModel model)
        {
            var newSinhVien = _mapper.Map<Sinhvien>(model);
            _context.Sinhviens!.Add(newSinhVien);
            await _context.SaveChangesAsync();
            return newSinhVien.MaSv;
        }

        public async Task DeleteSinhViensAsync(string ma)
        {
            var deleteSinhVien = _context.Sinhviens!.SingleOrDefault(dt => dt.MaSv.Equals(ma));
            if (deleteSinhVien != null)
            {
                _context.Sinhviens!.Remove(deleteSinhVien);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SinhvienModel>> GetAllSinhViensAsync()
        {
            var SinhViens = await _context.Sinhviens.ToListAsync();
            return _mapper.Map<List<SinhvienModel>>(SinhViens);
        }

        public async Task<SinhvienModel> GetSinhVienByIDAsync(string ma)
        {
            var SinhVien = await _context.Sinhviens.FindAsync(ma);
            return _mapper.Map<SinhvienModel>(SinhVien);
        }

        public async Task UpdateSinhViensAsync(string ma, SinhvienModel model)
        {
            if (ma.Equals(model.MaSv))
            {
                var updateSinhVien = _mapper.Map<Sinhvien>(model);
                _context.Sinhviens.Update(updateSinhVien);
                await _context.SaveChangesAsync();
            }
        }
    }
}
