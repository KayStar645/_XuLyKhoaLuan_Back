using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace XuLyKhoaLuan.Repositories
{
    public class DuyetdtRepository : IDuyetdtRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public DuyetdtRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddDuyetdtsAsync(DuyetdtModel model)
        {
            // Tự động cập nhật lần duyệt đề tài
            model.LanDuyet = (await maxLanDuyetdtAsync(model.MaGv, model.MaDt)) + 1;

            var newDuyetdt = _mapper.Map<Duyetdt>(model);
            _context.Duyetdts!.Add(newDuyetdt);
            await _context.SaveChangesAsync();
            string returnString = newDuyetdt.MaGv + newDuyetdt.MaDt + newDuyetdt.LanDuyet;
            return returnString;
        }

        public async Task<int> maxLanDuyetdtAsync(string maGv, string maDt)
        {
            return await _context.Duyetdts
                    .Where(d => d.MaGv == maGv && d.MaDt == maDt)
                     .MaxAsync(d => (int?)d.LanDuyet) ?? 0;
        }

        public async Task DeleteDuyetdtsAsync(DuyetdtModel Duyetdt)
        {
            var deleteDuyetdt = await _context.Duyetdts!.SingleOrDefaultAsync(
                duyetDT => duyetDT.MaDt == Duyetdt.MaDt && duyetDT.MaGv == Duyetdt.MaGv
                && duyetDT.LanDuyet == Duyetdt.LanDuyet);
            if (deleteDuyetdt != null)
            {
                _context.Duyetdts!.Remove(deleteDuyetdt);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DuyetdtModel>> GetAllDuyetdtsAsync()
        {
            var Duyetdts = await _context.Duyetdts.ToListAsync();
            return _mapper.Map<List<DuyetdtModel>>(Duyetdts);
        }

        public async Task<DuyetdtModel> GetDuyetdtByIDAsync(DuyetdtModel Duyetdt)
        {
            var duyetDT = await _context.Duyetdts.FindAsync(Duyetdt.MaGv, Duyetdt.MaDt, Duyetdt.LanDuyet);
            return _mapper.Map<DuyetdtModel>(duyetDT);
        }

        public async Task UpdateDuyetdtsAsync(DuyetdtModel Duyetdt, DuyetdtModel model)
        {
            if (Duyetdt.MaDt == model.MaDt && Duyetdt.MaGv == model.MaGv && Duyetdt.LanDuyet == model.LanDuyet)
            {
                var updateDuyetdt = _mapper.Map<Duyetdt>(model);
                _context.Duyetdts.Update(updateDuyetdt);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DuyetdtModel>> GetDuyetdtByMaDT(string maDt)
        {
            var duyetDts = await _context.Duyetdts
                            .Where(d => d.MaDt == maDt)
                            .OrderByDescending(d => d.NgayDuyet)
                            .ToListAsync();
            return _mapper.Map<List<DuyetdtModel>>(duyetDts);
        }

        public async Task UpdateTrangthaiDetaiAsync(string maDT, string maGV, bool trangThai)
        {
            var deTai = await _context.Detais.FindAsync(maDT);
            deTai.TrangThai = trangThai;
            _context.Detais.Update(deTai);

            var huongDan = await _context.Huongdans.FindAsync(maGV, maDT);

            // Nếu duyệt đề tài thì mặc định thêm giảng viên ra đề vào hướng dẫn
            if (trangThai && huongDan == null)
            {
                HuongdanModel huongDanModel = new HuongdanModel()
                {
                    MaGv = maGV,
                    MaDt = maDT,
                    DuaRaHd = false
                };
                var huongDanMap = _mapper.Map<Huongdan>(huongDanModel);
                _context.Huongdans!.Add(huongDanMap);
            }
            // Nếu yêu cầu chỉnh sửa lại thì xóa giảng viên hướng dẫn nếu có
            else if (!trangThai && huongDan != null)
            {
                _context.Huongdans!.Remove(huongDan);
            }
            await _context.SaveChangesAsync();


        }
    }
}
