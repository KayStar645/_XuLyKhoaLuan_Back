using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class DotdkRepository : IDotdkRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public DotdkRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddDotdksAsync(DotdkModel model)
        {
            var newDotdk = _mapper.Map<Dotdk>(model);
            _context.Dotdks!.Add(newDotdk);
            await _context.SaveChangesAsync();
            string returnString = newDotdk.NamHoc + newDotdk.Dot;
            return returnString;
        }

        public async Task DeleteDotdksAsync(DotdkModel Dotdk)
        {
            var deleteDotdk = _context.Dotdks!.SingleOrDefault(
                dotDK => dotDK.Dot == Dotdk.Dot && dotDK.NamHoc == Dotdk.NamHoc);
            if (deleteDotdk != null)
            {
                _context.Dotdks!.Remove(deleteDotdk);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DotdkModel>> GetAllDotdksAsync()
        {
            var Dotdks = await _context.Dotdks.ToListAsync();
            return _mapper.Map<List<DotdkModel>>(Dotdks);
        }

        public async Task<DotdkModel> GetDotdkByIDAsync(DotdkModel dotDK)
        {
            var Dotdk = await _context.Dotdks.FindAsync(dotDK.NamHoc, dotDK.Dot);
            return _mapper.Map<DotdkModel>(Dotdk);
        }
    }
}
