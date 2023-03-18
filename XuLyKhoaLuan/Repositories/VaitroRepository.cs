using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class VaitroRepository:IVaitroRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public VaitroRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddVaitrosAsync(VaitroModel model)
        {
            var newVaitro = _mapper.Map<Vaitro>(model);
            _context.Vaitros!.Add(newVaitro);
            await _context.SaveChangesAsync();
            return newVaitro.MaVt;
        }

        public async Task DeleteVaitrosAsync(string ma)
        {
            var deleteVaitro = _context.Vaitros!.SingleOrDefault(vaiTro => vaiTro.MaVt.Equals(ma));
            if (deleteVaitro != null)
            {
                _context.Vaitros!.Remove(deleteVaitro);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<VaitroModel>> GetAllVaitrosAsync()
        {
            var vaiTros = await _context.Vaitros.ToListAsync();
            return _mapper.Map<List<VaitroModel>>(vaiTros);
        }

        public async Task<VaitroModel> GetVaitroByIDAsync(string ma)
        {
            var vaiTro = await _context.Vaitros.FindAsync(ma);
            return _mapper.Map<VaitroModel>(vaiTro);

        }

        public async Task UpdateVaitrosAsync(string ma, VaitroModel model)
        {
            if (ma.Equals(model.MaVt))
            {
                var updateVaitro = _mapper.Map<Vaitro>(model);
                _context.Vaitros.Update(updateVaitro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
