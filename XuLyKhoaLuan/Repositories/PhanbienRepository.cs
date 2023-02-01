using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class PhanbienRepository:IPhanbienRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public PhanbienRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddPhanbiensAsync(PhanbienModel model)
        {
            var newPhanbien = _mapper.Map<Phanbien>(model);
            _context.Phanbiens!.Add(newPhanbien);
            await _context.SaveChangesAsync();
            string returnString = newPhanbien.MaGv + newPhanbien.MaDt;
            return returnString;
        }

        public async Task DeletePhanbiensAsync(PhanbienModel Phanbien)
        {
            var deletePhanbien = _context.Phanbiens!.SingleOrDefault(
                phanBien => phanBien.MaGv == Phanbien.MaGv
                && phanBien.MaDt == Phanbien.MaDt);
            if (deletePhanbien != null)
            {
                _context.Phanbiens!.Remove(deletePhanbien);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<PhanbienModel>> GetAllPhanbiensAsync()
        {
            var Phanbiens = await _context.Phanbiens.ToListAsync();
            return _mapper.Map<List<PhanbienModel>>(Phanbiens);
        }

        public async Task<PhanbienModel> GetPhanbienByIDAsync(PhanbienModel phanBien)
        {
            var Phanbien = await _context.Phanbiens.FindAsync(phanBien.MaGv, phanBien.MaDt);
            return _mapper.Map<PhanbienModel>(Phanbien);
        }

        public async Task UpdatePhanbiensAsync(PhanbienModel phanBien, PhanbienModel model)
        {
            if (phanBien.MaGv == model.MaGv
                && phanBien.MaDt == model.MaDt)
            {
                var updatePhanbien = _mapper.Map<Phanbien>(model);
                _context.Phanbiens.Update(updatePhanbien);
                await _context.SaveChangesAsync();
            }
        }
    }
}
