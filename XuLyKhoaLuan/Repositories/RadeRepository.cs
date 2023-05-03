using AutoMapper;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Helpers;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class RadeRepository : IRadeRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public RadeRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddRadesAsync(RadeModel model)
        {
            var newRade = _mapper.Map<Rade>(model);
            var giangVien = await _context.Giangviens.FindAsync(newRade.MaGv);
            var deTai = await _context.Detais.FindAsync(newRade.MaDt);
            if(giangVien == null || deTai == null)
            {
                throw new errorMessage("Giảng viên hoặc đề tài không tồn tại!");
            }
            var isRade = await _context.Rades.AnyAsync(
                rd => (rd.MaGv == newRade.MaGv && rd.MaDt == newRade.MaDt));
            if(isRade)
            {
                throw new errorMessage("Đã tồn tại!");
            }
            newRade.ThoiGian = DateTime.Now;
            _context.Rades.Add(newRade);
            await _context.SaveChangesAsync();
            return newRade.MaGv + " - " + newRade.MaDt;
        }

        public async Task DeleteRadeAsync(RadeModel delete)
        {
            var delRade = await _context.Rades.SingleOrDefaultAsync(
                rd => rd.MaGv == delete.MaGv && rd.MaDt == delete.MaDt);
            if(delRade!= null)
            {
                _context.Rades!.Remove(delRade);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<RadeModel>> GetAllRadesAsync()
        {
            var rades = await _context.Rades.ToListAsync();
            return _mapper.Map<List<RadeModel>>(rades);
        }

        public async Task<List<RadeModel>> GetRadeByMaGVMaDTAsync(string? maGV, string? maDT)
        {
            if (maGV != null && maDT != null)
            {
                var rades = await _context.Rades
                .Where(rd => rd.MaDt == maDT && rd.MaGv == maGV).ToListAsync();
                return _mapper.Map<List<RadeModel>>(rades);
            }
            else
            {
                if (maDT == null)
                {
                    var rades = await _context.Rades
                .Where(rd => rd.MaGv == maGV).ToListAsync();
                    return _mapper.Map<List<RadeModel>>(rades);
                }
                else
                {
                    var rades = await _context.Rades
                .Where(rd => rd.MaDt == maDT).ToListAsync();
                    return _mapper.Map<List<RadeModel>>(rades);
                }
            }
        }
    }
}
