using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class ThamgiaRepository:IThamgiaRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public ThamgiaRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddThamgiasAsync(ThamgiaModel model)
        {
            var newThamgia = _mapper.Map<Thamgium>(model);
            _context.Thamgia!.Add(newThamgia);
            await _context.SaveChangesAsync();
            string returnString = newThamgia.MaSv + newThamgia.NamHoc + newThamgia.Dot;
            return returnString;
        }

        public async Task DeleteThamgiasAsync(string maSV, string namHoc, int dot)
        {
            var deleteThamgia = _context.Thamgia!.SingleOrDefault(
                thamGia => thamGia.NamHoc == namHoc && thamGia.MaSv == maSV
                && thamGia.Dot == dot);
            if (deleteThamgia != null)
            {
                _context.Thamgia!.Remove(deleteThamgia);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ThamgiaModel>> GetAllThamgiasAsync()
        {
            var Thamgias = await _context.Thamgia.ToListAsync();
            return _mapper.Map<List<ThamgiaModel>>(Thamgias);
        }

        public async Task<ThamgiaModel> GetThamgiaByIDAsync(string maSV, string namHoc, int dot)
        {
            var thamGia = await _context.Thamgia.FindAsync(maSV, namHoc, dot);
            return _mapper.Map<ThamgiaModel>(thamGia);
        }

        public async Task<List<ThamgiaModel>> GetThamgiaByMacnAsync(string maCn)
        {
            var thamGias = await _context.Thamgia
                .Join(_context.Sinhviens, t => t.MaSv, s => s.MaSv, (t, s) => new { t, s })
                .Join(_context.Chuyennganhs, x => x.s.MaCn, c => c.MaCn, (x, c) => new { x.t, c })
                .Where(x => x.c.MaCn == maCn)
                .Select(x => x.t)
                .ToListAsync();
            return _mapper.Map<List<ThamgiaModel>>(thamGias);
        }

        public async Task<List<ThamgiaModel>> SearchThamgiaByNameAsync(string name)
        {
            var sinhviens = await _context.Thamgia
                                    .Join(_context.Sinhviens, t => t.MaSv, s => s.MaSv, (t, s) => new { t = t, s = s })
                                    .Where(st => st.s.TenSv.Contains(name))
                                    .Select(st => st.t)
                                    .ToListAsync();
            return _mapper.Map<List<ThamgiaModel>>(sinhviens);
        }

        public async Task UpdateThamgiasAsync(ThamgiaModel Thamgia, ThamgiaModel model)
        {
            if (Thamgia.NamHoc == model.NamHoc && Thamgia.MaSv == model.MaSv && Thamgia.Dot == model.Dot)
            {
                var updateThamgia = _mapper.Map<Thamgium>(model);
                _context.Thamgia.Update(updateThamgia);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SinhvienModel>> GetSinhvienByNhomAsync(string maNhom, bool flag)
        {
            if(flag)
            {
                // Trả về trưởng nhóm
                var sinhVien = await _context.Sinhviens
                                .Join(_context.Thamgia, sv => sv.MaSv, tg => tg.MaSv, (sv, tg) => new { sv = sv, tg = tg })
                                .Where(re => re.tg.MaNhom == maNhom && re.tg.TruongNhom == true)
                                .Select(re => re.sv)
                                .ToListAsync();
                return _mapper.Map<List<SinhvienModel>>(sinhVien);
            }
            else
            {
                // Trả về thành viên cả nhóm
                var sinhViens = await _context.Sinhviens
                                .Join(_context.Thamgia, sv => sv.MaSv, tg => tg.MaSv, (sv, tg) => new { sv = sv, tg = tg })
                                .Where(re => re.tg.MaNhom == maNhom)
                                .Select(re => re.sv)
                                .ToListAsync();
                return _mapper.Map<List<SinhvienModel>>(sinhViens);
            }
        }

        public async Task<List<ThamgiaModel>> GetThamgiaByDotdk(string namHoc, int dot)
        {
            var Thamgias = await _context.Thamgia.Where(tg => tg.NamHoc == namHoc && tg.Dot == dot).ToListAsync();
            return _mapper.Map<List<ThamgiaModel>>(Thamgias);
        }

        public async Task<List<ThamgiaModel>> GetThamgiaByChuyennganhDotdk(string maCn, string namHoc, int dot)
        {
            var Thamgias = await _context.Thamgia
                        .Join(_context.Sinhviens, tg => tg.MaSv, sv => sv.MaSv, (tg, sv) => new { tg = tg, sv = sv })
                        .Where(re => re.tg.NamHoc == namHoc && re.tg.Dot == dot && re.sv.MaCn == maCn)
                        .Select(re => re.tg)
                        .ToListAsync();
            return _mapper.Map<List<ThamgiaModel>>(Thamgias);
        }
    }
}
