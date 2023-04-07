using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Helpers;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

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

        public async Task DeleteTruongbmsAsync(int maTbm)
        {
            var deleteTruongbm = _context.Truongbms!.SingleOrDefault(
                dTruongbm => dTruongbm.MaTbm == maTbm);
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

        public async Task<TruongbmModel> CheckTruongBomonByMaGVAsync(string maGV)
        {
            // Lấy mã bộ môn giảng viên đang công tác
            var gv = await _context.Giangviens.FindAsync(maGV);

            // Kiểm tra đó có phải trưởng bộ môn của bộ môn đó không? (chưa nghĩ)
            var truongBm = await _context.Truongbms.Where(b => b.MaBm == gv.MaBm &&
                        b.MaGv== maGV && (b.NgayNghi == null || b.NgayNghi > DateTime.Now)).SingleAsync();
            if (truongBm == null)
            {
                throw new errorMessage("Giảng viên này không phải là trưởng bộ môn!");
            }
            return _mapper.Map<TruongbmModel>(truongBm);
        }

        public async Task<bool> IsTruongBomonByMaGVAsync(string isMaGV)
        {
            // Lấy mã bộ môn giảng viên đang công tác
            var gv = await _context.Giangviens.FindAsync(isMaGV);

            // Kiểm tra đó có phải trưởng bộ môn của bộ môn đó không? (chưa nghĩ)
            var isTruongBm = await _context.Truongbms.AnyAsync(b => b.MaBm == gv.MaBm &&
                        b.MaGv == isMaGV && (b.NgayNghi == null || b.NgayNghi > DateTime.Now));
            return isTruongBm;
        }

        public async Task<TruongbmModel> GetTruongbmByIDAsync(int maTbm)
        {
            var hdCham = await _context.Truongbms.FindAsync(maTbm);
            return _mapper.Map<TruongbmModel>(hdCham);
        }

        public async Task UpdateTruongbmsAsync(int maTbm, TruongbmModel model)
        {
            if (maTbm == model.MaTbm)
            {
                var updateTruongbm = _mapper.Map<Truongbm>(model);
                _context.Truongbms.Update(updateTruongbm);
                await _context.SaveChangesAsync();
            }
        }
    }
}
