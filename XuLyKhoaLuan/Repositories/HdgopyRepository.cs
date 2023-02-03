using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class HdgopyRepository : IHdgopyRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public HdgopyRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddHdgopiesAsync(HdgopyModel model)
        {
            var newHdgopy = _mapper.Map<Hdgopy>(model);
            _context.Hdgopies!.Add(newHdgopy);
            await _context.SaveChangesAsync();
            string returnString = newHdgopy.MaGv + newHdgopy.MaDt;
            return returnString;
        }

        public async Task DeleteHdgopiesAsync(int ma)
        {
            var deleteHdgopy = _context.Hdgopies!.SingleOrDefault(
                dHdgopy => dHdgopy.Id == ma);
            if (deleteHdgopy != null)
            {
                _context.Hdgopies!.Remove(deleteHdgopy);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<HdgopyModel>> GetAllHdgopiesAsync()
        {
            var Hdgopies = await _context.Hdgopies.ToListAsync();
            return _mapper.Map<List<HdgopyModel>>(Hdgopies);
        }

        public async Task<HdgopyModel> GetHdgopyByIDAsync(int ma)
        {
            var hdgy = await _context.Hdgopies.FindAsync(ma);
            return _mapper.Map<HdgopyModel>(hdgy);
        }

        public async Task UpdateHdgopiesAsync(int ma, HdgopyModel model)
        {
            if (model.Id == ma)
            {
                var updateHdgopy = _mapper.Map<Hdgopy>(model);
                _context.Hdgopies.Update(updateHdgopy);
                await _context.SaveChangesAsync();
            }
        }
    }
}
