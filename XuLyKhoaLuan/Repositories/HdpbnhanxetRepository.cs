using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class HdpbnhanxetRepository : IHdpbnhanxetRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public HdpbnhanxetRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddHdpbnhanxetsAsync(HdpbnhanxetModel model)
        {
            var newHdpbnhanxet = _mapper.Map<Hdpbnhanxet>(model);
            _context.Hdpbnhanxets!.Add(newHdpbnhanxet);
            await _context.SaveChangesAsync();
            string returnString = newHdpbnhanxet.MaGv + newHdpbnhanxet.MaDt;
            return returnString;
        }

        public async Task DeleteHdpbnhanxetsAsync(int ma)
        {
            var deleteHdpbnhanxet = _context.Hdpbnhanxets!.SingleOrDefault(
                dHdpbnhanxet => dHdpbnhanxet.Id == ma);
            if (deleteHdpbnhanxet != null)
            {
                _context.Hdpbnhanxets!.Remove(deleteHdpbnhanxet);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<HdpbnhanxetModel>> GetAllHdpbnhanxetsAsync()
        {
            var Hdpbnhanxets = await _context.Hdpbnhanxets.ToListAsync();
            return _mapper.Map<List<HdpbnhanxetModel>>(Hdpbnhanxets);
        }

        public async Task<HdpbnhanxetModel> GetHdpbnhanxetByIDAsync(int ma)
        {
            var hdpbNhanXet = await _context.Hdpbnhanxets.FindAsync(ma);
            return _mapper.Map<HdpbnhanxetModel>(hdpbNhanXet);
        }

        public async Task UpdateHdpbnhanxetsAsync(int ma, HdpbnhanxetModel model)
        {
            if (model.Id == ma)
            {
                var updateHdpbnhanxet = _mapper.Map<Hdpbnhanxet>(model);
                _context.Hdpbnhanxets.Update(updateHdpbnhanxet);
                await _context.SaveChangesAsync();
            }
        }
    }
}
