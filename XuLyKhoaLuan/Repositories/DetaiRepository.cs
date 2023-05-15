using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.ComTypes;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Models.VirtualModel;
using System.Linq;
using System.Threading.Tasks;

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
            int maxMaDTNumber = (maxMaDT == null) ? 1 : Convert.ToInt32(maxMaDT) + 1;
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

        public async Task<List<DetaiModel>> GetAllDeTaisByMakhoaAsync(string maKhoa, int trangThaiDT)
        {
            if(trangThaiDT == -1)
            {
                // Lấy tất cả đề tài của khoa
                var deTais = await _context.Detais
                    .Join(_context.Rades, d => d.MaDt, r => r.MaDt, (d, r) => new { d = d, r = r })
                    .Join(_context.Giangviens, rd => rd.r.MaGv, g => g.MaGv, (rd, g) => new { rd = rd, g = g })
                    .Join(_context.Bomons, grd => grd.g.MaBm, b => b.MaBm, (grd, b) => new { grd = grd, b = b })
                    .Join(_context.Khoas, grdb => grdb.b.MaKhoa, k => k.MaKhoa, (grdb, k) => new { grdb = grdb, k = k })
                    .Where(grdbk => grdbk.k.MaKhoa == maKhoa)
                    .Select(grdbk => grdbk.grdb.grd.rd.d)
                    .ToListAsync();
                return _mapper.Map<List<DetaiModel>>(deTais);
            }
            else if(trangThaiDT == 1)
            {
                // Lấy tất cả đề tài của khoa đạt yêu cầu
                var deTais = await _context.Detais
                    .Join(_context.Rades, d => d.MaDt, r => r.MaDt, (d, r) => new { d = d, r = r })
                    .Join(_context.Giangviens, rd => rd.r.MaGv, g => g.MaGv, (rd, g) => new { rd = rd, g = g })
                    .Join(_context.Bomons, grd => grd.g.MaBm, b => b.MaBm, (grd, b) => new { grd = grd, b = b })
                    .Join(_context.Khoas, grdb => grdb.b.MaKhoa, k => k.MaKhoa, (grdb, k) => new { grdb = grdb, k = k })
                    .Where(grdbk => grdbk.k.MaKhoa == maKhoa && grdbk.grdb.grd.rd.d.TrangThai == true)
                    .Select(grdbk => grdbk.grdb.grd.rd.d)
                    .ToListAsync();
                return _mapper.Map<List<DetaiModel>>(deTais);
            }
            else
            {
                // Lấy tất cả đề tài của khoa chưa đạt yêu cầu
                var deTais = await _context.Detais
                    .Join(_context.Rades, d => d.MaDt, r => r.MaDt, (d, r) => new { d = d, r = r })
                    .Join(_context.Giangviens, rd => rd.r.MaGv, g => g.MaGv, (rd, g) => new { rd = rd, g = g })
                    .Join(_context.Bomons, grd => grd.g.MaBm, b => b.MaBm, (grd, b) => new { grd = grd, b = b })
                    .Join(_context.Khoas, grdb => grdb.b.MaKhoa, k => k.MaKhoa, (grdb, k) => new { grdb = grdb, k = k })
                    .Where(grdbk => grdbk.k.MaKhoa == maKhoa && grdbk.grdb.grd.rd.d.TrangThai == false)
                    .Select(grdbk => grdbk.grdb.grd.rd.d)
                    .ToListAsync();
                return _mapper.Map<List<DetaiModel>>(deTais);
            }
        }

        public async Task<List<DetaiModel>> GetAllDeTaisByMaBomonAsync(string maBm, bool flag)
        {
            if(flag)
            {
                // Chỉ lấy đề tài đạt yêu cầu
                var deTais = await _context.Detais
                .Join(_context.Rades, d => d.MaDt, r => r.MaDt, (d, r) => new { d = d, r = r })
                .Join(_context.Giangviens, rd => rd.r.MaGv, g => g.MaGv, (rd, g) => new { rd = rd, g = g })
                .Join(_context.Bomons, grd => grd.g.MaBm, b => b.MaBm, (grd, b) => new { grd = grd, b = b })
                .Where(grdb => grdb.b.MaBm == maBm && grdb.grd.rd.d.TrangThai == true)
                .Select(grdb => grdb.grd.rd.d)
                .ToListAsync();
                return _mapper.Map<List<DetaiModel>>(deTais);
            }
            else
            {
                // Lấy hết đề tài
                var deTais = await _context.Detais
                .Join(_context.Rades, d => d.MaDt, r => r.MaDt, (d, r) => new { d = d, r = r })
                .Join(_context.Giangviens, rd => rd.r.MaGv, g => g.MaGv, (rd, g) => new { rd = rd, g = g })
                .Join(_context.Bomons, grd => grd.g.MaBm, b => b.MaBm, (grd, b) => new { grd = grd, b = b })
                .Where(grdb => grdb.b.MaBm == maBm)
                .Select(grdb => grdb.grd.rd.d)
                .ToListAsync();
                return _mapper.Map<List<DetaiModel>>(deTais);
            }
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

        public async Task<List<DetaiModel>> GetDetaiByChuyenNganhBomonAsync(string maCN, string maBM)
        {
            var deTais = await _context.Detais
                        .Join(_context.DetaiChuyennganhs, dt => dt.MaDt, cn => cn.MaDt, (dt, cn) => new { dt = dt, cn = cn })
                        .Join(_context.Rades, dc => dc.dt.MaDt, rd => rd.MaDt, (dc, rd) => new { dc = dc, rd = rd })
                        .Join(_context.Giangviens, dcr => dcr.rd.MaGv, gv => gv.MaGv, (dcr, gv) => new { dcr = dcr, gv = gv })
                        .Where(re => re.dcr.dc.cn.MaCn == maCN && re.gv.MaBm == maBM)
                        .Select(re => re.dcr.dc.dt)
                        .ToListAsync();            
            return _mapper.Map<List<DetaiModel>>(deTais);
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

        public async Task<List<DetaiModel>> GetDetaiByDotdk(string namHoc, int dot)
        {
            var deTais = await _context.Detais.Where(dt => dt.NamHoc == namHoc && dt.Dot == dot).ToListAsync();
            return _mapper.Map<List<DetaiModel>>(deTais);
        }

        public async Task<List<DetaiModel>> GetDetaiByBomonDotdk(string maBM, string namHoc, int dot, bool flag)
        {
            if(flag)
            {
                var deTais = await _context.Detais
                            .Join(_context.Rades, dt => dt.MaDt, rd => rd.MaDt, (dt, rd) => new { dt = dt, rd = rd })
                            .Join(_context.Giangviens, rdt => rdt.rd.MaGv, gv => gv.MaGv, (rdt, gv) => new { rdt = rdt, gv = gv })
                            .Where(re => re.rdt.dt.NamHoc == namHoc && re.rdt.dt.Dot == dot && re.gv.MaBm == maBM && re.rdt.dt.TrangThai == true)
                            .Select(re => re.rdt.dt)
                            .ToListAsync();
                return _mapper.Map<List<DetaiModel>>(deTais);
            }
            else
            {
                var deTais = await _context.Detais
                            .Join(_context.Rades, dt => dt.MaDt, rd => rd.MaDt, (dt, rd) => new { dt = dt, rd = rd })
                            .Join(_context.Giangviens, rdt => rdt.rd.MaGv, gv => gv.MaGv, (rdt, gv) => new { rdt = rdt, gv = gv })
                            .Where(re => re.rdt.dt.NamHoc == namHoc && re.rdt.dt.Dot == dot && re.gv.MaBm == maBM)
                            .Select(re => re.rdt.dt)
                            .ToListAsync();
                return _mapper.Map<List<DetaiModel>>(deTais);
            }
        }

        public async Task<List<DetaiModel>> GetDetaiByHuongdanOfGiangvienDotdkAsync(string maGv, string namHoc, int dot)
        {
            var deTaiHds = await _context.Detais
                        .Join(_context.Huongdans, dt => dt.MaDt, hd => hd.MaDt, (dt, hd) => new { hd = hd, dt = dt })
                        .Where(re => re.hd.MaGv == maGv && re.dt.NamHoc == namHoc && re.dt.Dot == dot)
                        .Select(re => re.dt)
                        .ToListAsync();
            return _mapper.Map<List<DetaiModel>>(deTaiHds);
        }

        public async Task<List<DetaiModel>> GetDetaiByPhanbienOfGiangvienDotdkAsync(string maGv, string namHoc, int dot)
        {
            var deTaiPbs = await _context.Detais
                        .Join(_context.Phanbiens, dt => dt.MaDt, pb => pb.MaDt, (dt, pb) => new { dt = dt, pb = pb })
                        .Where(re => re.pb.MaGv == maGv && re.dt.NamHoc == namHoc && re.dt.Dot == dot)
                        .Select(re => re.dt)
                        .ToListAsync();
            return _mapper.Map<List<DetaiModel>>(deTaiPbs);
        }

        public async Task<List<DetaiModel>> search(string? maCn, string? tenDt, string? namHoc, int? dot, string? key, string? maGv, int? chucVu = 0)
        {
            if (dot == 0)
                dot = null;

            var deTais = _context.Detais
                        .Join(_context.DetaiChuyennganhs, dt => dt.MaDt, dc => dc.MaDt, (dt, dc) => new { dt = dt, dc = dc })
                        .Where(re => (string.IsNullOrEmpty(maCn) || re.dc.MaCn == maCn) &&
                        (string.IsNullOrEmpty(tenDt) || re.dt.TenDt.Contains(tenDt)) &&
                        (string.IsNullOrEmpty(namHoc) || re.dt.NamHoc == namHoc) &&
                        (dot == null || re.dt.Dot == dot))
                        .Select(re => re.dt).Distinct();
            if (chucVu == 3) // Trưởng khoa + Trưởng bộ môn
            {
                deTais = deTais
                        .Join(_context.Rades, dt => dt.MaDt, rd => rd.MaDt, (dt, rd) => new { dt, rd })
                        .Join(_context.Giangviens, gr => gr.rd.MaGv, gv => gv.MaGv, (gr, gv) => new { gr = gr, gv = gv })
                        .Where(re => re.gv.MaBm == key || re.gr.rd.MaGv == maGv || re.gr.dt.TrangThai == true)
                        .Select(re => re.gr.dt).Distinct();
            }
            else if(chucVu == 2) // Trưởng khoa
            {
                deTais = deTais
                        .Join(_context.Rades, dt => dt.MaDt, rd => rd.MaDt, (dt, rd) => new { dt, rd })
                        .Where(re => re.dt.TrangThai == true || re.rd.MaGv == maGv)
                        .Select(re => re.dt).Distinct();
            }
            else if( chucVu == 1) // Trưởng bộ môn
            {
                deTais = deTais
                        .Join(_context.Rades, dt => dt.MaDt, rd => rd.MaDt, (dt, rd) => new { dt, rd })
                        .Join(_context.Giangviens, gr => gr.rd.MaGv, gv => gv.MaGv, (gr, gv) => new { gr = gr, gv = gv })
                        .Where(re => re.gv.MaBm == key || re.gr.rd.MaGv == maGv)
                        .Select(re => re.gr.dt).Distinct();
            }
            else if (chucVu == 0) // Giảng viên không có chức vụ
            {
                deTais = deTais
                        .Join(_context.Rades, dt => dt.MaDt, rd => rd.MaDt, (dt, rd) => new { dt, rd })
                        .Where(re => re.rd.MaGv == maGv)
                        .Select(re => re.dt).Distinct();
            }
            else // Giáo vụ
            {
                deTais = deTais
                        .Join(_context.Rades, dt => dt.MaDt, rd => rd.MaDt, (dt, rd) => new { dt, rd })
                        .Where(re => re.dt.TrangThai == true)
                        .Select(re => re.dt).Distinct();
            }
            var result = await deTais.ToListAsync();
            return _mapper.Map<List<DetaiModel>>(result);
        }

        public async Task<GiangVienDtVTModel> GetGiangvienByDetaiAsync(string maDt)
        {
            GiangVienDtVTModel list = new GiangVienDtVTModel();
            list.maDt = maDt;
            list.gvhds = await _context.Giangviens
                    .Join(_context.Huongdans, gv => gv.MaGv, hd => hd.MaGv, (gv, hd) => new { gv = gv, hd = hd })
                    .Where(re => re.hd.MaDt == maDt)
                    .Select(re => new GiangVienVTModel
                    {
                        MaGV = re.gv.MaGv,
                        TenGV = re.gv.TenGv
                    }).ToListAsync();
            list.gvpbs = await _context.Giangviens
                    .Join(_context.Phanbiens, gv => gv.MaGv, hd => hd.MaGv, (gv, hd) => new { gv = gv, hd = hd })
                    .Where(re => re.hd.MaDt == maDt)
                    .Select(re => new GiangVienVTModel
                    {
                        MaGV = re.gv.MaGv,
                        TenGV = re.gv.TenGv
                    }).ToListAsync();
            return list;
        }

    }
}
