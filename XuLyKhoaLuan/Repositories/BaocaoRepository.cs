﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Models.VirtualModel;

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

        public async Task<int> createLanNop(string maCv, string maSv, string namHoc, int dot)
        {
            var hasBaocao = await _context.Baocaos
                .AnyAsync(b => b.MaCv == maCv && b.MaSv == maSv && b.NamHoc == namHoc && b.Dot == dot);

            if (hasBaocao)
            {
                var maxLanNop = await _context.Baocaos
                    .Where(b => b.MaCv == maCv && b.MaSv == maSv && b.NamHoc == namHoc && b.Dot == dot)
                    .MaxAsync(b => b.LanNop);
                return (int)maxLanNop + 1;
            }
            else
            {
                return 1;
            }
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

        public async Task<List<BaoCaoVTModel>> GetBaocaoByMacv(string maCv, string? maSv)
        {
            var baoCaos = await _context.Baocaos
                .Join(_context.Sinhviens, bc => bc.MaSv, sv => sv.MaSv, (bc, sv) => new { bc = bc, sv = sv })
                .Where(re => re.bc.MaCv.Equals(maCv) && (string.IsNullOrEmpty(maSv) || re.bc.MaSv == maSv))
                .Select(re => new BaoCaoVTModel
                {
                    maCv = re.bc.MaCv,
                    maSv = re.sv.MaSv,
                    tenSv = re.sv.TenSv,
                    namHoc = re.bc.NamHoc,
                    dot = re.bc.Dot,
                    tgNop = re.bc.ThoiGianNop,
                    file = re.bc.FileBc,

                }).ToListAsync();
            return baoCaos;            
        }
    }
}
