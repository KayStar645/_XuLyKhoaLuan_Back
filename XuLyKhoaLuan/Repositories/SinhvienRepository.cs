using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
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

        public async Task<List<SinhvienModel>> GetSinhvienByChuyenNganhAsync(string maCN)
        {
            var Sinhviens = await _context.Sinhviens.Where(c => c.MaCn.Equals(maCN)).ToListAsync();
            return _mapper.Map<List<SinhvienModel>>(Sinhviens);
        }

        public async Task<List<SinhvienModel>> GetSinhvienByKhoaAsync(string maKhoa)
        {
            var sinhViens = await _context.Sinhviens
                .Join(_context.Chuyennganhs, s => s.MaCn, c => c.MaCn, (s, c) => new { sv = s, cn = c })
                .Join(_context.Khoas, sc => sc.cn.MaKhoa, k => k.MaKhoa, (sc, k) => new { sv = sc.sv, Khoa = k })
                .Where(sc => sc.Khoa.MaKhoa == maKhoa)
                .Select(sc => sc.sv).ToListAsync();

            return _mapper.Map<List<SinhvienModel>>(sinhViens);
        }

        public async Task<List<SinhvienModel>> GetSinhvienByDotDkAsync(string namHoc, int dot, bool flag)
        {
            if(flag)
            {
                var sinhViens = await _context.Sinhviens
                .Join(_context.Thamgia, s => s.MaSv, tg => tg.MaSv, (s, tg) => new { Sinhvien = s, Thamgia = tg })
                .Where(st => st.Thamgia.NamHoc == namHoc && st.Thamgia.Dot == dot)
                .Select(st => st.Sinhvien)
                .ToListAsync();
                return _mapper.Map<List<SinhvienModel>>(sinhViens);
            }            
            else
            {
                var sinhViens = await _context.Sinhviens
                    .Join(_context.Thamgia, s => s.MaSv, tg => tg.MaSv, (s, tg) => new { s = s, tg = tg })
                    .Where(st => st.tg.NamHoc != namHoc || st.tg.Dot != dot)
                    .Select(st => st.s)
                    .ToListAsync();
                return _mapper.Map<List<SinhvienModel>>(sinhViens);
            }
        }

        public async Task<List<SinhvienModel>> SearchSinhvienByNameAsync(string name)
        {
            var Sinhviens = await _context.Sinhviens.Where(c => c.TenSv.Contains(name)).ToListAsync();
            return _mapper.Map<List<SinhvienModel>>(Sinhviens);
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
