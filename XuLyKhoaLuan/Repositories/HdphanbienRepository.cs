using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class HdphanbienRepository : IHdphanbienRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public HdphanbienRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddHdphanbiensAsync(HdphanbienModel model)
        {
            var newHdphanbien = _mapper.Map<Hdphanbien>(model);
            _context.Hdphanbiens!.Add(newHdphanbien);
            await _context.SaveChangesAsync();
            string returnString = newHdphanbien.MaGv + newHdphanbien.MaDt;
            return returnString;
        }

        public async Task DeleteHdphanbiensAsync(HdphanbienModel Hdphanbien)
        {
            var deleteHdphanbien = _context.Hdphanbiens!.SingleOrDefault(
                dHdphanbien => dHdphanbien.MaDt == Hdphanbien.MaDt && dHdphanbien.MaGv == Hdphanbien.MaGv);
            if (deleteHdphanbien != null)
            {
                _context.Hdphanbiens!.Remove(deleteHdphanbien);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<HdphanbienModel>> GetAllHdphanbiensAsync()
        {
            var Hdphanbiens = await _context.Hdphanbiens.ToListAsync();
            return _mapper.Map<List<HdphanbienModel>>(Hdphanbiens);
        }

        public async Task<HdphanbienModel> GetHdphanbienByIDAsync(HdphanbienModel Hdphanbien)
        {
            var hdPhanBien = await _context.Hdphanbiens.FindAsync(Hdphanbien.MaGv, Hdphanbien.MaDt);
            return _mapper.Map<HdphanbienModel>(hdPhanBien);
        }

        public async Task UpdateHdphanbiensAsync(HdphanbienModel Hdphanbien, HdphanbienModel model)
        {
            if (Hdphanbien.MaDt == model.MaDt && Hdphanbien.MaGv == model.MaGv)
            {
                var updateHdphanbien = _mapper.Map<Hdphanbien>(model);
                _context.Hdphanbiens.Update(updateHdphanbien);
                await _context.SaveChangesAsync();
            }
        }
    }
}
