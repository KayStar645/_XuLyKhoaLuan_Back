using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class LoimoiRepository : ILoimoiRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public LoimoiRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddLoimoisAsync(LoimoiModel model)
        {
            var newLoimoi = _mapper.Map<Loimoi>(model);
            _context.Loimois!.Add(newLoimoi);
            await _context.SaveChangesAsync();
            string returnString = newLoimoi.MaSv + newLoimoi.NamHoc + newLoimoi.Dot + newLoimoi.MaNhom;
            return returnString;
        }

        public async Task DeleteLoimoisAsync(LoimoiModel Loimoi)
        {
            var deleteLoimoi = _context.Loimois!.SingleOrDefault(
                loiMoi => loiMoi.MaSv == Loimoi.MaSv 
                && loiMoi.MaNhom == Loimoi.MaNhom
                && loiMoi.Dot == Loimoi.Dot 
                && loiMoi.NamHoc == Loimoi.NamHoc);
            if (deleteLoimoi != null)
            {
                _context.Loimois!.Remove(deleteLoimoi);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<LoimoiModel>> GetAllLoimoisAsync()
        {
            var Loimois = await _context.Loimois.ToListAsync();
            return _mapper.Map<List<LoimoiModel>>(Loimois);
        }

        public async Task<LoimoiModel> GetLoimoiByIDAsync(LoimoiModel loiMoi)
        {
            var Loimoi = await _context.Loimois.FindAsync(loiMoi.MaSv, loiMoi.MaNhom, loiMoi.NamHoc, loiMoi.Dot);
            return _mapper.Map<LoimoiModel>(Loimoi);
        }

        public async Task UpdateLoimoisAsync(LoimoiModel loiMoi, LoimoiModel model)
        {
            if (loiMoi.MaSv == model.MaSv
                && loiMoi.MaNhom == model.MaNhom
                && loiMoi.Dot == model.Dot
                && loiMoi.NamHoc == model.NamHoc)
            {
                var updateLoimoi = _mapper.Map<Loimoi>(model);
                _context.Loimois.Update(updateLoimoi);
                await _context.SaveChangesAsync();
            }
        }
    }
}
