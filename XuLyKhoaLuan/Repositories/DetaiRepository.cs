using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.ComTypes;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Models.VirtualModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public async Task<List<DetaiModel>> GetAllDeTaisByGiangvienAsync(string MaGv)
        {
            var deTais = await _context.Detais
            .Join(_context.Rades, d => d.MaDt, r => r.MaDt, (d, r) => new {d = d, r = r})
            .Join(_context.Giangviens, rd => rd.r.MaGv, g => g.MaGv, (rd, g) => new {rd = rd, g = g})
            .Where(grd => grd.g.MaGv == MaGv)
            .Select(grd => grd.rd.d)
            .ToListAsync();
            return _mapper.Map<List<DetaiModel>>(deTais);
        }

        public async Task<List<DetaiModel>> GetDeTaisByChuyennganhGiangvienAsync(string maCn, string MaGv)
        {
            var deTais = await _context.Detais
            .Join(_context.Rades, d => d.MaDt, r => r.MaDt, (d, r) => new { d = d, r = r })
            .Join(_context.Giangviens, rd => rd.r.MaGv, g => g.MaGv, (rd, g) => new { rd = rd, g = g })
            .Join(_context.DetaiChuyennganhs, cn => cn.rd.d.MaDt, dtcn => dtcn.MaDt, (dtcn, cn) => new {dt = dtcn, cn = cn })
            .Where(grd => grd.dt.g.MaGv == MaGv && grd.cn.MaCn == maCn)
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

        public async Task<bool> CheckisDetaiOfGiangvienAsync(string maDt, string MaGv)
        {
            var isDtOfGv = await _context.Rades.AnyAsync(rd => rd.MaDt == maDt && rd.MaGv == MaGv);
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
                            .Where(re => /*re.rdt.dt.NamHoc == namHoc && re.rdt.dt.Dot == dot &&*/ re.gv.MaBm == maBM && re.rdt.dt.TrangThai == true)
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

        public async Task<List<DetaiModel>> GetDetaiByHuongdanOfGiangvienDotdkAsync(string MaGv, string namHoc, int dot)
        {
            var deTaiHds = await _context.Detais
                        .Join(_context.Huongdans, dt => dt.MaDt, hd => hd.MaDt, (dt, hd) => new { hd = hd, dt = dt })
                        .Where(re => re.hd.MaGv == MaGv /*&& re.dt.NamHoc == namHoc && re.dt.Dot == dot*/)
                        .Select(re => re.dt)
                        .ToListAsync();
            return _mapper.Map<List<DetaiModel>>(deTaiHds);
        }

        public async Task<List<DetaiModel>> GetDetaiByPhanbienOfGiangvienDotdkAsync(string MaGv, string namHoc, int dot)
        {
            var deTaiPbs = await _context.Detais
                        .Join(_context.Phanbiens, dt => dt.MaDt, pb => pb.MaDt, (dt, pb) => new { dt = dt, pb = pb })
                        .Where(re => re.pb.MaGv == MaGv /*&& re.dt.NamHoc == namHoc && re.dt.Dot == dot*/)
                        .Select(re => re.dt)
                        .ToListAsync();
            return _mapper.Map<List<DetaiModel>>(deTaiPbs);
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
                        MaGv = re.gv.MaGv,
                        TenGv = re.gv.TenGv
                    }).ToListAsync();
            list.gvpbs = await _context.Giangviens
                    .Join(_context.Phanbiens, gv => gv.MaGv, hd => hd.MaGv, (gv, hd) => new { gv = gv, hd = hd })
                    .Where(re => re.hd.MaDt == maDt)
                    .Select(re => new GiangVienVTModel
                    {
                        MaGv = re.gv.MaGv,
                        TenGv = re.gv.TenGv
                    }).ToListAsync();
            return list;
        }

        public async Task<List<DetaiModel>> search(string? maCn, string? tenDt,
            string? namHoc, int? dot, string? key, string? MaGv, int? chucVu = 0)
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
                        .Where(re => re.gv.MaBm == key || re.gr.rd.MaGv == MaGv || re.gr.dt.TrangThai == true)
                        .Select(re => re.gr.dt).Distinct();
            }
            else if (chucVu == 2) // Trưởng khoa
            {
                deTais = deTais
                        .Join(_context.Rades, dt => dt.MaDt, rd => rd.MaDt, (dt, rd) => new { dt, rd })
                        .Where(re => re.dt.TrangThai == true || re.rd.MaGv == MaGv)
                        .Select(re => re.dt).Distinct();
            }
            else if (chucVu == 1) // Trưởng bộ môn
            {
                deTais = deTais
                        .Join(_context.Rades, dt => dt.MaDt, rd => rd.MaDt, (dt, rd) => new { dt, rd })
                        .Join(_context.Giangviens, gr => gr.rd.MaGv, gv => gv.MaGv, (gr, gv) => new { gr = gr, gv = gv })
                        .Where(re => re.gv.MaBm == key || re.gr.rd.MaGv == MaGv)
                        .Select(re => re.gr.dt).Distinct();
            }
            else if (chucVu == 0) // Giảng viên không có chức vụ
            {
                deTais = deTais
                        .Join(_context.Rades, dt => dt.MaDt, rd => rd.MaDt, (dt, rd) => new { dt, rd })
                        .Where(re => re.rd.MaGv == MaGv)
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

        //keyword: +mã đề tài, +tên đề tài, chuyên ngành, giảng viên ra đề, giảng viên hướng dẫn,
        //trạng thái(Chưa duyệt, Chưa đạt, Đạt)
        public async Task<List<DetaiVTModel>> Search(string? keyword, string? maBm, string? MaGv, string? namHoc,
            int? dot = 0, bool? flag = false, int? chucVu = 0)
        {
            if (dot == 0)
                dot = null;
            List<DetaiVTModel> listDt = await _context.Detais
                        .Where(re => 
                        (string.IsNullOrEmpty(keyword) || 
                        (re.TenDt.Contains(keyword) || re.MaDt.Contains(keyword))) &&
                        (string.IsNullOrEmpty(namHoc) ||
                        re.NamHoc == namHoc) && (dot == null || re.Dot == dot) &&
                        (flag == false || re.TrangThai == true))
                        .Select(re => new DetaiVTModel
                        {
                            MaDT = re.MaDt,
                            TenDT = re.TenDt,
                            TomTat = re.TomTat,
                            SLMin = re.Slmin,
                            SLMax = re.Slmax,
                            TrangThai = re.TrangThai,
                            NamHoc = re.NamHoc,
                            Dot = re.Dot,
                            duyetDT = -1,
                            ngayDuyet = null,
                            CnPhuHop = new List<ChuyennganhModel>(),
                            GVRD = new List<GiangVienVTModel>(),
                            GVHD = new List<GiangVienVTModel>(),
                            GVPB = new List<GiangVienVTModel>()
                        }).Distinct().ToListAsync();

            // Trưởng khoa + Trưởng bộ môn
            if (chucVu == 3)
            {
                listDt = listDt
                        .Join(_context.Rades, dt => dt.MaDT, rd => rd.MaDt, (dt, rd) => new { dt, rd })
                        .Join(_context.Giangviens, gr => gr.rd.MaGv, gv => gv.MaGv, (gr, gv) => new { gr = gr, gv = gv })
                        .Where(re => re.gv.MaBm == maBm || re.gr.rd.MaGv == MaGv || re.gr.dt.TrangThai == true)
                        .Select(re => new DetaiVTModel
                        {
                            MaDT = re.gr.dt.MaDT,
                            TenDT = re.gr.dt.TenDT,
                            TomTat = re.gr.dt.TomTat,
                            SLMin = re.gr.dt.SLMin,
                            SLMax = re.gr.dt.SLMax,
                            TrangThai = re.gr.dt.TrangThai,
                            NamHoc = re.gr.dt.NamHoc,
                            Dot = re.gr.dt.Dot,
                            duyetDT = -1,
                            ngayDuyet = null,
                            CnPhuHop = new List<ChuyennganhModel>(),
                            GVRD = new List<GiangVienVTModel>(),
                            GVHD = new List<GiangVienVTModel>(),
                            GVPB = new List<GiangVienVTModel>()
                        }).Distinct().ToList();
            }
            // Trưởng khoa
            else if (chucVu == 2)
            {
                listDt = listDt
                        .Join(_context.Rades, dt => dt.MaDT, rd => rd.MaDt, (dt, rd) => new { dt, rd })
                        .Where(re => re.dt.TrangThai == true || re.rd.MaGv == MaGv)
                        .Select(re => new DetaiVTModel
                        {
                            MaDT = re.dt.MaDT,
                            TenDT = re.dt.TenDT,
                            TomTat = re.dt.TomTat,
                            SLMin = re.dt.SLMin,
                            SLMax = re.dt.SLMax,
                            TrangThai = re.dt.TrangThai,
                            NamHoc = re.dt.NamHoc,
                            Dot = re.dt.Dot,
                            duyetDT = -1,
                            ngayDuyet = null,
                            CnPhuHop = new List<ChuyennganhModel>(),
                            GVRD = new List<GiangVienVTModel>(),
                            GVHD = new List<GiangVienVTModel>(),
                            GVPB = new List<GiangVienVTModel>()
                        }).Distinct().ToList();
            }
            // Trưởng bộ môn
            else if (chucVu == 1)
            {
                listDt = listDt
                        .Join(_context.Rades, dt => dt.MaDT, rd => rd.MaDt, (dt, rd) => new { dt, rd })
                        .Join(_context.Giangviens, gr => gr.rd.MaGv, gv => gv.MaGv, (gr, gv) => new { gr = gr, gv = gv })
                        .Where(re => re.gv.MaBm == maBm || re.gr.rd.MaGv == MaGv)
                        .Select(re => new DetaiVTModel
                        {
                            MaDT = re.gr.dt.MaDT,
                            TenDT = re.gr.dt.TenDT,
                            TomTat = re.gr.dt.TomTat,
                            SLMin = re.gr.dt.SLMin,
                            SLMax = re.gr.dt.SLMax,
                            TrangThai = re.gr.dt.TrangThai,
                            NamHoc = re.gr.dt.NamHoc,
                            Dot = re.gr.dt.Dot,
                            duyetDT = -1,
                            ngayDuyet = null,
                            CnPhuHop = new List<ChuyennganhModel>(),
                            GVRD = new List<GiangVienVTModel>(),
                            GVHD = new List<GiangVienVTModel>(),
                            GVPB = new List<GiangVienVTModel>()
                        }).Distinct().ToList();
            }
            // Giảng viên không có chức vụ
            else if (chucVu == 0) 
            {
                listDt = listDt
                       .Join(_context.Rades, dt => dt.MaDT, rd => rd.MaDt, (dt, rd) => new { dt, rd })
                       .Where(re => re.rd.MaGv == MaGv)
                       .Select(re => new DetaiVTModel
                       {
                           MaDT = re.dt.MaDT,
                           TenDT = re.dt.TenDT,
                           TomTat = re.dt.TomTat,
                           SLMin = re.dt.SLMin,
                           SLMax = re.dt.SLMax,
                           TrangThai = re.dt.TrangThai,
                           NamHoc = re.dt.NamHoc,
                           Dot = re.dt.Dot,
                           duyetDT = -1,
                           ngayDuyet = null,
                           CnPhuHop = new List<ChuyennganhModel>(),
                           GVRD = new List<GiangVienVTModel>(),
                           GVHD = new List<GiangVienVTModel>(),
                           GVPB = new List<GiangVienVTModel>()
                       }).Distinct().ToList();
            }
            // Giáo vụ
            else
            {
                listDt = listDt
                       .Join(_context.Rades, dt => dt.MaDT, rd => rd.MaDt, (dt, rd) => new { dt, rd })
                       .Where(re => re.dt.TrangThai == true)
                       .Select(re => new DetaiVTModel
                       {
                           MaDT = re.dt.MaDT,
                           TenDT = re.dt.TenDT,
                           TomTat = re.dt.TomTat,
                           SLMin = re.dt.SLMin,
                           SLMax = re.dt.SLMax,
                           TrangThai = re.dt.TrangThai,
                           NamHoc = re.dt.NamHoc,
                           Dot = re.dt.Dot,
                           duyetDT = -1,
                           ngayDuyet = null,
                           CnPhuHop = new List<ChuyennganhModel>(),
                           GVRD = new List<GiangVienVTModel>(),
                           GVHD = new List<GiangVienVTModel>(),
                           GVPB = new List<GiangVienVTModel>()
                       }).Distinct().ToList();

            }

            for (int i = 0; i < listDt.Count; i++)
            {
                DateTime? maxNgayDuyet = await _context.Duyetdts
                        .Where(re => re.MaDt == listDt[i].MaDT)
                        .OrderByDescending(re => re.NgayDuyet)
                        .Select(re => (DateTime?)re.NgayDuyet)
                        .FirstOrDefaultAsync();

                if (maxNgayDuyet != null)
                {
                    var duyetDT = await _context.Duyetdts
                    .Where(re => re.MaDt == listDt[i].MaDT && re.NgayDuyet == maxNgayDuyet)
                    .FirstOrDefaultAsync();
                    listDt[i].ngayDuyet = duyetDT?.NgayDuyet;
                }

                if (listDt[i].TrangThai == true)
                {
                    listDt[i].duyetDT = 1;
                }
                else if (maxNgayDuyet != null)
                {
                    listDt[i].duyetDT = 0;
                }
                else
                {
                    listDt[i].duyetDT = -1;
                }

                listDt[i].GVRD = await _context.Rades
                        .Join(_context.Giangviens, rd => rd.MaGv, gv => gv.MaGv, (rd, gv) => new { rd = rd, gv = gv })
                        .Where(re => re.rd.MaDt == listDt[i].MaDT)
                        .Select(re => new GiangVienVTModel
                        {
                            MaGv = re.gv.MaGv,
                            TenGv = re.gv.TenGv,
                            VaiTro = 0,
                            ChucVu = "",
                            duaRaHoiDong = 0
                        })
                        .ToListAsync();

                listDt[i].GVHD = await _context.Huongdans
                        .Join(_context.Giangviens, hd => hd.MaGv, gv => gv.MaGv, (hd, gv) => new { hd = hd, gv = gv })
                        .Where(re => re.hd.MaDt == listDt[i].MaDT)
                        .Select(re => new GiangVienVTModel
                        {
                            MaGv = re.gv.MaGv,
                            TenGv = re.gv.TenGv,
                            VaiTro = 0,
                            ChucVu = "",
                            duaRaHoiDong = 1
                        })
                        .ToListAsync();

                listDt[i].GVPB = await _context.Phanbiens
                        .Join(_context.Giangviens, pb => pb.MaGv, gv => gv.MaGv, (pb, gv) => new { pb = pb, gv = gv })
                        .Where(re => re.pb.MaDt == listDt[i].MaDT)
                        .Select(re => new GiangVienVTModel
                        {
                            MaGv = re.gv.MaGv,
                            TenGv = re.gv.TenGv,
                            VaiTro = 0,
                            ChucVu = "",
                            duaRaHoiDong = 2
                        })
                        .ToListAsync();

                listDt[i].CnPhuHop = await _context.DetaiChuyennganhs
                            .Join(_context.Chuyennganhs, dc => dc.MaCn, cn => cn.MaCn, (dc, cn) => new { dc = dc, cn = cn })
                            .Where(re => re.dc.MaDt == listDt[i].MaDT)
                            .Select(re => new ChuyennganhModel
                            {
                                MaCn = re.cn.MaCn,
                                TenCn = re.cn.TenCn,
                                MaKhoa = re.cn.MaKhoa
                            })
                        .ToListAsync();

                if (!string.IsNullOrEmpty(keyword))
                {   
                    // Tìm kiếm theo chuyên ngành phù hợp
                    bool isCnph = false;
                    foreach (var c in listDt[i].CnPhuHop)
                    {
                        if (c.TenCn.Contains(keyword))
                        {
                            isCnph = true;
                            break;
                        }
                    }

                    // Giảng viên ra đề
                    bool isRd = false;
                    foreach (var gv in listDt[i].GVRD)
                    {
                        if (gv.TenGv.Contains(keyword))
                        {
                            isRd = true;
                            break;
                        }
                    }

                    // Giảng viên hướng dẫn
                    bool isGvhd = false;
                    foreach (var gv in listDt[i].GVHD)
                    {
                        if (gv.TenGv.Contains(keyword))
                        {
                            isGvhd = true;
                            break;
                        }
                    }

                    // Giảng viên phản biện
                    bool isPb = false;
                    foreach (var gv in listDt[i].GVPB)
                    {
                        if (gv.TenGv.Contains(keyword))
                        {
                            isPb = true;
                            break;
                        }
                    }

                    bool isDt = false;
                    if (listDt[i].TenDT.Contains(keyword) || listDt[i].MaDT.Contains(keyword))
                    {
                        isDt = true;
                    }

                    if (!isDt && !isCnph && !isRd && !isGvhd && !isPb)
                    {
                        listDt.RemoveAt(i);
                        i--;
                    }
                }
            }
            return listDt;
        }

    }
}
