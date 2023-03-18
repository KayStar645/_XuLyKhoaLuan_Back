using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class HdpbchamRepository : IHdpbchamRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public HdpbchamRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddHdpbchamsAsync(HdpbchamModel model)
        {
            var newHdpbcham = _mapper.Map<Hdpbcham>(model);
            _context.Hdpbchams!.Add(newHdpbcham);
            await _context.SaveChangesAsync();
            string returnString = newHdpbcham.MaGv + newHdpbcham.MaHd + newHdpbcham.MaDt + newHdpbcham.MaSv + newHdpbcham.NamHoc + newHdpbcham.Dot;
            return returnString;
        }

        public async Task DeleteHdpbchamsAsync(HdpbchamModel Hdpbcham)
        {
            var deleteHdpbcham = _context.Hdpbchams!.SingleOrDefault(
                hdpbCham => hdpbCham.MaHd == Hdpbcham.MaHd && hdpbCham.MaGv == Hdpbcham.MaGv
                && hdpbCham.MaDt == Hdpbcham.MaDt && hdpbCham.MaSv == Hdpbcham.MaSv
                && hdpbCham.NamHoc == Hdpbcham.NamHoc && hdpbCham.Dot == Hdpbcham.Dot);
            if (deleteHdpbcham != null)
            {
                _context.Hdpbchams!.Remove(deleteHdpbcham);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<HdpbchamModel>> GetAllHdpbchamsAsync()
        {
            var Hdpbchams = await _context.Hdpbchams.ToListAsync();
            return _mapper.Map<List<HdpbchamModel>>(Hdpbchams);
        }

        public async Task<HdpbchamModel> GetHdpbchamByIDAsync(HdpbchamModel hdpbCham)
        {
            var Hdpbcham = await _context.Hdpbchams.FindAsync(hdpbCham.MaGv, hdpbCham.MaHd, hdpbCham.MaDt, hdpbCham.MaSv, hdpbCham.NamHoc, hdpbCham.Dot);
            return _mapper.Map<HdpbchamModel>(Hdpbcham);

        }

        public async Task UpdateHdpbchamsAsync(HdpbchamModel hdpbCham, HdpbchamModel model)
        {
            if (hdpbCham.MaHd == model.MaHd && hdpbCham.MaGv == model.MaGv
                && hdpbCham.MaDt == model.MaDt && hdpbCham.MaSv == model.MaSv
                && hdpbCham.NamHoc == model.NamHoc && hdpbCham.Dot == model.Dot)
            {
                var updateHdpbcham = _mapper.Map<Hdpbcham>(model);
                _context.Hdpbchams.Update(updateHdpbcham);
                await _context.SaveChangesAsync();
            }
        }
    }
}
