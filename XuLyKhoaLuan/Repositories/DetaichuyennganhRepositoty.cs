using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Helpers;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class DetaichuyennganhRepositoty : IDetaichuyennganhRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public DetaichuyennganhRepositoty(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddDetaiChuyennganhsAsync(DetaiChuyennganhModel model)
        {
            var newDetaiChuyennganh = _mapper.Map<DetaiChuyennganh>(model);

            var detai = await _context.Detais.FindAsync(newDetaiChuyennganh.MaDt);
            var chuyennganh = await _context.Chuyennganhs.FindAsync(newDetaiChuyennganh.MaCn);

            if (detai == null || chuyennganh == null)
            {
                throw new errorMessage("Đề tài hoặc chuyên ngành không tồn tại!");
            }

            var isDeTai = await _context.DetaiChuyennganhs.AnyAsync(d 
                => d.MaDt == newDetaiChuyennganh.MaDt && d.MaCn == newDetaiChuyennganh.MaCn);
            if(isDeTai) 
            {
                throw new errorMessage("Đã tồn tại!");
            }
            _context.DetaiChuyennganhs!.Add(newDetaiChuyennganh);
            await _context.SaveChangesAsync();
            return newDetaiChuyennganh.MaCn + " - " + newDetaiChuyennganh.MaDt;
        }

        public async Task DeleteDetaiChuyennganhsAsync(DetaiChuyennganhModel model)
        {
            var delDetaiChuyennganh = await _context.DetaiChuyennganhs.SingleOrDefaultAsync(
                dc => dc.MaDt == model.MaDt && dc.MaCn == model.MaCn);
            if(delDetaiChuyennganh != null)
            {
                _context.DetaiChuyennganhs!.Remove(delDetaiChuyennganh);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DetaiChuyennganhModel>> GetAllDetaiChuyennganhsAsync()
        {
            var detaiChuyennganhs = await _context.DetaiChuyennganhs.ToListAsync();
            return _mapper.Map<List<DetaiChuyennganhModel>>(detaiChuyennganhs);
        }

        public async Task<List<DetaiChuyennganhModel>> GetDetaiChuyennganhByMaDTMaCNAsync(string? maDT, string? maCN)
        {
            if (maDT != null && maCN != null)
            {
                var detaiChuyennganh = await _context.DetaiChuyennganhs
                .Where(dtcn => dtcn.MaDt == maDT && dtcn.MaCn == maCN).ToListAsync();
                return _mapper.Map<List<DetaiChuyennganhModel>>(detaiChuyennganh);
            }
            else
            {
                if (maDT == null)
                {
                    var detaiChuyennganh = await _context.DetaiChuyennganhs
                    .Where(dtcn => dtcn.MaCn == maCN).ToListAsync();
                    return _mapper.Map<List<DetaiChuyennganhModel>>(detaiChuyennganh);
                }
                else
                {
                    var detaiChuyennganh = await _context.DetaiChuyennganhs
                    .Where(dtcn => dtcn.MaDt == maDT).ToListAsync();
                    return _mapper.Map<List<DetaiChuyennganhModel>>(detaiChuyennganh);
                }
            }
        }
    }
}
