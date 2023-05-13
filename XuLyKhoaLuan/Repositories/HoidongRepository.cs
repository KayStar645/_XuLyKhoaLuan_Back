using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Repositories
{
    public class HoidongRepository : IHoidongRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public HoidongRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddHoidongsAsync(HoidongModel model)
        {
            var newHoidong = _mapper.Map<Hoidong>(model);
            _context.Hoidongs!.Add(newHoidong);
            await _context.SaveChangesAsync();
            return newHoidong.MaHd;
        }

        public async Task DeleteHoidongsAsync(string MaHd)
        {
            var deleteHoidong = _context.Hoidongs!.SingleOrDefault(dt => dt.MaHd.Equals(MaHd));
            if (deleteHoidong != null)
            {
                _context.Hoidongs!.Remove(deleteHoidong);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<HoidongModel>> GetAllHoidongsAsync()
        {
            var Hoidongs = await _context.Hoidongs.ToListAsync();
            return _mapper.Map<List<HoidongModel>>(Hoidongs);
        }

        public async Task<HoidongModel> GetHoidongByIDAsync(string MaHd)
        {
            var Hoidong = await _context.Hoidongs.FindAsync(MaHd);
            return _mapper.Map<HoidongModel>(Hoidong);

        }

        public async Task UpdateHoidongsAsync(string MaHd, HoidongModel model)
        {
            if (MaHd.Equals(model.MaHd))
            {
                var updateHoidong = _mapper.Map<Hoidong>(model);
                _context.Hoidongs.Update(updateHoidong);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<HoiDongVTModel>> GetHoidongsByBomonAsync(string maBm)
        {
            var hoiDongs = await _context.Hoidongs
                        .Join(_context.Thamgiahds, hd => hd.MaHd, tg => tg.MaHd, (hd, tg) => new { hd = hd, tg = tg })
                        .Where(re => re.hd.MaBm == maBm)
                        .Select(re => new HoiDongVTModel
                        {
                            MaHD = re.hd.MaHd,
                            TenHD = re.hd.TenHd,
                            NgayLap = re.hd.NgayLap,
                            ThoiGianBD = re.hd.ThoiGianBd,
                            ThoiGianKT = re.hd.ThoiGianKt,
                            DiaDiem = re.hd.DiaDiem,
                            ChuTich = new GiangVienVTModel(),
                            ThuKy = new GiangVienVTModel(),
                            UyViens = new List<GiangVienVTModel>()
                        })
                        .Distinct().ToListAsync();
            foreach(var hd in hoiDongs)
            {
                var giangViens = await _context.Thamgiahds
                                .Join(_context.Giangviens, tg => tg.MaGv, gv => gv.MaGv, (tg, gv) => new { tg = tg, gv = gv })
                                .Where(re => re.tg.MaHd == hd.MaHD)
                                .ToListAsync();
                foreach(var gv in giangViens)
                {
                    if(gv.tg.MaVt == "VT01")
                    {
                        hd.ChuTich = new GiangVienVTModel 
                        {
                            MaGV = gv.gv.MaGv,
                            TenGV = gv.gv.TenGv,
                            VaiTro = 3,
                            ChucVu = "Chủ tịch"
                        };
                    }   
                    else if (gv.tg.MaVt == "VT02")
                    {
                        hd.ThuKy = new GiangVienVTModel
                        {
                            MaGV = gv.gv.MaGv,
                            TenGV = gv.gv.TenGv,
                            VaiTro = 3,
                            ChucVu = "Thư ký"
                        };
                    }
                    else
                    {
                        hd.UyViens.Add(new GiangVienVTModel
                        {
                            MaGV = gv.gv.MaGv,
                            TenGV = gv.gv.TenGv,
                            VaiTro = 3,
                            ChucVu = "Ủy viên"
                        });
                    }
                }    
            }
            return hoiDongs;
        }

        public async Task<List<HoiDongVTModel>> GetHoidongsByGiangvienAsync(string maGv)
        {
            var hoiDongs = await _context.Hoidongs
                        .Join(_context.Thamgiahds, hd => hd.MaHd, tg => tg.MaHd, (hd, tg) => new { hd = hd, tg = tg })
                        .Where(re => re.tg.MaGv == maGv)
                        .Select(re => new HoiDongVTModel
                        {
                            MaHD = re.hd.MaHd,
                            TenHD = re.hd.TenHd,
                            NgayLap = re.hd.NgayLap,
                            ThoiGianBD = re.hd.ThoiGianBd,
                            ThoiGianKT = re.hd.ThoiGianKt,
                            DiaDiem = re.hd.DiaDiem,
                            ChuTich = new GiangVienVTModel(),
                            ThuKy = new GiangVienVTModel(),
                            UyViens = new List<GiangVienVTModel>()
                        })
                        .Distinct().ToListAsync();
            foreach (var hd in hoiDongs)
            {
                var giangViens = await _context.Thamgiahds
                                .Join(_context.Giangviens, tg => tg.MaGv, gv => gv.MaGv, (tg, gv) => new { tg = tg, gv = gv })
                                .Where(re => re.tg.MaHd == hd.MaHD)
                                .ToListAsync();
                foreach (var gv in giangViens)
                {
                    if (gv.tg.MaVt == "VT01")
                    {
                        hd.ChuTich = new GiangVienVTModel
                        {
                            MaGV = gv.gv.MaGv,
                            TenGV = gv.gv.TenGv,
                            VaiTro = 3,
                            ChucVu = "Chủ tịch"
                        };
                    }
                    else if (gv.tg.MaVt == "VT02")
                    {
                        hd.ThuKy = new GiangVienVTModel
                        {
                            MaGV = gv.gv.MaGv,
                            TenGV = gv.gv.TenGv,
                            VaiTro = 3,
                            ChucVu = "Thư ký"
                        };
                    }
                    else
                    {
                        hd.UyViens.Add(new GiangVienVTModel
                        {
                            MaGV = gv.gv.MaGv,
                            TenGV = gv.gv.TenGv,
                            VaiTro = 3,
                            ChucVu = "Ủy viên"
                        });
                    }
                }
            }
            return hoiDongs;
        }
    }
}
