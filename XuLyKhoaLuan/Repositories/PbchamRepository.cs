using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class PbchamRepository:IPbchamRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public PbchamRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddPbchamsAsync(PbchamModel model)
        {
            var newPbcham = _mapper.Map<Pbcham>(model);
            _context.Pbchams!.Add(newPbcham);
            await _context.SaveChangesAsync();
            string returnString = newPbcham.MaGv + newPbcham.MaDt;
            return returnString;
        }

        public async Task DeletePbchamsAsync(PbchamModel Pbcham)
        {
            var deletePbcham = _context.Pbchams!.SingleOrDefault(
                pbCham => pbCham.MaGv == Pbcham.MaGv
                && pbCham.MaDt == Pbcham.MaDt);
            if (deletePbcham != null)
            {
                _context.Pbchams!.Remove(deletePbcham);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<PbchamModel>> GetAllPbchamsAsync()
        {
            var Pbchams = await _context.Pbchams.ToListAsync();
            return _mapper.Map<List<PbchamModel>>(Pbchams);
        }

        public async Task<PbchamModel> GetPbchamByIDAsync(PbchamModel pbCham)
        {
            var Pbcham = await _context.Pbchams.FindAsync(pbCham.MaGv, pbCham.MaDt);
            return _mapper.Map<PbchamModel>(Pbcham);
        }

        public async Task UpdatePbchamsAsync(PbchamModel pbCham, PbchamModel model)
        {
            if (pbCham.MaGv == model.MaGv
                && pbCham.MaDt == model.MaDt)
            {
                var updatePbcham = _mapper.Map<Pbcham>(model);
                _context.Pbchams.Update(updatePbcham);
                await _context.SaveChangesAsync();
            }
        }
    }
}
