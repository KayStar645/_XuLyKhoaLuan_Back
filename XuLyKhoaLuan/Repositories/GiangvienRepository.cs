using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class GiangvienRepository : IGiangvienRepository
    {

        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public GiangvienRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddGiangviensAsync(GiangvienModel model)
        {
            var newGiangvien = _mapper.Map<Giangvien>(model);
            _context.Giangviens!.Add(newGiangvien);
            await _context.SaveChangesAsync();
            return newGiangvien.MaGv;
        }

        public async Task DeleteGiangviensAsync(string maGV)
        {
            var deleteGiangvien = _context.Giangviens!.SingleOrDefault(dt => dt.MaGv.Equals(maGV));
            if (deleteGiangvien != null)
            {
                _context.Giangviens!.Remove(deleteGiangvien);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<GiangvienModel>> GetAllGiangviensAsync()
        {
            var Giangviens = await _context.Giangviens.ToListAsync();
            return _mapper.Map<List<GiangvienModel>>(Giangviens);
        }

        public async Task<GiangvienModel> GetGiangvienByIDAsync(string maGV)
        {
            var Giangvien = await _context.Giangviens.FindAsync(maGV);
            return _mapper.Map<GiangvienModel>(Giangvien);
        }

        public async Task<List<GiangvienModel>> GetGiangvienByBoMonAsync(string maBM)
        {
            var Giangviens = await _context.Giangviens.Where(c => c.MaBm.Equals(maBM)).ToListAsync();
            return _mapper.Map<List<GiangvienModel>>(Giangviens);
        }

        public async Task<List<GiangvienModel>> GetGiangvienByKhoaAsync(string maKhoa)
        {
            var giangviens = await _context.Giangviens
                                    .Join(_context.Bomons, g => g.MaBm, b => b.MaBm, (g, b) => new { g = g, b = b })
                                    .Join(_context.Khoas, gb => gb.b.MaKhoa, k => k.MaKhoa, (gb, k) => new { gv = gb.g, k = k })
                                    .Where(sk => sk.k.MaKhoa == maKhoa)
                                    .Select(sk => sk.gv).ToListAsync();
            return _mapper.Map<List<GiangvienModel>>(giangviens);
        }

        public async Task<List<GiangvienModel>> SearchGiangvienByNameAsync(string name, string maBm)
        {
            var Giangviens = await _context.Giangviens.Where(c => c.TenGv.Contains(name) && c.MaBm.Contains(maBm)).ToListAsync();
            return _mapper.Map<List<GiangvienModel>>(Giangviens);
        }

        public async Task UpdateGiangviensAsync(string maGV, GiangvienModel model)
        {
            if (maGV.Equals(model.MaGv))
            {
                var updateGiangvien = _mapper.Map<Giangvien>(model);
                _context.Giangviens.Update(updateGiangvien);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<GiangvienModel>> search(string? maBm, string? tenGv, string namHoc, int dot, bool flag = false)
        {
            var giangViens = await _context.Giangviens
                    .Where(gv => (string.IsNullOrEmpty(maBm) || gv.MaBm == maBm) &&
                                 (string.IsNullOrEmpty(tenGv) ||
                                    (gv.TenGv.Contains(tenGv) || gv.MaGv.Contains(tenGv) ||
                                    gv.Email.Contains(tenGv) || gv.Sdt.Contains(tenGv))
                                 ))
                    .ToListAsync();
            if (flag)
            {
                List<GiangvienModel> listGv = _mapper.Map<List<GiangvienModel>>(giangViens);
                foreach (GiangvienModel gv in listGv)
                {
                    gv.slnv = await this.GetSoLuongNhiemVuAsync(gv.MaGv, namHoc, dot);
                }
                return listGv;
            }  

            return _mapper.Map<List<GiangvienModel>>(giangViens);
        }

        public async Task<List<GiangvienModel>> GetGiangVienByNhiemVuAsync(string maBm, string maDt, int loaiNV)
        {
            if (loaiNV == 1) // Hướng dẫn
            {
                // Lấy danh sách giảng viên thuộc bộ môn này và chưa phản biện đề tài này
                var giangViens = await _context.Giangviens
                    .Where(gv => gv.MaBm == maBm &&
                           !_context.Phanbiens.Any(pb => pb.MaGv == gv.MaGv && pb.MaDt == maDt))
                    .ToListAsync();
                return _mapper.Map<List<GiangvienModel>>(giangViens);
            }
            else // Phản biện
            {
                var giangViens = await _context.Giangviens
                    .Where(gv => gv.MaBm == maBm &&
                           !_context.Huongdans.Any(pb => pb.MaGv == gv.MaGv && pb.MaDt == maDt))
                    .ToListAsync();
                return _mapper.Map<List<GiangvienModel>>(giangViens);
            }
        }

        public async Task<List<int>> GetSoLuongNhiemVuAsync(string maGv, string namHoc, int dot)
        {
            List<int> list = new List<int>();
            var dotDk = await _context.Dotdks.FindAsync(namHoc, dot);
            if (dotDk == null)
            {
                for(int i = 0; i < 5; i++)
                {
                    list.Add(0);
                }
                return list;
            }
            // 0. Số lượng đề tài được giao - Nhiệm vụ
            var cDTgiao = await _context.Nhiemvus
                        .Where(n => dotDk.NgayBd <= n.ThoiGianBd && n.ThoiGianBd <= dotDk.NgayKt && n.MaGv == maGv)
                        .SumAsync(n => n.SoLuongDt);
            list.Add(cDTgiao);

            // 1. Số lượng đề tài đạt - Ra đề đạt
            var cDTDat = await _context.Rades
                    .Join(_context.Detais, rd => rd.MaDt, dt => dt.MaDt, (rd, dt) => new { rd = rd, dt = dt })
                    .Where(re => re.dt.NamHoc == dotDk.NamHoc && re.dt.Dot == dotDk.Dot &&
                    re.dt.TrangThai == true && re.rd.MaGv == maGv)
                    .CountAsync();
            list.Add(cDTDat);

            // 2. Số lượng đề tài ra - Ra đề
            var cDTRa = await _context.Rades
                    .Join(_context.Detais, rd => rd.MaDt, dt => dt.MaDt, (rd, dt) => new { rd = rd, dt = dt })
                    .Where(re => re.dt.NamHoc == dotDk.NamHoc && re.dt.Dot == dotDk.Dot && re.rd.MaGv == maGv)
                    .CountAsync();
            list.Add(cDTRa);

            // Hướng dẫn hoặc phản biện đề tài của đợt hiện tại

            // 3. Số lượng đề tài hướng dẫn - Hướng dẫn
            var cDTHD = await _context.Huongdans
                    .Join(_context.Detais, hd => hd.MaDt, dt => dt.MaDt, (hd, dt) => new { hd = hd, dt = dt })
                    .Where(re => re.dt.NamHoc == namHoc && re.dt.Dot == dot && re.hd.MaGv == maGv )
                    .CountAsync();
            list.Add(cDTHD);

            // 4. Số lượng đề tài phản biện - Phản biện
            var cDTPB = await _context.Phanbiens
                    .Join(_context.Detais, pb => pb.MaDt, dt => dt.MaDt, (pb, dt) => new { pb = pb, dt = dt })
                    .Where(re => re.dt.NamHoc == namHoc && re.dt.Dot == dot && re.pb.MaGv == maGv )
                    .CountAsync();
            list.Add(cDTPB);

            return list;
        }
    }
}
