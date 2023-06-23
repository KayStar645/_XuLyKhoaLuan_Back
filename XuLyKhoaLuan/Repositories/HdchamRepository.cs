using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class HdchamRepository : IHdchamRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public HdchamRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddHdchamsAsync(HdchamModel model)
        {
            var newHdcham = _mapper.Map<Hdcham>(model);
            _context.Hdchams!.Add(newHdcham);
            await _context.SaveChangesAsync();
            string returnString = newHdcham.MaGv + newHdcham.MaDt;
            return returnString;
        }

        public async Task DeleteHdchamsAsync(HdchamModel Hdcham)
        {
            var deleteHdcham = _context.Hdchams!
                .SingleOrDefault(h => h.MaDt == Hdcham.MaDt && h.MaGv == Hdcham.MaGv &&
                h.MaSv == Hdcham.MaSv && h.NamHoc == Hdcham.NamHoc && h.Dot == Hdcham.Dot);
            if (deleteHdcham != null)
            {
                _context.Hdchams!.Remove(deleteHdcham);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteHdchamsByGvDtAsync(string maGv, string maDt, string namHoc, int dot)
        {
            var sinhViens = await _context.Sinhviens
                            .Join(_context.Thamgia, sv => sv.MaSv, tg => tg.MaSv, (sv, tg) => new { sv = sv, tg = tg })
                            .Join(_context.Nhoms, svtg => svtg.tg.MaNhom, n => n.MaNhom, (svtg, n) => new { svtg = svtg, n = n })
                            .Join(_context.Dangkies, svtgn => svtgn.n.MaNhom, dk => dk.MaNhom, (svtgndk, dk) => new { svtgndk = svtgndk, dk = dk })
                            .Where(re => re.dk.MaDt == maDt)
                            .Select(re => re.svtgndk.svtg.sv)
                            .ToListAsync();
    
            foreach(var sv in sinhViens)
            {
                // Nếu tồn tại 1 sinh viên đã chấm điểm (!= -1) thì không được xóa điểm nhóm này
                var isChamDiem = await _context.Hdchams.Where(h => h.MaSv == sv.MaSv && h.Diem != -1 && h.MaDt == maDt).AnyAsync();
                if(isChamDiem) { return false; }
            }
            foreach (var sv in sinhViens)
            {
                HdchamModel model = new()
                {
                    MaGv = maGv,
                    MaDt = maDt,
                    MaSv = sv.MaSv,
                    NamHoc = namHoc,
                    Dot = dot
                };
                await DeleteHdchamsAsync(model);
            }
            return true;
        }

        public async Task<List<HdchamModel>> GetAllHdchamsAsync()
        {
            var Hdchams = await _context.Hdchams.ToListAsync();
            return _mapper.Map<List<HdchamModel>>(Hdchams);
        }

        public async Task<HdchamModel> GetHdchamByIDAsync(HdchamModel Hdcham)
        {
            var hdCham = await _context.Hdchams.FindAsync(Hdcham.MaGv, Hdcham.MaDt);
            return _mapper.Map<HdchamModel>(hdCham);
        }

        public async Task UpdateHdchamsAsync(HdchamModel Hdcham, HdchamModel model)
        {
            if (Hdcham.MaDt == model.MaDt && Hdcham.MaGv == model.MaGv)
            {
                var updateHdcham = _mapper.Map<Hdcham>(model);
                _context.Hdchams.Update(updateHdcham);
                await _context.SaveChangesAsync();
            }
        }
    }
}
