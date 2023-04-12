using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class CongviecRepository : ICongviecRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public CongviecRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddCongviecsAsync(CongviecModel model)
        {
            var newCongviec = _mapper.Map<Congviec>(model);
            _context.Congviecs!.Add(newCongviec);
            await _context.SaveChangesAsync();
            return newCongviec.MaCv;
        }

        public async Task DeleteCongviecsAsync(string maCV)
        {
            var deleteCongviec = _context.Congviecs!.SingleOrDefault(dt => dt.MaCv.Equals(maCV));
            if (deleteCongviec != null)
            {
                _context.Congviecs!.Remove(deleteCongviec);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CongviecModel>> GetAllCongviecsAsync()
        {
            var Congviecs = await _context.Congviecs.ToListAsync();
            return _mapper.Map<List<CongviecModel>>(Congviecs);
        }

        public async Task<CongviecModel> GetCongviecByIDAsync(string maCV)
        {
            var Congviec = await _context.Congviecs.FindAsync(maCV);
            return _mapper.Map<CongviecModel>(Congviec);

        }

        public async Task UpdateCongviecsAsync(string maCV, CongviecModel model)
        {
            if (maCV.Equals(model.MaCv))
            {
                var updateCongviec = _mapper.Map<Congviec>(model);
                _context.Congviecs.Update(updateCongviec);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CongviecModel>> GetCongviecByMadtAsync(string maDT)
        {
            var congViecs = await _context.Detais
                        .Join(_context.Dangkies, dt => dt.MaDt, dk => dk.MaDt, (dt, dk) => new { dt = dt, dk = dk })
                        .Join(_context.Nhoms, dtk => dtk.dk.MaNhom, n => n.MaNhom, (dtk, n) => new { dtk = dtk, n = n })
                        .Join(_context.Congviecs, dtkn => dtkn.n.MaNhom, c => c.MaNhom, (dtkn, c) => new { dtkn = dtkn, c = c })
                        .Where(re => re.dtkn.dtk.dt.MaDt == maDT)
                        .Select(re => re.c)
                        .ToListAsync();
            return _mapper.Map<List<CongviecModel>>(congViecs);
        }
    }
}
