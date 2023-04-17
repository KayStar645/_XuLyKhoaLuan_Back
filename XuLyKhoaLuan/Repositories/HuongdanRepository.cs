﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class HuongdanRepository : IHuongdanRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public HuongdanRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddHuongdansAsync(HuongdanModel model)
        {
            var newHuongdan = _mapper.Map<Huongdan>(model);
            _context.Huongdans!.Add(newHuongdan);
            await _context.SaveChangesAsync();
            string returnString = newHuongdan.MaGv + newHuongdan.MaDt;
            return returnString;
        }

        public async Task DeleteHuongdansAsync(HuongdanModel Huongdan)
        {
            var deleteHuongdan = await _context.Huongdans.FindAsync(Huongdan.MaGv, Huongdan.MaDt);
            if (deleteHuongdan != null)
            {
                _context.Huongdans!.Remove(deleteHuongdan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<HuongdanModel>> GetAllHuongdansAsync()
        {
            var Huongdans = await _context.Huongdans.ToListAsync();
            return _mapper.Map<List<HuongdanModel>>(Huongdans);
        }

        public async Task<HuongdanModel> GetHuongdanByIDAsync(HuongdanModel Huongdan)
        {
            var huongDan = await _context.Huongdans.FindAsync(Huongdan.MaGv, Huongdan.MaDt);
            return _mapper.Map<HuongdanModel>(huongDan);
        }

        public async Task UpdateHuongdansAsync(HuongdanModel Huongdan, HuongdanModel model)
        {
            if (Huongdan.MaDt == model.MaDt && Huongdan.MaGv == model.MaGv)
            {
                var updateHuongdan = _mapper.Map<Huongdan>(model);
                _context.Huongdans.Update(updateHuongdan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<GiangvienModel>> GetGiangvienByDetaiAsync(string maDT)
        {
            var giangViens = await _context.Giangviens
                            .Join(_context.Huongdans, gv => gv.MaGv, hd => hd.MaGv, (gv, hd) => new { gv = gv, hd = hd })
                            .Where(re => re.hd.MaDt == maDT)
                            .Select(re => re.gv)
                            .ToListAsync();
            return _mapper.Map<List<GiangvienModel>>(giangViens);
        }

        public async Task<List<DetaiModel>> GetDetaiByGVHDDotdkAsync(string maGV, string namHoc, int dot)
        {
            var deTais = await _context.Detais
                        .Join(_context.Huongdans, dt => dt.MaDt, hd => hd.MaDt, (dt, hd) => new { dt = dt, hd = hd })
                        .Where(re => re.hd.MaGv == maGV && re.dt.NamHoc == namHoc && re.dt.Dot == dot)
                        .Select(re => re.dt) .ToListAsync();
            return _mapper.Map<List<DetaiModel>>(deTais);
        }
    }
}
