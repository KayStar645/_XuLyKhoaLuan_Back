using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class TruongbmRepository:ITruongbmRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public TruongbmRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddTruongbmsAsync(TruongbmModel model)
        {
            var newTruongbm = _mapper.Map<Truongbm>(model);
            _context.Truongbms!.Add(newTruongbm);
            await _context.SaveChangesAsync();
            string returnString = newTruongbm.MaBm + newTruongbm.MaGv;
            return returnString;
        }

        public async Task DeleteTruongbmsAsync(TruongbmModel Truongbm)
        {
            var deleteTruongbm = _context.Truongbms!.SingleOrDefault(
                dTruongbm => dTruongbm.MaGv == Truongbm.MaGv && dTruongbm.MaBm == Truongbm.MaBm);
            if (deleteTruongbm != null)
            {
                _context.Truongbms!.Remove(deleteTruongbm);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TruongbmModel>> GetAllTruongbmsAsync()
        {
            var Truongbms = await _context.Truongbms.ToListAsync();
            return _mapper.Map<List<TruongbmModel>>(Truongbms);
        }

        public async Task<TruongbmModel> GetTruongbmByIDAsync(TruongbmModel Truongbm)
        {
            var hdCham = await _context.Truongbms.FindAsync(Truongbm.MaBm, Truongbm.MaGv);
            return _mapper.Map<TruongbmModel>(hdCham);
        }

        public async Task UpdateTruongbmsAsync(TruongbmModel Truongbm, TruongbmModel model)
        {
            if (Truongbm.MaGv == model.MaGv && Truongbm.MaBm == model.MaBm)
            {
                var updateTruongbm = _mapper.Map<Truongbm>(model);
                _context.Truongbms.Update(updateTruongbm);
                await _context.SaveChangesAsync();
            }
        }
    }
}
