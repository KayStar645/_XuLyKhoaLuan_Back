using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class XacnhanRepository : IXacnhanRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public XacnhanRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddXacnhansAsync(XacnhanModel model)
        {
            var newXacnhan = _mapper.Map<Xacnhan>(model);
            _context.Xacnhans!.Add(newXacnhan);
            await _context.SaveChangesAsync();
            string returnString = newXacnhan.MaGv + newXacnhan.MaDt;
            return returnString;
        }

        public async Task DeleteXacnhansAsync(XacnhanModel xacNhan)
        {
            var deleteXacnhan = _context.Xacnhans!.SingleOrDefault(
                dXacnhan => dXacnhan.MaGv == xacNhan.MaGv && dXacnhan.MaDt == xacNhan.MaDt);
            if (deleteXacnhan != null)
            {
                _context.Xacnhans!.Remove(deleteXacnhan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<XacnhanModel>> GetAllXacnhansAsync()
        {
            var Xacnhans = await _context.Xacnhans.ToListAsync();
            return _mapper.Map<List<XacnhanModel>>(Xacnhans);
        }

        public async Task<XacnhanModel> GetXacnhanByIDAsync(XacnhanModel Xacnhan)
        {
            var xacNhan = await _context.Xacnhans.FindAsync(Xacnhan.MaGv, Xacnhan.MaDt);
            return _mapper.Map<XacnhanModel>(xacNhan);
        }

        public async Task UpdateXacnhansAsync(XacnhanModel xacNhan, XacnhanModel model)
        {
            if (model.MaGv == xacNhan.MaGv && model.MaDt == xacNhan.MaDt)
            {
                var updateXacnhan = _mapper.Map<Xacnhan>(model);
                _context.Xacnhans.Update(updateXacnhan);
                await _context.SaveChangesAsync();
            }
        }
    }
}
