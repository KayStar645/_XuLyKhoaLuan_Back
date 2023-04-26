using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface.TraoDoi;
using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Repositories.BinhLuan
{
    public class TraodoiRepo : ITraodoiRepo
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public TraodoiRepo(XuLyKhoaLuanContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<TraodoiModel>> GetAllTraoDoiMotCongViec(string maCv)
        {
            var binhLuanList = await _context.Binhluans
                .Join(_context.Sinhviens, b => b.MaSv, sv => sv.MaSv, (b, sv) => new { b = b, sv = sv })
                .Where(re => re.b.MaCv == maCv)
                .Select(re => new TraodoiModel
                {
                    TenHienThi = re.b.MaSv + " - " + re.sv.TenSv,
                    VaiTro = "Sinh viên",
                    ThoiGian = re.b.ThoiGian ?? DateTime.MinValue,
                    NoiDung = re.b.NoiDung ?? ""
                })
                .ToListAsync();

            var hdGopyList = await _context.Hdgopies
                .Join(_context.Giangviens, g => g.MaGv, gv => gv.MaGv, (g, gv) => new { g = g, gv = gv })
                .Where(re => re.g.MaCv == maCv)
                .Select(re => new TraodoiModel
                {
                    TenHienThi = re.gv.TenGv,
                    VaiTro = "Giảng viên",
                    ThoiGian = re.g.ThoiGian ?? DateTime.MinValue,
                    NoiDung = re.g.NoiDung ?? ""
                })
                .ToListAsync();

            return binhLuanList.Concat(hdGopyList).OrderBy(t => t.ThoiGian).ToList();
        }
    }
}
