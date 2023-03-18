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
            var deleteHdcham = _context.Hdchams!.SingleOrDefault(
                dHdcham => dHdcham.MaDt == Hdcham.MaDt && dHdcham.MaGv == Hdcham.MaGv);
            if (deleteHdcham != null)
            {
                _context.Hdchams!.Remove(deleteHdcham);
                await _context.SaveChangesAsync();
            }
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
