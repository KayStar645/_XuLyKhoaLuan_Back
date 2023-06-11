using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface.NghiepVu;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Repositories.NghiepVu
{
    public class LichPhanBienRepo : ILichPhanBienRepo
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public LichPhanBienRepo(XuLyKhoaLuanContext context, IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;
        }


        public async Task<List<LichPhanBienVTModel>> GetLichPhanBienByGvAsync(string maGv)
        {
            var lichHTs = await _context.GapMatHds
                        .Join(_context.Detais, hd => hd.MaDt, dt => dt.MaDt, (hd, dt) => new { hd = hd, dt = dt })
                        .Where(re => re.hd.MaGv == maGv && re.hd.ThoiGianBd != null && re.hd.ThoiGianBd != null)
                        .Select(re => new LichPhanBienVTModel
                        {
                            MaDt = re.dt.MaDt,
                            TenDeTai = re.dt.TenDt,
                            ThoiGianBD = (DateTime)re.hd.ThoiGianBd,
                            ThoiGianKT = (DateTime)re.hd.ThoiGianKt,
                            DiaDiem = re.hd.DiaDiem,
                            LoaiLich = 0
                        })
                        .ToListAsync();

            var lichHDs = await _context.Huongdans
                        .Join(_context.Detais, hd => hd.MaDt, dt => dt.MaDt, (hd, dt) => new { hd = hd, dt = dt })
                        .Where(re => re.hd.MaGv == maGv && re.hd.ThoiGianBd != null && re.hd.ThoiGianBd != null)
                        .Select(re => new LichPhanBienVTModel
                        {
                            MaDt = re.dt.MaDt,
                            TenDeTai = re.dt.TenDt,
                            ThoiGianBD = (DateTime)re.hd.ThoiGianBd,
                            ThoiGianKT = (DateTime)re.hd.ThoiGianKt,
                            DiaDiem = re.hd.DiaDiem,
                            LoaiLich = 1
                        })
                        .ToListAsync();
            var lichPBs = await _context.Phanbiens
                        .Join(_context.Detais, pb => pb.MaDt, dt => dt.MaDt, (pb, dt) => new { pb = pb, dt = dt })
                        .Where(re => re.pb.MaGv == maGv && re.pb.ThoiGianBd != null && re.pb.ThoiGianBd != null)
                        .Select(re => new LichPhanBienVTModel
                        {
                            MaDt = re.dt.MaDt,
                            TenDeTai = re.dt.TenDt,
                            ThoiGianBD = (DateTime)re.pb.ThoiGianBd,
                            ThoiGianKT = (DateTime)re.pb.ThoiGianKt,
                            DiaDiem = re.pb.DiaDiem,
                            LoaiLich = 2
                        })
                        .ToListAsync();
            var lichHDongs = await _context.Hoidongs
                        .Join(_context.Hdphanbiens, hd => hd.MaHd, hdpb => hdpb.MaHd, (hd, hdpb) => new { hd = hd, hdpb = hdpb })
                        .Join(_context.Detais, hp => hp.hdpb.MaDt, dt => dt.MaDt, (hp, dt) => new { hp = hp, dt = dt })
                        .Where(re => re.hp.hdpb.MaGv == maGv && re.hp.hd.ThoiGianBd != null && re.hp.hd.ThoiGianKt != null)
                        .Select(re => new LichPhanBienVTModel
                        {
                            MaDt = re.dt.MaDt,
                            TenDeTai = re.dt.TenDt,
                            ThoiGianBD = (DateTime)re.hp.hd.ThoiGianBd,
                            ThoiGianKT = (DateTime)re.hp.hd.ThoiGianKt,
                            DiaDiem = re.hp.hd.DiaDiem,
                            LoaiLich = 3
                        })
                        .ToListAsync();
            return lichHTs.Concat(lichHDs).Concat(lichPBs).Concat(lichHDongs).OrderBy(l => l.ThoiGianBD).OrderByDescending(l => l.ThoiGianKT).ToList();
        }

        public async Task<List<LichPhanBienVTModel>> GetLichPhanBienBySvAsync(string maSv)
        {
            var lichHTs = await _context.GapMatHds
                        .Join(_context.Detais, hd => hd.MaDt, dt => dt.MaDt, (hd, dt) => new { hd = hd, dt = dt })
                        .Join(_context.Dangkies, ht => ht.dt.MaDt, dk => dk.MaDt, (ht, dk) => new { ht = ht, dk = dk })
                        .Join(_context.Thamgia, htk => htk.dk.MaNhom, tg => tg.MaNhom, (htk, tg) => new { htk = htk, tg = tg })
                        .Join(_context.Sinhviens, htkt => htkt.tg.MaSv, sv => sv.MaSv, (htkt, sv) => new { htkt = htkt, sv = sv })
                        .Where(re => re.sv.MaSv == maSv && re.htkt.htk.ht.hd.ThoiGianBd != null && re.htkt.htk.ht.hd.ThoiGianBd != null)
                        .Select(re => new LichPhanBienVTModel
                        {
                            MaDt = re.htkt.htk.ht.dt.MaDt,
                            TenDeTai = re.htkt.htk.ht.dt.TenDt,
                            ThoiGianBD = (DateTime)re.htkt.htk.ht.hd.ThoiGianBd,
                            ThoiGianKT = (DateTime)re.htkt.htk.ht.hd.ThoiGianKt,
                            DiaDiem = re.htkt.htk.ht.hd.DiaDiem,
                            LoaiLich = 0
                        })
                        .ToListAsync();

            var lichHDs = await _context.Huongdans
                        .Join(_context.Detais, hd => hd.MaDt, dt => dt.MaDt, (hd, dt) => new { hd = hd, dt = dt })
                        .Join(_context.Dangkies, ht => ht.dt.MaDt, dk => dk.MaDt, (ht, dk) => new { ht = ht, dk = dk })
                        .Join(_context.Thamgia, htk => htk.dk.MaNhom, tg => tg.MaNhom, (htk, tg) => new { htk = htk, tg = tg })
                        .Join(_context.Sinhviens, htkt => htkt.tg.MaSv, sv => sv.MaSv, (htkt, sv) => new { htkt = htkt, sv = sv })
                        .Where(re => re.sv.MaSv == maSv && re.htkt.htk.ht.hd.ThoiGianBd != null && re.htkt.htk.ht.hd.ThoiGianBd != null)
                        .Select(re => new LichPhanBienVTModel
                        {
                            MaDt = re.htkt.htk.ht.dt.MaDt,
                            TenDeTai = re.htkt.htk.ht.dt.TenDt,
                            ThoiGianBD = (DateTime)re.htkt.htk.ht.hd.ThoiGianBd,
                            ThoiGianKT = (DateTime)re.htkt.htk.ht.hd.ThoiGianKt,
                            DiaDiem = re.htkt.htk.ht.hd.DiaDiem,
                            LoaiLich = 1
                        })
                        .ToListAsync();
            var lichPBs = await _context.Phanbiens
                        .Join(_context.Detais, pb => pb.MaDt, dt => dt.MaDt, (pb, dt) => new { pb = pb, dt = dt })
                        .Join(_context.Dangkies, ht => ht.dt.MaDt, dk => dk.MaDt, (ht, dk) => new { ht = ht, dk = dk })
                        .Join(_context.Thamgia, htk => htk.dk.MaNhom, tg => tg.MaNhom, (htk, tg) => new { htk = htk, tg = tg })
                        .Join(_context.Sinhviens, htkt => htkt.tg.MaSv, sv => sv.MaSv, (htkt, sv) => new { htkt = htkt, sv = sv })
                        .Where(re => re.sv.MaSv == maSv && re.htkt.htk.ht.pb.ThoiGianBd != null && re.htkt.htk.ht.pb.ThoiGianBd != null)
                        .Select(re => new LichPhanBienVTModel
                        {
                            MaDt = re.htkt.htk.ht.dt.MaDt,
                            TenDeTai = re.htkt.htk.ht.dt.TenDt,
                            ThoiGianBD = (DateTime)re.htkt.htk.ht.pb.ThoiGianBd,
                            ThoiGianKT = (DateTime)re.htkt.htk.ht.pb.ThoiGianKt,
                            DiaDiem = re.htkt.htk.ht.pb.DiaDiem,
                            LoaiLich = 2
                        })
                        .ToListAsync();
            var lichHDongs = await _context.Hoidongs
                        .Join(_context.Hdphanbiens, hd => hd.MaHd, hdpb => hdpb.MaHd, (hd, hdpb) => new { hd = hd, hdpb = hdpb })
                        .Join(_context.Detais, hp => hp.hdpb.MaDt, dt => dt.MaDt, (hp, dt) => new { hp = hp, dt = dt })
                        .Join(_context.Dangkies, ht => ht.dt.MaDt, dk => dk.MaDt, (ht, dk) => new { ht = ht, dk = dk })
                        .Join(_context.Thamgia, htk => htk.dk.MaNhom, tg => tg.MaNhom, (htk, tg) => new { htk = htk, tg = tg })
                        .Join(_context.Sinhviens, htkt => htkt.tg.MaSv, sv => sv.MaSv, (htkt, sv) => new { htkt = htkt, sv = sv })
                        .Where(re => re.sv.MaSv == maSv && re.htkt.htk.ht.hp.hd.ThoiGianBd != null && re.htkt.htk.ht.hp.hd.ThoiGianBd != null)
                        .Select(re => new LichPhanBienVTModel
                        {
                            MaDt = re.htkt.htk.ht.dt.MaDt,
                            TenDeTai = re.htkt.htk.ht.dt.TenDt,
                            ThoiGianBD = (DateTime)re.htkt.htk.ht.hp.hd.ThoiGianBd,
                            ThoiGianKT = (DateTime)re.htkt.htk.ht.hp.hd.ThoiGianKt,
                            DiaDiem = re.htkt.htk.ht.hp.hd.DiaDiem,
                            LoaiLich = 3
                        })
                        .ToListAsync();
            return lichHTs.Concat(lichHDs).Concat(lichPBs).Concat(lichHDongs).OrderBy(l => l.ThoiGianBD).OrderByDescending(l => l.ThoiGianKT).ToList();
        }

        public async Task<List<DetaiModel>> GetSelectDetaiByGiangVienAsync(string maGv, string namHoc, int dot, int loaiLich)
        {
            if(loaiLich == 1)
            {
                var deTais = await _context.Detais
                            .Join(_context.Huongdans, dt => dt.MaDt, hd => hd.MaDt, (dt, hd) => new { dt = dt, hd = hd })
                            .Where(re => re.hd.MaGv == maGv && re.dt.NamHoc == namHoc && re.dt.Dot == dot &&
                            re.hd.ThoiGianBd == null && re.hd.ThoiGianKt == null && re.hd.DiaDiem == null)
                            .Select(re => re.dt)
                            .ToListAsync();
                return _mapper.Map<List<DetaiModel>>(deTais);
            }   
            else if(loaiLich == 2)
            {

                var deTais = await _context.Detais
                            .Join(_context.Phanbiens, dt => dt.MaDt, hd => hd.MaDt, (dt, hd) => new { dt = dt, hd = hd })
                            .Where(re => re.hd.MaGv == maGv && re.dt.NamHoc == namHoc && re.dt.Dot == dot &&
                            re.hd.ThoiGianBd == null && re.hd.ThoiGianKt == null && re.hd.DiaDiem == null)
                            .Select(re => re.dt)
                            .ToListAsync();
                return _mapper.Map<List<DetaiModel>>(deTais);
            }
            else if(loaiLich == 3)
            {

                return null;
            }
            else
            {

                return null;
            }
                        
        }    
    }
}
