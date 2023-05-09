using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class PbchamRepository:IPbchamRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public PbchamRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddPbchamsAsync(PbchamModel model)
        {
            var newPbcham = _mapper.Map<Pbcham>(model);
            _context.Pbchams!.Add(newPbcham);
            await _context.SaveChangesAsync();
            string returnString = newPbcham.MaGv + newPbcham.MaDt;
            return returnString;
        }

        public async Task DeletePbchamsAsync(PbchamModel Pbcham)
        {
            var deletePbcham = _context.Pbchams!
                .SingleOrDefault(p => p.MaGv == Pbcham.MaGv && p.MaDt == Pbcham.MaDt &&
                p.MaSv == Pbcham.MaSv && p.NamHoc == Pbcham.NamHoc && p.Dot == Pbcham.Dot);
            if (deletePbcham != null)
            {
                _context.Pbchams!.Remove(deletePbcham);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> DeletePbchamsByGvDtAsync(string maGv, string maDt, string namHoc, int dot)
        {
            var sinhViens = await _context.Sinhviens
                            .Join(_context.Thamgia, sv => sv.MaSv, tg => tg.MaSv, (sv, tg) => new { sv = sv, tg = tg })
                            .Join(_context.Nhoms, svtg => svtg.tg.MaNhom, n => n.MaNhom, (svtg, n) => new { svtg = svtg, n = n })
                            .Join(_context.Dangkies, svtgn => svtgn.n.MaNhom, dk => dk.MaNhom, (svtgndk, dk) => new { svtgndk = svtgndk, dk = dk })
                            .Where(re => re.dk.MaDt == maDt)
                            .Select(re => re.svtgndk.svtg.sv)
                            .ToListAsync();
            if (sinhViens.Count == 0)
            {
                return false;
            }
            foreach (var sv in sinhViens)
            {
                // Nếu tồn tại 1 sinh viên đã chấm điểm (!= -1) thì không được xóa điểm nhóm này
                var isChamDiem = await _context.Pbchams.Where(h => h.MaSv == sv.MaSv && h.Diem != -1).AnyAsync();
                if (isChamDiem) { return false; }
            }
            foreach (var sv in sinhViens)
            {
                PbchamModel model = new()
                {
                    MaGv = maGv,
                    MaDt = maDt,
                    MaSv = sv.MaSv,
                    NamHoc = namHoc,
                    Dot = dot
                };
                await DeletePbchamsAsync(model);
            }
            return true;
        }

        public async Task<List<PbchamModel>> GetAllPbchamsAsync()
        {
            var Pbchams = await _context.Pbchams.ToListAsync();
            return _mapper.Map<List<PbchamModel>>(Pbchams);
        }

        public async Task<PbchamModel> GetPbchamByIDAsync(PbchamModel pbCham)
        {
            var Pbcham = await _context.Pbchams.FindAsync(pbCham.MaGv, pbCham.MaDt);
            return _mapper.Map<PbchamModel>(Pbcham);
        }

        public async Task UpdatePbchamsAsync(PbchamModel pbCham, PbchamModel model)
        {
            if (pbCham.MaGv == model.MaGv
                && pbCham.MaDt == model.MaDt)
            {
                var updatePbcham = _mapper.Map<Pbcham>(model);
                _context.Pbchams.Update(updatePbcham);
                await _context.SaveChangesAsync();
            }
        }
    }
}
