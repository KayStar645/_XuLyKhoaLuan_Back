using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

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
            string returnString = newTruongkhoa.MaKhoa + newTruongkhoa.MaGv;
            return returnString;
        }

        public async Task DeleteTruongkhoasAsync(TruongkhoaModel Truongkhoa)
        {
            var deleteTruongkhoa = _context.Truongkhoas!.SingleOrDefault(
                dTruongkhoa => dTruongkhoa.MaGv == Truongkhoa.MaGv && dTruongkhoa.MaKhoa == Truongkhoa.MaKhoa);
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

        public async Task<TruongkhoaModel> GetTruongkhoaByMaKhoaMaGVAsync(TruongkhoaModel truongkhoa)
        {
            var trKhoa = await _context.Truongkhoas.FindAsync(truongkhoa.MaKhoa, truongkhoa.MaGv);
            return _mapper.Map<TruongkhoaModel>(trKhoa);
        }

        public async Task<TruongkhoaModel> GetTruongkhoaByMaGVAsync(string maGV)
        {
            var truongKhoa = await _context.Truongkhoas.Where(k => k.MaGv == maGV && k.NgayNghi == null).SingleAsync();
            return _mapper.Map<TruongkhoaModel>(truongKhoa);
        }

        public async Task UpdateTruongkhoasAsync(TruongkhoaModel Truongkhoa, TruongkhoaModel model)
        {
            if (Truongkhoa.MaGv == model.MaGv && Truongkhoa.MaKhoa == model.MaKhoa)
            {
                var updateTruongkhoa = _mapper.Map<Truongkhoa>(model);
                _context.Truongkhoas.Update(updateTruongkhoa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
