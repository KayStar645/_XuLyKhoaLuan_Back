using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.ComTypes;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class DetaiRepository : IDetaiRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public DetaiRepository(XuLyKhoaLuanContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddDeTaisAsync(DetaiModel model)
        {
            var newDeTai = _mapper.Map<Detai>(model);
            _context.Detais!.Add(newDeTai);
            await _context.SaveChangesAsync();
            return newDeTai.MaDt;
        }

        public async Task<string> createMaDT(string maKhoa)
        {
            string maxMaDT = await _context.Detais.MaxAsync(d => d.MaDt.Substring(d.MaDt.Length - 3));
            int maxMaDTNumber = (maxMaDT == null) ? 0 : Convert.ToInt32(maxMaDT) + 1;
            string maDT = maxMaDTNumber.ToString();
            while (maDT.Length < 6)
            {
                maDT = "0" + maDT;
            }
            return maKhoa + maDT;
        }

        public async Task DeleteDeTaisAsync(string maDT)
        {
            var deleteDeTai = _context.Detais!.SingleOrDefault(dt => dt.MaDt.Equals(maDT));
            if(deleteDeTai != null)
            {
                _context.Detais!.Remove(deleteDeTai);
                await _context.SaveChangesAsync();
            }    
        }

        public async Task<List<DetaiModel>> GetAllDeTaisAsync()
        {
            var deTais = await _context.Detais.ToListAsync();
            return _mapper.Map<List<DetaiModel>>(deTais);
        }

        public async Task<List<DetaiModel>> GetAllDeTaisByMakhoaAsync(string maKhoa)
        {
            var deTais = await _context.Detais
            .Join(_context.Rades, d => d.MaDt, r => r.MaDt, (d, r) => new { d = d, r = r })
            .Join(_context.Giangviens, rd => rd.r.MaGv, g => g.MaGv, (rd, g) => new { rd = rd, g = g })
            .Join(_context.Bomons, grd => grd.g.MaBm, b => b.MaBm, (grd, b) => new { grd = grd, b = b })
            .Join(_context.Khoas, grdb => grdb.b.MaKhoa, k => k.MaKhoa, (grdb, k) => new {grdb = grdb, k = k})
            .Where(grdbk => grdbk.k.MaKhoa == maKhoa)
            .Select(grdbk => grdbk.grdb.grd.rd.d)
            .ToListAsync();
            return _mapper.Map<List<DetaiModel>>(deTais);
        }

        public async Task<List<DetaiModel>> GetAllDeTaisByMaBomonAsync(string maBm)
        {
            var deTais = await _context.Detais
            .Join(_context.Rades, d => d.MaDt, r => r.MaDt, (d, r) => new { d = d, r = r })
            .Join(_context.Giangviens, rd => rd.r.MaGv, g => g.MaGv, (rd, g) => new { rd = rd, g = g })
            .Join(_context.Bomons, grd => grd.g.MaBm, b => b.MaBm, (grd, b) => new { grd = grd, b = b})
            .Where(grdb => grdb.b.MaBm == maBm)
            .Select(grdb => grdb.grd.rd.d)
            .ToListAsync();
            return _mapper.Map<List<DetaiModel>>(deTais);
        }

        public async Task<List<DetaiModel>> GetAllDeTaisByGiangvienAsync(string maGv)
        {
            var deTais = await _context.Detais
            .Join(_context.Rades, d => d.MaDt, r => r.MaDt, (d, r) => new {d = d, r = r})
            .Join(_context.Giangviens, rd => rd.r.MaGv, g => g.MaGv, (rd, g) => new {rd = rd, g = g})
            .Where(grd => grd.g.MaGv == maGv)
            .Select(grd => grd.rd.d)
            .ToListAsync();
            return _mapper.Map<List<DetaiModel>>(deTais);
        }

        public async Task<List<DetaiModel>> GetDeTaisByChuyennganhGiangvienAsync(string maCn, string maGv)
        {
            var deTais = await _context.Detais
            .Join(_context.Rades, d => d.MaDt, r => r.MaDt, (d, r) => new { d = d, r = r })
            .Join(_context.Giangviens, rd => rd.r.MaGv, g => g.MaGv, (rd, g) => new { rd = rd, g = g })
            .Join(_context.DetaiChuyennganhs, cn => cn.rd.d.MaDt, dtcn => dtcn.MaDt, (dtcn, cn) => new {dt = dtcn, cn = cn })
            .Where(grd => grd.dt.g.MaGv == maGv && grd.cn.MaCn == maCn)
            .Select(grd => grd.dt.rd.d)
            .ToListAsync();
            return _mapper.Map<List<DetaiModel>>(deTais);
        }

        public async Task<DetaiModel> GetDeTaiByIDAsync(string maDT)
        {
            var deTai = await _context.Detais.FindAsync(maDT);
            return _mapper.Map<DetaiModel>(deTai);

        }

        public async Task UpdateDeTaisAsync(string maDT, DetaiModel model)
        {
            if(maDT.Equals(model.MaDT))
            {
                var updateDeTai = _mapper.Map<Detai>(model);
                _context.Detais.Update(updateDeTai);
                await _context.SaveChangesAsync();
            }    
        }

        public async Task<List<DetaiModel>> GetDetaiByChuyenNganhAsync(string maCN)
        {
            var Detais = await (from dt in _context.Detais
                         join cn in _context.DetaiChuyennganhs on dt.MaDt equals cn.MaDt
                         where cn.MaCn.Equals(maCN)
                         select dt).ToListAsync();
            return _mapper.Map<List<DetaiModel>>(Detais);
        }
        public async Task<List<ChuyennganhModel>> GetChuyennganhOfDetaiAsync(string maDT)
        {
            var Chuyennganhs = await (from dt in _context.Detais
                                join cn in _context.Chuyennganhs on dt.MaDt equals cn.MaCn
                                where dt.MaDt.Equals(maDT)
                                select cn).ToListAsync();
            return _mapper.Map<List<ChuyennganhModel>>(Chuyennganhs);
        }
            
        public async Task<List<DetaiModel>> SearchDetaiByNameAsync(string name)
        {
            var Detais = await _context.Detais.Where(c => c.TenDt.Contains(name)).ToListAsync();
            return _mapper.Map <List<DetaiModel>>(Detais);
        }

        public async Task<bool> CheckisDetaiOfGiangvienAsync(string maDt, string maGv)
        {
            var isDtOfGv = await _context.Rades.AnyAsync(rd => rd.MaDt == maDt && rd.MaGv == maGv);
            return isDtOfGv;
        }

        public async Task<DetaiModel> GetDetaiByTendt(string tenDT)
        {
            var deTai = await _context.Detais.Where(dt => dt.TenDt == tenDT).SingleAsync();
            return _mapper.Map<DetaiModel>(deTai);
        }

    }
}
