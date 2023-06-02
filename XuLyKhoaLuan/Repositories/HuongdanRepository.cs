using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class HuongdanRepository : IHuongdanRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public HuongdanRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddHuongdansAsync(HuongdanModel model)
        {
            var newHuongdan = _mapper.Map<Huongdan>(model);
            _context.Huongdans!.Add(newHuongdan);
            await _context.SaveChangesAsync();
            string returnString = newHuongdan.MaGv + newHuongdan.MaDt;
            return returnString;
        }

        public async Task DeleteHuongdansAsync(HuongdanModel Huongdan)
        {
            var deleteHuongdan = await _context.Huongdans.FindAsync(Huongdan.MaGv, Huongdan.MaDt);
            if (deleteHuongdan != null)
            {
                _context.Huongdans!.Remove(deleteHuongdan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<HuongdanModel>> GetAllHuongdansAsync()
        {
            var Huongdans = await _context.Huongdans.ToListAsync();
            return _mapper.Map<List<HuongdanModel>>(Huongdans);
        }

        public async Task<HuongdanModel> GetHuongdanByIDAsync(HuongdanModel Huongdan)
        {
            var huongDan = await _context.Huongdans.FindAsync(Huongdan.MaGv, Huongdan.MaDt);
            return _mapper.Map<HuongdanModel>(huongDan);
        }

        public async Task UpdateHuongdansAsync(HuongdanModel Huongdan, HuongdanModel model)
        {
            if (Huongdan.MaDt == model.MaDt && Huongdan.MaGv == model.MaGv)
            {
                var updateHuongdan = _mapper.Map<Huongdan>(model);
                _context.Huongdans.Update(updateHuongdan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<GiangvienModel>> GetGiangvienByDetaiAsync(string maDT)
        {
            var giangViens = await _context.Giangviens
                            .Join(_context.Huongdans, gv => gv.MaGv, hd => hd.MaGv, (gv, hd) => new { gv = gv, hd = hd })
                            .Where(re => re.hd.MaDt == maDT)
                            .Select(re => re.gv)
                            .ToListAsync();
            return _mapper.Map<List<GiangvienModel>>(giangViens);
        }

        public async Task<List<DetaiModel>> GetDetaiByGVHDDotdkAsync(string maGV, string namHoc, int dot)
        {
            var deTais = await _context.Detais
                        .Join(_context.Huongdans, dt => dt.MaDt, hd => hd.MaDt, (dt, hd) => new { dt = dt, hd = hd })
                        .Join(_context.Dangkies, ht => ht.dt.MaDt, dk => dk.MaDt, (ht, dk) => new { ht = ht, dk = dk })
                        .Where(re => re.ht.hd.MaGv == maGV && re.ht.dt.NamHoc == namHoc && re.ht.dt.Dot == dot && re.dk.MaNhom != null)
                        .Select(re => re.ht.dt) .ToListAsync();
            return _mapper.Map<List<DetaiModel>>(deTais);
        }

        public async Task<int> CountDetaiHuongDanByGiangVienAsync(string maGv)
        {
            return await _context.Huongdans
                    .Where(hd => hd.MaGv == maGv)
                    .CountAsync();
        }

        public async Task<int> CheckThoiGianUpdateLich(string maGv, DateTime? start, DateTime? end)
        {
            // Kiểm tra thời gian được chọn giảng viên và sinh viên có bị trùng lịch không
            if (start != null)
            {
                // Kiểm tra hợp lệ thời gian
                if(start >= end)
                {
                    return 0;
                }    

                // Kiểm tra trùng lặp thời gian với giảng viên
                var isHasHD = await _context.Huongdans
                    .AnyAsync(hd => hd.ThoiGianBd != null && hd.MaGv.Equals(maGv) &&
                    !(hd.ThoiGianBd > end || hd.ThoiGianKt < start));

                var isHasPB = await _context.Phanbiens
                    .AnyAsync(pb => pb.ThoiGianBd != null && pb.MaGv.Equals(maGv) &&
                    !(pb.ThoiGianBd > end || pb.ThoiGianKt < start));

                var isHasHDPB = await _context.Thamgiahds
                    .Join(_context.Hoidongs, tg => tg.MaHd, hd => hd.MaHd, (tg, hd) => new { tg = tg, hd = hd })
                    .AnyAsync(re => re.tg.MaGv.Equals(maGv) && re.hd.ThoiGianBd != null &&
                    !(re.hd.ThoiGianBd > end || re.hd.ThoiGianKt < start));

                if (isHasHD || isHasPB || isHasHDPB)
                {
                    return -1;
                }
            }
            return 1;
        }
    }
}
