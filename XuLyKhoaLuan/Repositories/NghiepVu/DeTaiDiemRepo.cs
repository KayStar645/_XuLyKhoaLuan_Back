using AutoMapper;
using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface.NghiepVu;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Repositories.NghiepVu
{
    public class DeTaiDiemRepo : IDeTaiDiemRepo
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public DeTaiDiemRepo(XuLyKhoaLuanContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<DeTaiDiemVTModel>> GetDanhSachDiemByGv(string MaGv)
        {
            // Lấy danh đề tài mà giảng viên này hướng dẫn/Phản biện/Hội đồng
            var deTais = await _context.Detais
                        .GroupJoin(_context.Huongdans, dt => dt.MaDt, hd => hd.MaDt, (dt, hd) => new { dt, hd })
                        .SelectMany(x => x.hd.DefaultIfEmpty(), (x, hd) => new { x.dt, hd })
                        .GroupJoin(_context.Phanbiens, x => x.dt.MaDt, pb => pb.MaDt, (x, pb) => new { x.dt, x.hd, pb })
                        .SelectMany(x => x.pb.DefaultIfEmpty(), (x, pb) => new { x.dt, x.hd, pb })
                        .GroupJoin(_context.Hdphanbiens, x => x.dt.MaDt, hdpb => hdpb.MaDt, (x, hdpb) => new { x.dt, x.hd, x.pb, hdpb })
                        .SelectMany(x => x.hdpb.DefaultIfEmpty(), (x, hdpb) => new { x.dt, x.hd, x.pb, hdpb })
                        .Where(x => x.hd.MaGv == MaGv || x.pb.MaGv == MaGv || x.hdpb.MaGv == MaGv)
                        .Select(x => new DeTaiDiemVTModel
                        {
                            MaDT = x.dt.MaDt,
                            TenDT = x.dt.TenDt,
                        })
                        .Distinct()
                        .ToListAsync();


            foreach (DeTaiDiemVTModel dt in deTais)
            {
                // Lấy danh sách sinh viên của từng đề tài
                dt.SinhViens = await _context.Sinhviens
                            .Join(_context.Thamgia, sv => sv.MaSv, tg => tg.MaSv, (sv, tg) => new { sv = sv, tg = tg })
                            .Join(_context.Dangkies, st => st.tg.MaNhom, dk => dk.MaNhom, (st, dk) => new { st = st, dk = dk })
                            .Where(re => re.dk.MaDt == dt.MaDT)
                            .Select(re => new SinhVienVTModel
                            {
                                MaSV = re.st.sv.MaSv,
                                TenSV = re.st.sv.TenSv,
                                Lop = re.st.sv.Lop,
                                NamHoc = re.st.tg.NamHoc,
                                Dot = re.st.tg.Dot
                            }).Distinct().ToListAsync();

                // Lấy danh sách giảng viên hướng dẫn
                dt.GVHDs = await _context.Giangviens
                            .Join(_context.Huongdans, gv => gv.MaGv, hd => hd.MaGv, (gv, hd) => new { gv = gv, hd = hd })
                            .Where(re => re.hd.MaDt == dt.MaDT)
                            .Select(re => new GiangVienVTModel
                            {
                                MaGv = re.gv.MaGv,
                                TenGv = re.gv.TenGv,
                                VaiTro = 1,
                                ChucVu = "",
                                duaRaHoiDong = re.hd.DuaRaHd == true ? 1 : 0,
                            }).Distinct().ToListAsync();

                // Lấy danh sách giảng viên phản biện
                dt.GVPBs = await _context.Giangviens
                            .Join(_context.Phanbiens, gv => gv.MaGv, pb => pb.MaGv, (gv, pb) => new { gv = gv, pb = pb })
                            .Where(re => re.pb.MaDt == dt.MaDT)
                            .Select(re => new GiangVienVTModel
                            {
                                MaGv = re.gv.MaGv,
                                TenGv = re.gv.TenGv,
                                VaiTro = 2,
                                ChucVu = "",
                                duaRaHoiDong = re.pb.DuaRaHd == true ? 2 : 0,
                            }).Distinct().ToListAsync();

                // Lấy danh sách giảng viên hội đồng
                dt.HoiDongs = await _context.Giangviens
                            .Join(_context.Thamgiahds, gv => gv.MaGv, tg => tg.MaGv, (gv, tg) => new { gv, tg })
                            .Join(_context.Vaitros, gt => gt.tg.MaVt, vt => vt.MaVt, (ght, vt) => new { ght, vt })
                            .Join(_context.Hdphanbiens, gtv => gtv.ght.tg.MaHd, hdpb => hdpb.MaHd, (gtv, hdpb) => new { gtv, hdpb })
                            .Where(re => re.hdpb.MaDt == dt.MaDT)
                            .Select(re => new GiangVienVTModel
                            {
                                MaGv = re.gtv.ght.gv.MaGv,
                                TenGv = re.gtv.ght.gv.TenGv,
                                VaiTro = 3,
                                ChucVu = re.gtv.vt.TenVaiTro,
                                duaRaHoiDong = 0
                            }).Distinct().OrderBy(gv => gv.MaGv).ToListAsync();

                // Lấy danh sách điểm của từng sinh viên
                foreach (SinhVienVTModel sv in dt.SinhViens)
                {
                    // Chỉ là hướng dẫn thôi
                    var diemHDs = await _context.Hdchams
                            .Where(hd => hd.MaSv == sv.MaSV && hd.NamHoc == sv.NamHoc && hd.Dot == sv.Dot)
                            .Select(re => new DiemSoVTModel
                            {
                                MaGV = re.MaGv,
                                nguoiCham = 1,
                                Diem = Math.Round(Convert.ToDouble(re.Diem), 2)
                            }).ToListAsync();
                    if (diemHDs.Count == 0)
                    {
                        diemHDs.Add(new DiemSoVTModel
                        {
                            MaGV = "",
                            nguoiCham = 1,
                            Diem = -1
                        });
                    }    

                    var diemPBs = await _context.Pbchams
                            .Where(pb => pb.MaSv == sv.MaSV && pb.NamHoc == sv.NamHoc && pb.Dot == sv.Dot)
                            .Select(re => new DiemSoVTModel
                            {
                                MaGV = re.MaGv,
                                nguoiCham = 2,
                                Diem = Math.Round(Convert.ToDouble(re.Diem), 2)
                            }).ToListAsync();
                    if (diemPBs.Count == 0)
                    {
                        diemPBs.Add(new DiemSoVTModel
                        {
                            MaGV = "",
                            nguoiCham = 2,
                            Diem = -1
                        });
                    }

                    var diemHDPBs = await _context.Hdpbchams
                            .Where(hdpb => hdpb.MaSv == sv.MaSV && hdpb.NamHoc == sv.NamHoc && hdpb.Dot == sv.Dot)
                            .Select(re => new DiemSoVTModel
                            {
                                MaGV = re.MaGv,
                                nguoiCham = 3,
                                Diem = Math.Round(Convert.ToDouble(re.Diem), 2)
                            }).OrderBy(re => re.MaGV).ToListAsync();
                    var tb = 0.0;
                    if (diemHDPBs.Count == 0)
                    {
                        diemHDPBs.Add(new DiemSoVTModel
                        {
                            MaGV = "",
                            nguoiCham = 3,
                            Diem = -1
                        });
                        tb = (diemHDs.Average(i => i.Diem == -1 ? 0 : i.Diem) +
                                 diemPBs.Average(i => i.Diem == -1 ? 0 : i.Diem)) / 2 ?? 0;

                    }
                    else
                    {
                        tb = (diemHDs.Average(i => i.Diem == -1 ? 0 : i.Diem) +
                                 diemPBs.Average(i => i.Diem == -1 ? 0 : i.Diem) +
                                 diemHDPBs.Average(i => i.Diem == -1 ? 0 : i.Diem)) / 3 ?? 0;
                    }
                    var diemTB = new DiemSoVTModel
                    {
                        MaGV = "",
                        nguoiCham = 4,
                        Diem = Math.Round(Convert.ToDouble(tb), 2)
                    };

                    var diemTBs = await _context.Hdpbchams
                            .Where(hdpb => hdpb.MaSv != hdpb.MaSv)
                            .Select(re => new DiemSoVTModel
                            {
                                MaGV = re.MaGv,
                                nguoiCham = 3,
                                Diem = Math.Round(Convert.ToDouble(re.Diem), 2)
                            }).OrderBy(re => re.MaGV).ToListAsync();
                    diemTBs.Add(diemTB);
                    sv.Diems = diemHDs.Concat(diemPBs).Concat(diemHDPBs).Concat(diemTBs).ToList();
                }
            }
            return deTais;
        }

        public async Task<List<DeTaiDiemVTModel>> GetDanhSachDiemBySv(string maSv)
        {
            // Lấy danh sách đề tài mà sinh viên này tham gia
            var listDt = await _context.Dangkies
                        .Join(_context.Thamgia, dk => dk.MaNhom, tg => tg.MaNhom, (dk, tg) => new { dk, tg })
                        .Where(re => re.tg.MaSv == maSv)
                        .Select(re => re.dk)
                        .Distinct().ToListAsync();
            foreach(var item in listDt)
            {
                // Lấy danh đề tài mà giảng viên này hướng dẫn/Phản biện/Hội đồng
                var deTais = await _context.Detais
                            .GroupJoin(_context.Huongdans, dt => dt.MaDt, hd => hd.MaDt, (dt, hd) => new { dt, hd })
                            .SelectMany(x => x.hd.DefaultIfEmpty(), (x, hd) => new { x.dt, hd })
                            .GroupJoin(_context.Phanbiens, x => x.dt.MaDt, pb => pb.MaDt, (x, pb) => new { x.dt, x.hd, pb })
                            .SelectMany(x => x.pb.DefaultIfEmpty(), (x, pb) => new { x.dt, x.hd, pb })
                            .GroupJoin(_context.Hdphanbiens, x => x.dt.MaDt, hdpb => hdpb.MaDt, (x, hdpb) => new { x.dt, x.hd, x.pb, hdpb })
                            .SelectMany(x => x.hdpb.DefaultIfEmpty(), (x, hdpb) => new { x.dt, x.hd, x.pb, hdpb })
                            .Where(x => x.dt.MaDt == item.MaDt)
                            .Select(x => new DeTaiDiemVTModel
                            {
                                MaDT = x.dt.MaDt,
                                TenDT = x.dt.TenDt,
                            })
                            .Distinct()
                            .ToListAsync();


                foreach (DeTaiDiemVTModel dt in deTais)
                {
                    // Lấy danh sách sinh viên của từng đề tài
                    dt.SinhViens = await _context.Sinhviens
                                .Join(_context.Thamgia, sv => sv.MaSv, tg => tg.MaSv, (sv, tg) => new { sv = sv, tg = tg })
                                .Join(_context.Dangkies, st => st.tg.MaNhom, dk => dk.MaNhom, (st, dk) => new { st = st, dk = dk })
                                .Where(re => re.dk.MaDt == dt.MaDT)
                                .Select(re => new SinhVienVTModel
                                {
                                    MaSV = re.st.sv.MaSv,
                                    TenSV = re.st.sv.TenSv,
                                    Lop = re.st.sv.Lop,
                                    NamHoc = re.st.tg.NamHoc,
                                    Dot = re.st.tg.Dot
                                }).Distinct().ToListAsync();

                    // Lấy danh sách giảng viên hướng dẫn
                    dt.GVHDs = await _context.Giangviens
                                .Join(_context.Huongdans, gv => gv.MaGv, hd => hd.MaGv, (gv, hd) => new { gv = gv, hd = hd })
                                .Where(re => re.hd.MaDt == dt.MaDT)
                                .Select(re => new GiangVienVTModel
                                {
                                    MaGv = re.gv.MaGv,
                                    TenGv = re.gv.TenGv,
                                    VaiTro = 1,
                                    ChucVu = "",
                                    duaRaHoiDong = re.hd.DuaRaHd == true ? 1 : 0,
                                }).Distinct().ToListAsync();

                    // Lấy danh sách giảng viên phản biện
                    dt.GVPBs = await _context.Giangviens
                                .Join(_context.Phanbiens, gv => gv.MaGv, pb => pb.MaGv, (gv, pb) => new { gv = gv, pb = pb })
                                .Where(re => re.pb.MaDt == dt.MaDT)
                                .Select(re => new GiangVienVTModel
                                {
                                    MaGv = re.gv.MaGv,
                                    TenGv = re.gv.TenGv,
                                    VaiTro = 2,
                                    ChucVu = "",
                                    duaRaHoiDong = re.pb.DuaRaHd == true ? 2 : 0,
                                }).Distinct().ToListAsync();

                    // Lấy danh sách giảng viên hội đồng
                    dt.HoiDongs = await _context.Giangviens
                                .Join(_context.Thamgiahds, gv => gv.MaGv, tg => tg.MaGv, (gv, tg) => new { gv, tg })
                                .Join(_context.Vaitros, gt => gt.tg.MaVt, vt => vt.MaVt, (ght, vt) => new { ght, vt })
                                .Join(_context.Hdphanbiens, gtv => gtv.ght.tg.MaHd, hdpb => hdpb.MaHd, (gtv, hdpb) => new { gtv, hdpb })
                                .Where(re => re.hdpb.MaDt == dt.MaDT)
                                .Select(re => new GiangVienVTModel
                                {
                                    MaGv = re.gtv.ght.gv.MaGv,
                                    TenGv = re.gtv.ght.gv.TenGv,
                                    VaiTro = 3,
                                    ChucVu = re.gtv.vt.TenVaiTro,
                                    duaRaHoiDong = 0
                                }).Distinct().OrderBy(gv => gv.MaGv).ToListAsync();

                    // Lấy danh sách điểm của từng sinh viên
                    foreach (SinhVienVTModel sv in dt.SinhViens)
                    {
                        // Chỉ là hướng dẫn thôi
                        var diemHDs = await _context.Hdchams
                                .Where(hd => hd.MaSv == sv.MaSV && hd.NamHoc == sv.NamHoc && hd.Dot == sv.Dot)
                                .Select(re => new DiemSoVTModel
                                {
                                    MaGV = re.MaGv,
                                    nguoiCham = 1,
                                    Diem = Math.Round(Convert.ToDouble(re.Diem), 2)
                                }).ToListAsync();
                        if (diemHDs.Count == 0)
                        {
                            diemHDs.Add(new DiemSoVTModel
                            {
                                MaGV = "",
                                nguoiCham = 1,
                                Diem = -1
                            });
                        }

                        var diemPBs = await _context.Pbchams
                                .Where(pb => pb.MaSv == sv.MaSV && pb.NamHoc == sv.NamHoc && pb.Dot == sv.Dot)
                                .Select(re => new DiemSoVTModel
                                {
                                    MaGV = re.MaGv,
                                    nguoiCham = 2,
                                    Diem = Math.Round(Convert.ToDouble(re.Diem), 2)
                                }).ToListAsync();
                        if (diemPBs.Count == 0)
                        {
                            diemPBs.Add(new DiemSoVTModel
                            {
                                MaGV = "",
                                nguoiCham = 2,
                                Diem = -1
                            });
                        }

                        var diemHDPBs = await _context.Hdpbchams
                                .Where(hdpb => hdpb.MaSv == sv.MaSV && hdpb.NamHoc == sv.NamHoc && hdpb.Dot == sv.Dot)
                                .Select(re => new DiemSoVTModel
                                {
                                    MaGV = re.MaGv,
                                    nguoiCham = 3,
                                    Diem = Math.Round(Convert.ToDouble(re.Diem), 2)
                                }).OrderBy(re => re.MaGV).ToListAsync();
                        var tb = 0.0;
                        if (diemHDPBs.Count == 0)
                        {
                            diemHDPBs.Add(new DiemSoVTModel
                            {
                                MaGV = "",
                                nguoiCham = 3,
                                Diem = -1
                            });
                            tb = (diemHDs.Average(i => i.Diem == -1 ? 0 : i.Diem) +
                                     diemPBs.Average(i => i.Diem == -1 ? 0 : i.Diem)) / 2 ?? 0;

                        }
                        else
                        {
                            tb = (diemHDs.Average(i => i.Diem == -1 ? 0 : i.Diem) +
                                     diemPBs.Average(i => i.Diem == -1 ? 0 : i.Diem) +
                                     diemHDPBs.Average(i => i.Diem == -1 ? 0 : i.Diem)) / 3 ?? 0;
                        }
                        var diemTB = new DiemSoVTModel
                        {
                            MaGV = "",
                            nguoiCham = 4,
                            Diem = Math.Round(Convert.ToDouble(tb), 2)
                        };

                        var diemTBs = await _context.Hdpbchams
                                .Where(hdpb => hdpb.MaSv != hdpb.MaSv)
                                .Select(re => new DiemSoVTModel
                                {
                                    MaGV = re.MaGv,
                                    nguoiCham = 3,
                                    Diem = Math.Round(Convert.ToDouble(re.Diem), 2)
                                }).OrderBy(re => re.MaGV).ToListAsync();
                        diemTBs.Add(diemTB);
                        sv.Diems = diemHDs.Concat(diemPBs).Concat(diemHDPBs).Concat(diemTBs).ToList();
                    }
                }
                return deTais;
            }
            return null;
        }

        public async Task<bool> ChamDiemSvAsync(string MaGv, string maDt, string maSv, string namHoc, int dot, int vaiTro, double diem)
        {
            if (vaiTro == 1)
            {
                var chamDiem = await _context.Hdchams
                    .Where(c => c.MaGv == MaGv && c.MaDt == maDt &&
                    c.MaSv == maSv && c.NamHoc == namHoc && c.Dot == dot)
                    .SingleOrDefaultAsync();
                if(chamDiem != null)
                {
                    chamDiem.Diem = diem;
                    _context.Hdchams.Update(chamDiem);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            else if (vaiTro == 2)
            {
                var chamDiem = await _context.Pbchams
                    .Where(c => c.MaGv == MaGv && c.MaDt == maDt &&
                    c.MaSv == maSv && c.NamHoc == namHoc && c.Dot == dot)
                    .SingleOrDefaultAsync();
                if (chamDiem != null)
                {

                    chamDiem.Diem = diem;
                    _context.Pbchams.Update(chamDiem);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            else if (vaiTro == 3)
            {
                var chamDiem = await _context.Hdpbchams
                    .Where(c => c.MaGv == MaGv && c.MaDt == maDt &&
                    c.MaSv == maSv && c.NamHoc == namHoc && c.Dot == dot)
                    .SingleOrDefaultAsync();
                if (chamDiem != null)
                {
                    chamDiem.Diem = diem;
                    _context.Hdpbchams.Update(chamDiem);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<List<DiemSVVTModel>> GetDanhSachDiem(string? keyword, string? maCn, string? namHoc, int? dot = 0)
        {
           List<DiemSVVTModel> listDiem = await _context.Sinhviens
                            .Join(_context.Thamgia, sv => sv.MaSv, tg => tg.MaSv, (sv, tg) => new { sv = sv, tg = tg })
                            .Join(_context.Chuyennganhs, sg => sg.sv.MaCn, cn => cn.MaCn, (sg, cn) => new { sg = sg, cn = cn })
                            .Where(re =>
                                (string.IsNullOrEmpty(namHoc) || re.sg.tg.NamHoc == namHoc) &&
                                (dot == 0 || re.sg.tg.Dot == dot) &&
                                (string.IsNullOrEmpty(maCn) ||re.cn.MaCn == maCn) &&
                                (string.IsNullOrEmpty(keyword) ||
                                (re.sg.sv.TenSv.Contains(keyword) || re.sg.sv.MaSv.Contains(keyword) ||
                                re.sg.sv.Lop.Contains(keyword) || re.cn.TenCn.Contains(keyword))
                                ))
                            .Select(re => new DiemSVVTModel
                            {
                                maSv = re.sg.sv.MaSv,
                                tenSv = re.sg.sv.TenSv,
                                namHoc = re.sg.tg.NamHoc,
                                dot = re.sg.tg.Dot,
                                lop = re.sg.sv.Lop,
                                maCn = re.cn.MaCn,
                                chuyenNganh = re.cn.TenCn,
                                diemHd = 0,
                                diemPb = 0,
                                diemHdpb = -1,
                                diemTb = 0
                            })
                            .ToListAsync();
            foreach(var sv in listDiem)
            {
                // Điểm hướng dẫn
                var diemHds = await _context.Hdchams
                            .Where(hd => hd.MaSv == sv.maSv && hd.NamHoc == sv.namHoc && hd.Dot == sv.dot)
                            .ToListAsync();
                double diemHd = 0;
                foreach (var diem in diemHds)
                {
                    diemHd += (diem.Diem != null && diem.Diem != -1) ? (double)diem.Diem : 0;
                }
                if(diemHds.Count != 0)
                {
                    sv.diemHd = Math.Round(Convert.ToDouble(diemHd / diemHds.Count), 2);
                }

                // Điểm phản biện
                var diemPbs = await _context.Pbchams
                            .Where(pb => pb.MaSv == sv.maSv &&pb.NamHoc == sv.namHoc && pb.Dot == sv.dot)
                            .ToListAsync();
                double diemPb = 0;
                foreach (var diem in diemPbs)
                {
                    diemPb += (diem.Diem != null && diem.Diem != -1) ? (double)diem.Diem : 0;
                }
                if (diemPbs.Count != 0)
                {
                    sv.diemPb = Math.Round(Convert.ToDouble(diemPb / diemPbs.Count), 2);
                }

                // Điểm hội đồng
                var diemHdpbs = await _context.Hdpbchams
                            .Where(hdpb => hdpb.MaSv == sv.maSv && hdpb.NamHoc == sv.namHoc && hdpb.Dot == sv.dot)
                            .ToListAsync();
                double diemHdpb = 0;
                foreach (var diem in diemHdpbs)
                {
                    diemHdpb += (diem.Diem != null && diem.Diem != -1) ? (double)diem.Diem : 0;
                }
                if (diemHdpbs.Count != 0)
                {
                    sv.diemHdpb = Math.Round(Convert.ToDouble(diemHdpb / diemHdpbs.Count), 2);
                }
                else
                {
                    sv.diemHdpb = -1;
                }
                if(-1 == sv.diemHdpb)
                {
                    sv.diemTb = Math.Round(Convert.ToDouble((sv.diemHd + sv.diemPb) / 2), 2);
                }
                else
                {
                    sv.diemTb = Math.Round(Convert.ToDouble((sv.diemHd + sv.diemPb + sv.diemHdpb) / 3), 2);
                }
            }
            return listDiem;
        }

    }
}