using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class DuyetdtRepository : IDuyetdtRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public DuyetdtRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddDuyetdtsAsync(DuyetdtModel model)
        {
            var newDuyetdt = _mapper.Map<Duyetdt>(model);
            _context.Duyetdts!.Add(newDuyetdt);
            await _context.SaveChangesAsync();
            string returnString = newDuyetdt.MaGv + newDuyetdt.MaDt + newDuyetdt.LanDuyet;
            return returnString;
        }

        public async Task DeleteDuyetdtsAsync(DuyetdtModel Duyetdt)
        {
            var deleteDuyetdt = await _context.Duyetdts!.SingleOrDefaultAsync(
                duyetDT => duyetDT.MaDt == Duyetdt.MaDt && duyetDT.MaGv == Duyetdt.MaGv
                && duyetDT.LanDuyet == Duyetdt.LanDuyet);
            if (deleteDuyetdt != null)
            {
                _context.Duyetdts!.Remove(deleteDuyetdt);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DuyetdtModel>> GetAllDuyetdtsAsync()
        {
            var Duyetdts = await _context.Duyetdts.ToListAsync();
            return _mapper.Map<List<DuyetdtModel>>(Duyetdts);
        }

        public async Task<DuyetdtModel> GetDuyetdtByIDAsync(DuyetdtModel Duyetdt)
        {
            var duyetDT = await _context.Duyetdts.FindAsync(Duyetdt.MaGv, Duyetdt.MaDt, Duyetdt.LanDuyet);
            return _mapper.Map<DuyetdtModel>(duyetDT);
        }

        public async Task UpdateDuyetdtsAsync(DuyetdtModel Duyetdt, DuyetdtModel model)
        {
            if (Duyetdt.MaDt == model.MaDt && Duyetdt.MaGv == model.MaGv && Duyetdt.LanDuyet == model.LanDuyet)
            {
                var updateDuyetdt = _mapper.Map<Duyetdt>(model);
                _context.Duyetdts.Update(updateDuyetdt);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DuyetdtModel>> GetDuyetdtByMaDT(string maDt)
        {
            var duyetDts = await _context.Duyetdts
                            .Where(d => d.MaDt == maDt)
                            .OrderByDescending(d => d.NgayDuyet)
                            .ToListAsync();
            return _mapper.Map<List<DuyetdtModel>>(duyetDts);
        }
    }
}
