using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Repositories
{
    public class BaocaoRepository : IBaocaoRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public BaocaoRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<string> AddBaoCaosAsync(BaocaoModel model)
        {
            var newBaoCao = _mapper.Map<Baocao>(model);
            _context.Baocaos!.Add(newBaoCao);
            await _context.SaveChangesAsync();
            string returnString = newBaoCao.MaCv + newBaoCao.MaSv + newBaoCao.NamHoc + newBaoCao.Dot + newBaoCao.LanNop;
            return returnString;
        }

        public async Task DeleteBaoCaosAsync(BaocaoModel baocao)
        {
            var deleteBaocao = _context.Baocaos!.SingleOrDefault(
                bc => bc.MaSv == baocao.MaSv && bc.MaCv == baocao.MaCv 
                && bc.NamHoc == baocao.NamHoc && bc.Dot == baocao.Dot 
                && bc.LanNop == baocao.LanNop);
            if (deleteBaocao != null)
            {
                _context.Baocaos!.Remove(deleteBaocao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<BaocaoModel>> GetAllBaoCaosAsync()
        {
            var Baocaos = await _context.Baocaos.ToListAsync();
            return _mapper.Map<List<BaocaoModel>>(Baocaos);
        }

        public async Task<BaocaoModel> GetBaoCaoByIDAsync(BaocaoModel bc)
        {
            var Baocao = await _context.Baocaos.FindAsync(bc.MaCv, bc.MaSv, bc.NamHoc, bc.Dot, bc.LanNop);
            return _mapper.Map<BaocaoModel>(Baocao);

        }

        public async Task UpdateBaoCaosAsync(BaocaoModel bc, BaocaoModel model)
        {
            if (bc.MaSv == model.MaSv && bc.MaCv == model.MaCv 
                && bc.NamHoc == model.NamHoc && bc.Dot == model.Dot 
                && bc.LanNop == model.LanNop)
            {
                var updateBaocao = _mapper.Map<Baocao>(model);
                _context.Baocaos.Update(updateBaocao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
