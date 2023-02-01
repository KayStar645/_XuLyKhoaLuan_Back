using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class CongviecRepository:ICongviecRepository
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

    }
}
