﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface.NghiepVu;
using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Repositories.NghiepVu
{
    public class DeTaiDiemRepo : IDeTaiDiemRepo
    {
        private readonly XuLyKhoaLuanContext _context;

        public DeTaiDiemRepo(XuLyKhoaLuanContext context)
        {
            this._context = context;
        }

        public async Task<List<DeTaiDiemVTModel>> GetDanhSachDiemByGv(string maGv)
        {
            // Lấy danh đề tài mà giảng viên này hướng dẫn/Phản biện/Hội đồng
            var deTais = await _context.Detais
                        .GroupJoin(_context.Huongdans, dt => dt.MaDt, hd => hd.MaDt, (dt, hd) => new { dt, hd })
                        .SelectMany(x => x.hd.DefaultIfEmpty(), (x, hd) => new { x.dt, hd })
                        .GroupJoin(_context.Phanbiens, x => x.dt.MaDt, pb => pb.MaDt, (x, pb) => new { x.dt, x.hd, pb })
                        .SelectMany(x => x.pb.DefaultIfEmpty(), (x, pb) => new { x.dt, x.hd, pb })
                        .GroupJoin(_context.Hdphanbiens, x => x.dt.MaDt, hdpb => hdpb.MaDt, (x, hdpb) => new { x.dt, x.hd, x.pb, hdpb })
                        .SelectMany(x => x.hdpb.DefaultIfEmpty(), (x, hdpb) => new { x.dt, x.hd, x.pb, hdpb })
                        .Where(x => x.hd.MaGv == maGv || x.pb.MaGv == maGv || x.hdpb.MaGv == maGv)
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
                                MaGV = re.gv.MaGv,
                                TenGV = re.gv.TenGv,
                                VaiTro = 1,
                                ChucVu = ""
                            }).Distinct().ToListAsync();

                // Lấy danh sách giảng viên phản biện
                dt.GVPBs = await _context.Giangviens
                            .Join(_context.Phanbiens, gv => gv.MaGv, pb => pb.MaGv, (gv, pb) => new { gv = gv, pb = pb })
                            .Where(re => re.pb.MaDt == dt.MaDT)
                            .Select(re => new GiangVienVTModel
                            {
                                MaGV = re.gv.MaGv,
                                TenGV = re.gv.TenGv,
                                VaiTro = 2,
                                ChucVu = ""
                            }).Distinct().ToListAsync();

                // Lấy danh sách giảng viên hội đồng
                dt.HoiDongs = await _context.Giangviens
                            .Join(_context.Hdphanbiens, gv => gv.MaGv, hdpb => hdpb.MaGv, (gv, hdpb) => new { gv = gv, hdpb = hdpb })
                            .Join(_context.Thamgiahds, gh => gh.hdpb.MaHd, tg => tg.MaHd, (gh, tg) => new { gh = gh, tg = tg })
                            .Join(_context.Vaitros, ght => ght.tg.MaVt, vt => vt.MaVt, (ght, vt) => new { ght = ght, vt = vt })
                            .Where(re => re.ght.gh.hdpb.MaDt == dt.MaDT)
                            .Select(re => new GiangVienVTModel
                            {
                                MaGV = re.ght.gh.gv.MaGv,
                                TenGV = re.ght.gh.gv.TenGv,
                                VaiTro = 3,
                                ChucVu = re.vt.TenVaiTro
                            }).Distinct().ToListAsync();

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
                                Diem = re.Diem
                            }).ToListAsync();
                    if(diemHDs.Count == 0)
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
                                Diem = re.Diem
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
                                Diem = re.Diem
                            }).ToListAsync();
                    if (diemHDPBs.Count == 0)
                    {
                        diemHDPBs.Add(new DiemSoVTModel
                        {
                            MaGV = "",
                            nguoiCham = 3,
                            Diem = -1
                        });
                    }

                    sv.Diems = diemHDs.Concat(diemPBs).Concat(diemHDPBs).ToList();
                }
            }
            return deTais;
        }

    }
}

/*
  List<DiemSoVTModel> diemSos = await _context.Sinhviens
                    .SelectMany(sv => giangViens, (sv, gv) => new { SinhVien = sv, GiangVien = gv })
                    .SelectAsync(s => new DiemSoVTModel
                    {
                        MaGV = s.GiangVien.MaGV,
                        MaSV = s.SinhVien.MaSV,
                        Diem = _context.Hdchams
                            .Where(hd => hd.MaSv == s.SinhVien.MaSV && hd.NamHoc == s.SinhVien.NamHoc && hd.Dot == s.SinhVien.Dot && hd.MaGv == s.GiangVien.MaGV)
                            .Select(hd => hd.Diem)
                            .FirstOrDefaultAsync()
                            .Result // sử dụng .Result để lấy giá trị của Task
                    }).ToListAsync();
 */