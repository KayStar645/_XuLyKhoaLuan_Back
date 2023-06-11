using AutoMapper;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class GapMatHdRepository : IGapMatHdRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public GapMatHdRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddGapMatAsync(GapMatHdModel model)
        {
            var newGapMat = _mapper.Map<GapMatHd>(model);
            _context.GapMatHds!.Add(newGapMat);
            await _context.SaveChangesAsync();
            return newGapMat.Id.ToString();
        }

        public async Task UpdateGapMatAsync(int id, GapMatHdModel model)
        {
            if (model.Id == id)
            {
                var update = _mapper.Map<GapMatHd>(model);
                _context.GapMatHds.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
