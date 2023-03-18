using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class DetaiRepository : IDetaiRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public DetaiRepository(XuLyKhoaLuanContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddDeTaisAsync(DetaiModel model)
        {
            var newDeTai = _mapper.Map<Detai>(model);
            _context.Detais!.Add(newDeTai);
            await _context.SaveChangesAsync();
            return newDeTai.MaDt;
        }

        public async Task DeleteDeTaisAsync(string maDT)
        {
            var deleteDeTai = _context.Detais!.SingleOrDefault(dt => dt.MaDt.Equals(maDT));
            if(deleteDeTai != null)
            {
                _context.Detais!.Remove(deleteDeTai);
                await _context.SaveChangesAsync();
            }    
        }

        public async Task<List<DetaiModel>> GetAllDeTaisAsync()
        {
            var deTais = await _context.Detais.ToListAsync();
            return _mapper.Map<List<DetaiModel>>(deTais);
        }

        public async Task<DetaiModel> GetDeTaiByIDAsync(string maDT)
        {
            var deTai = await _context.Detais.FindAsync(maDT);
            return _mapper.Map<DetaiModel>(deTai);

        }

        public async Task UpdateDeTaisAsync(string maDT, DetaiModel model)
        {
            if(maDT.Equals(model.MaDT))
            {
                var updateDeTai = _mapper.Map<Detai>(model);
                _context.Detais.Update(updateDeTai);
                await _context.SaveChangesAsync();
            }    
        }

        public async Task<List<DetaiModel>> GetDetaiByChuyenNganhAsync(string maCN)
        {
            var Detais = await (from dt in _context.Detais
                         join cn in _context.DetaiChuyennganhs on dt.MaDt equals cn.MaDt
                         where cn.MaCn.Equals(maCN)
                         select dt).ToListAsync();
            return _mapper.Map<List<DetaiModel>>(Detais);
        }
        public async Task<List<ChuyennganhModel>> GetChuyennganhOfDetaiAsync(string maDT)
        {
            var Chuyennganhs = await (from dt in _context.Detais
                                join cn in _context.Chuyennganhs on dt.MaDt equals cn.MaCn
                                where dt.MaDt.Equals(maDT)
                                select cn).ToListAsync();
            return _mapper.Map<List<ChuyennganhModel>>(Chuyennganhs);
        }
            
        public async Task<List<DetaiModel>> SearchDetaiByNameAsync(string name)
        {
            var Detais = await _context.Detais.Where(c => c.TenDt.Contains(name)).ToListAsync();
            return _mapper.Map <List<DetaiModel>>(Detais);
        }

    }
}
