using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class DangkyRepository : IDangkyRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public DangkyRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddDangkiesAsync(DangkyModel model)
        {
            var newDangky = _mapper.Map<Dangky>(model);
            _context.Dangkies!.Add(newDangky);
            await _context.SaveChangesAsync();
            string returnString = newDangky.MaNhom + newDangky.MaDt;
            return returnString;
        }

        public async Task DeleteDangkiesAsync(DangkyModel Dangky)
        {
            var deleteDangky = _context.Dangkies!.SingleOrDefault(
                dk => dk.MaDt == Dangky.MaDt && dk.MaNhom == Dangky.MaNhom);
            if (deleteDangky != null)
            {
                _context.Dangkies!.Remove(deleteDangky);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DangkyModel>> GetAllDangkiesAsync()
        {
            var Dangkies = await _context.Dangkies.ToListAsync();
            return _mapper.Map<List<DangkyModel>>(Dangkies);
        }

        public async Task<DangkyModel> GetDangkyByIDAsync(DangkyModel dk)
        {
            var Dangky = await _context.Dangkies.FindAsync(dk.MaNhom, dk.MaDt);
            return _mapper.Map<DangkyModel>(Dangky);

        }

        public async Task UpdateDangkiesAsync(DangkyModel dk, DangkyModel model)
        {
            if (dk.MaDt == model.MaDt && dk.MaNhom == model.MaNhom)
            {
                var updateDangky = _mapper.Map<Dangky>(model);
                _context.Dangkies.Update(updateDangky);
                await _context.SaveChangesAsync();
            }
        }
    }
}
