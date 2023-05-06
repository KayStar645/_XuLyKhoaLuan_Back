using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface.NghiepVu;
using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Repositories.NghiepVu
{
    public class LichPhanBienRepo : ILichPhanBienRepo
    {
        private readonly XuLyKhoaLuanContext _context;

        public LichPhanBienRepo(XuLyKhoaLuanContext context)
        {
            this._context = context;
        }


        public async Task<List<LichPhanBienVTModel>> GetLichPhanBienByGvAsync(string maGv)
        {
            var lichHDs = await _context.Huongdans
                        .Join(_context.Detais, hd => hd.MaDt, dt => dt.MaDt, (hd, dt) => new { hd = hd, dt = dt })
                        .Where(re => re.hd.MaGv == maGv)
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
                        .Where(re => re.pb.MaGv == maGv)
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
            return lichHDs.Concat(lichPBs).Concat(lichHDongs).OrderBy(l => l.ThoiGianBD).OrderByDescending(l => l.ThoiGianKT).ToList();
        }
    }
}
