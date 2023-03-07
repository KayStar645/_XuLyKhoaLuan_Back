using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class GiangvienRepository : IGiangvienRepository
    {

        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public GiangvienRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddGiangviensAsync(GiangvienModel model)
        {
            var newGiangvien = _mapper.Map<Giangvien>(model);
            _context.Giangviens!.Add(newGiangvien);
            await _context.SaveChangesAsync();
            return newGiangvien.MaGv;
        }

        public async Task DeleteGiangviensAsync(string maGV)
        {
            var deleteGiangvien = _context.Giangviens!.SingleOrDefault(dt => dt.MaGv.Equals(maGV));
            if (deleteGiangvien != null)
            {
                _context.Giangviens!.Remove(deleteGiangvien);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<GiangvienModel>> GetAllGiangviensAsync()
        {
            var Giangviens = await _context.Giangviens.ToListAsync();
            return _mapper.Map<List<GiangvienModel>>(Giangviens);
        }

        public async Task<GiangvienModel> GetGiangvienByIDAsync(string maGV)
        {
            var Giangvien = await _context.Giangviens.FindAsync(maGV);
            return _mapper.Map<GiangvienModel>(Giangvien);
        }

        public async Task<List<GiangvienModel>> GetGiangvienByBoMonAsync(string maBM)
        {
            var Giangviens = await _context.Giangviens.Where(c => c.MaBm.Equals(maBM)).ToListAsync();
            return _mapper.Map<List<GiangvienModel>>(Giangviens);
        }

        public async Task<List<GiangvienModel>> SearchGiangvienByNameAsync(string name)
        {
            var Giangviens = await _context.Giangviens.Where(c => c.TenGv.Contains(name)).ToListAsync();
            return _mapper.Map<List<GiangvienModel>>(Giangviens);
        }

        public async Task UpdateGiangviensAsync(string maGV, GiangvienModel model)
        {
            if (maGV.Equals(model.MaGv))
            {
                var updateGiangvien = _mapper.Map<Giangvien>(model);
                _context.Giangviens.Update(updateGiangvien);
                await _context.SaveChangesAsync();
            }
        }
    }
}
