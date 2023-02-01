
<<<<<<< Updated upstream
=======
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

>>>>>>> Stashed changes
namespace XuLyKhoaLuan.Repositories
{
    public class GiaovuRepository: IGiaovuRepository
    {
<<<<<<< Updated upstream
=======
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public GiaovuRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddGiaovusAsync(GiaovuModel model)
        {
            var newGiaovu = _mapper.Map<Giaovu>(model);
            _context.Giaovus!.Add(newGiaovu);
            await _context.SaveChangesAsync();
            return newGiaovu.MaGv;
        }

        public async Task DeleteGiaovusAsync(string maGV)
        {
            var deleteGiaovu = _context.Giaovus!.SingleOrDefault(dt => dt.MaGv.Equals(maGV));
            if (deleteGiaovu != null)
            {
                _context.Giaovus!.Remove(deleteGiaovu);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<GiaovuModel>> GetAllGiaovusAsync()
        {
            var Giaovus = await _context.Giaovus.ToListAsync();
            return _mapper.Map<List<GiaovuModel>>(Giaovus);
        }

        public async Task<GiaovuModel> GetGiaovuByIDAsync(string maGV)
        {
            var Giaovu = await _context.Giaovus.FindAsync(maGV);
            return _mapper.Map<GiaovuModel>(Giaovu);

        }

        public async Task UpdateGiaovusAsync(string maGV, GiaovuModel model)
        {
            if (maGV.Equals(model.MaGv))
            {
                var updateGiaovu = _mapper.Map<Giaovu>(model);
                _context.Giaovus.Update(updateGiaovu);
                await _context.SaveChangesAsync();
            }
        }
>>>>>>> Stashed changes
    }
}
