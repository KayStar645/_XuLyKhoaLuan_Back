using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class ThongbaoRepository:IThongbaoRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public ThongbaoRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddThongbaosAsync(ThongbaoModel model)
        {
            var newThongbao = _mapper.Map<Thongbao>(model);
            _context.Thongbaos!.Add(newThongbao);
            await _context.SaveChangesAsync();
            return newThongbao.MaTb.ToString();
        }

        public async Task DeleteThongbaosAsync(int ma)
        {
            var deleteThongbao = _context.Thongbaos!.SingleOrDefault(
                dThongbao => dThongbao.MaTb == ma);
            if (deleteThongbao != null)
            {
                _context.Thongbaos!.Remove(deleteThongbao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ThongbaoModel>> GetAllThongbaosAsync()
        {
            var Thongbaos = await _context.Thongbaos.ToListAsync();
            return _mapper.Map<List<ThongbaoModel>>(Thongbaos);
        }

        public async Task<ThongbaoModel> GetThongbaoByIDAsync(int ma)
        {
            var thongBao = await _context.Thongbaos.FindAsync(ma);
            return _mapper.Map<ThongbaoModel>(thongBao);
        }

        public async Task UpdateThongbaosAsync(int ma, ThongbaoModel model)
        {
            if (model.MaTb == ma)
            {
                var updateThongbao = _mapper.Map<Thongbao>(model);
                _context.Thongbaos.Update(updateThongbao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
