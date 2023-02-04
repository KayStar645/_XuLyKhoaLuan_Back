using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class ThamgiaRepository:IThamgiaRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public ThamgiaRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddThamgiasAsync(ThamgiaModel model)
        {
            var newThamgia = _mapper.Map<Thamgia>(model);
            _context.Thamgias!.Add(newThamgia);
            await _context.SaveChangesAsync();
            string returnString = newThamgia.MaSv + newThamgia.NamHoc + newThamgia.Dot;
            return returnString;
        }

        public async Task DeleteThamgiasAsync(ThamgiaModel Thamgia)
        {
            var deleteThamgia = _context.Thamgias!.SingleOrDefault(
                thamGia => thamGia.NamHoc == Thamgia.NamHoc && thamGia.MaSv == Thamgia.MaSv
                && thamGia.Dot == Thamgia.Dot);
            if (deleteThamgia != null)
            {
                _context.Thamgias!.Remove(deleteThamgia);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ThamgiaModel>> GetAllThamgiasAsync()
        {
            var Thamgias = await _context.Thamgias.ToListAsync();
            return _mapper.Map<List<ThamgiaModel>>(Thamgias);
        }

        public async Task<ThamgiaModel> GetThamgiaByIDAsync(ThamgiaModel Thamgia)
        {
            var thamGia = await _context.Thamgias.FindAsync(Thamgia.MaSv, Thamgia.NamHoc, Thamgia.Dot);
            return _mapper.Map<ThamgiaModel>(thamGia);
        }

        public async Task UpdateThamgiasAsync(ThamgiaModel Thamgia, ThamgiaModel model)
        {
            if (Thamgia.NamHoc == model.NamHoc && Thamgia.MaSv == model.MaSv && Thamgia.Dot == model.Dot)
            {
                var updateThamgia = _mapper.Map<Thamgia>(model);
                _context.Thamgias.Update(updateThamgia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
