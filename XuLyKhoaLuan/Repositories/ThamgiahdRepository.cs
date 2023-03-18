using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class ThamgiahdRepository:IThamgiahdRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public ThamgiahdRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddThamgiahdsAsync(ThamgiahdModel model)
        {
            var newThamgiahd = _mapper.Map<Thamgiahd>(model);
            _context.Thamgiahds!.Add(newThamgiahd);
            await _context.SaveChangesAsync();
            string returnString = newThamgiahd.MaHd + newThamgiahd.MaGv;
            return returnString;
        }

        public async Task DeleteThamgiahdsAsync(ThamgiahdModel Thamgiahd)
        {
            var deleteThamgiahd = _context.Thamgiahds!.SingleOrDefault(
                thamGiaHD => thamGiaHD.MaHd == Thamgiahd.MaHd
                && thamGiaHD.MaGv == Thamgiahd.MaGv);
            if (deleteThamgiahd != null)
            {
                _context.Thamgiahds!.Remove(deleteThamgiahd);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ThamgiahdModel>> GetAllThamgiahdsAsync()
        {
            var Thamgiahds = await _context.Thamgiahds.ToListAsync();
            return _mapper.Map<List<ThamgiahdModel>>(Thamgiahds);
        }

        public async Task<ThamgiahdModel> GetThamgiahdByIDAsync(ThamgiahdModel thamGiaHD)
        {
            var Thamgiahd = await _context.Thamgiahds.FindAsync(thamGiaHD.MaHd, thamGiaHD.MaGv);
            return _mapper.Map<ThamgiahdModel>(Thamgiahd);
        }

        public async Task UpdateThamgiahdsAsync(ThamgiahdModel thamGiaHD, ThamgiahdModel model)
        {
            if (thamGiaHD.MaHd == model.MaHd
                && thamGiaHD.MaGv == model.MaGv)
            {
                var updateThamgiahd = _mapper.Map<Thamgiahd>(model);
                _context.Thamgiahds.Update(updateThamgiahd);
                await _context.SaveChangesAsync();
            }
        }
    }
}
