using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class TruongkhoaRepository: ITruongkhoaRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public TruongkhoaRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddTruongkhoasAsync(TruongkhoaModel model)
        {
            var newTruongkhoa = _mapper.Map<Truongkhoa>(model);
            _context.Truongkhoas!.Add(newTruongkhoa);
            await _context.SaveChangesAsync();
            return newTruongkhoa.MaTk.ToString();
        }

        public async Task DeleteTruongkhoasAsync(int maTk)
        {
            var deleteTruongkhoa = _context.Truongkhoas!.SingleOrDefault(
                dTruongkhoa => dTruongkhoa.MaTk == maTk);
            if (deleteTruongkhoa != null)
            {
                _context.Truongkhoas!.Remove(deleteTruongkhoa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TruongkhoaModel>> GetAllTruongkhoasAsync()
        {
            var Truongkhoas = await _context.Truongkhoas.ToListAsync();
            return _mapper.Map<List<TruongkhoaModel>>(Truongkhoas);
        }

        public async Task<TruongkhoaModel> GetTruongkhoaByIDAsync(int maTk)
        {
            var trKhoa = await _context.Truongkhoas.FindAsync(maTk);
            return _mapper.Map<TruongkhoaModel>(trKhoa);
        }

        public async Task<string> CheckTruongKhoaByMaGVAsync(string maGV)
        {
            // Lấy khoa mà giảng viên đang công tác
            var maKhoa = await _context.Giangviens
                            .Join(_context.Bomons, g => g.MaBm, b => b.MaBm, (g, b) => new { g, b })
                            .Join(_context.Khoas, bk => bk.b.MaKhoa, k => k.MaKhoa, (bk, k) => new { bk, k })
                            .Where(bkk => bkk.bk.g.MaGv == maGV)
                            .Select(bkk => bkk.k.MaKhoa).SingleAsync();

            // Kiểm tra giảng viên đó có phải là trưởng khoa không
            var isTruongKhoa = await _context.Truongkhoas.AnyAsync(
                t => t.MaKhoa == maKhoa && t.MaGv == maGV &&
                (t.NgayNghi == null || t.NgayNghi > DateTime.Now));
            if(isTruongKhoa)
                return maKhoa;
            return "";
        }

        public async Task UpdateTruongkhoasAsync(int maTk, TruongkhoaModel model)
        {
            if (maTk == model.MaTk)
            {
                var updateTruongkhoa = _mapper.Map<Truongkhoa>(model);
                _context.Truongkhoas.Update(updateTruongkhoa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
