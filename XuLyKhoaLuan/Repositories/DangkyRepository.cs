using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class DangkyRepository : IDangkyRepository
    {
        private readonly XuLyKhoaLuanContext _context;
        private readonly IMapper _mapper;

        public DangkyRepository(XuLyKhoaLuanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddDangkiesAsync(DangkyModel model)
        {
            var newDangky = _mapper.Map<Dangky>(model);
            _context.Dangkies!.Add(newDangky);
            await _context.SaveChangesAsync();
            string returnString = newDangky.MaNhom + newDangky.MaDt;
            return returnString;
        }

        public async Task DeleteDangkiesAsync(DangkyModel Dangky)
        {
            var deleteDangky = _context.Dangkies!.SingleOrDefault(
                dk => dk.MaDt == Dangky.MaDt && dk.MaNhom == Dangky.MaNhom);
            if (deleteDangky != null)
            {
                _context.Dangkies!.Remove(deleteDangky);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DangkyModel>> GetAllDangkiesAsync()
        {
            var Dangkies = await _context.Dangkies.ToListAsync();
            return _mapper.Map<List<DangkyModel>>(Dangkies);
        }

        public async Task<DangkyModel> GetDangkyByIDAsync(DangkyModel dk)
        {
            var Dangky = await _context.Dangkies.FindAsync(dk.MaNhom, dk.MaDt);
            return _mapper.Map<DangkyModel>(Dangky);

        }

        public async Task UpdateDangkiesAsync(DangkyModel dk, DangkyModel model)
        {
            if (dk.MaDt == model.MaDt && dk.MaNhom == model.MaNhom)
            {
                var updateDangky = _mapper.Map<Dangky>(model);
                _context.Dangkies.Update(updateDangky);
                await _context.SaveChangesAsync();
            }
        }

        // Chỉ lấy những đề tài đã được duyệt, chưa đăng ký, chuyên ngành phù hợp và đã có giảng viên hướng dẫn
        // Nếu true thì lấy đúng đợt đăng ký, ngược lại lấy sớm hơn 2 ngày
        // Dữ liệu đề tài sẽ được lấy ra mà không quan tâm tới ngày, client sẽ xử lý vấn đề đó
        // Tất cả sinh viên trong nhóm phải thuộc chuyên ngành phù hợp
        //public async Task<List<DetaiModel>> GetAllDetaiDangkyAsync(bool flag, string namHoc, int dot, string maNhom)
        //{
        //    // Lấy danh sách Thamgia
        //    var thamGias = await _context.Thamgia.Where(t => t.MaNhom == maNhom).ToListAsync();

        //    // Lấy danh sách Detai: Dotdk, trangThai, GVHD
        //    var deTais = await _context.Detais
        //            .Join(_context.Huongdans, dt => dt.MaDt, hd => hd.MaDt, (dt, hd) => new { dt = dt, hd = hd })
        //            .Where(re => re.dt.NamHoc == namHoc && re.dt.Dot == dot && re.dt.TrangThai == true)
        //            .ToListAsync();



        //    // Đề tài phải phù hợp với tất cả các thành viên trong nhóm



        //    var deTais = await _context.Detais
        //            .Join(_context.Huongdans, dt => dt.MaDt, hd => hd.MaDt, (dt, hd) => new { dt = dt, hd = hd })
        //            .Join(_context.Dotdks)
        //}

        // Thiếu ngày đăng ký
        public async Task<List<DetaiModel>> GetAllDetaiDangkyAsync(string namHoc, int dot, string maNhom)
        {
            // Đề tài đã được duyệt => trạng thái = true (Trong đợt đăng ký)
            var deTaisDuyet = await _context.Detais
                    .Where(dt => dt.NamHoc == namHoc && dt.Dot == dot && dt.TrangThai == true)
                    .ToListAsync();
            List<DetaiModel> deTaisModel = _mapper.Map<List<DetaiModel>>(deTaisDuyet);

            for(int i = 0; i < deTaisModel.Count; i++)
            {
                // Nếu là thời gian đăng ký học phần
                var isDotdk = await _context.Dotdks
                    .AnyAsync(d => d.NamHoc == namHoc && d.Dot == dot && d.NgayBd <= DateTime.Now && DateTime.Now <= d.NgayKt);
                if (isDotdk)
                {
                    // Chưa có bảng đăng ký
                    var isDangky = await _context.Dangkies.AnyAsync(d => d.MaDt == deTaisModel[i].MaDT);

                    if (!isDangky)
                    {
                        // Đã có giảng viên hướng dẫn
                        var isHuongdan = await _context.Huongdans.AnyAsync(d => d.MaDt == deTaisModel[i].MaDT);

                        if (isHuongdan)
                        {
                            // Lấy danh sách chuyên ngành phù hợp
                            var deTai_Chuyennganhs = await _context.DetaiChuyennganhs
                                    .Where(dc => dc.MaDt == deTaisModel[i].MaDT)
                                    .ToListAsync();
                            List<DetaiChuyennganhModel> deTai_ChuyennsModel = _mapper.Map<List<DetaiChuyennganhModel>>(deTai_Chuyennganhs);

                            // Phù hợp chuyên ngành với sinh viên => maNhom => Lấy thành viên nhóm
                            var thanhViens = await _context.Thamgia
                                    .Join(_context.Sinhviens, tg => tg.MaSv, sv => sv.MaSv, (tg, sv) => new { tg = tg, sv = sv })
                                    .Where(re => re.tg.MaNhom == maNhom)
                                    .Select(re => re.sv)
                                    .ToListAsync();
                            List<SinhvienModel> thamGiasModel = _mapper.Map<List<SinhvienModel>>(thanhViens);

                            // Kiểm tra từng sinh viên trong nhóm có phù hợp hay không
                            bool flag = true;
                            foreach (SinhvienModel sv in thamGiasModel)
                            {
                                bool _flag = false;
                                foreach (DetaiChuyennganhModel dc in deTai_ChuyennsModel)
                                {
                                    if (sv.MaCn == dc.MaCn)
                                    {
                                        _flag = true;
                                        break;
                                    }
                                }
                                if (!_flag)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (!flag)
                            {
                                deTaisModel.Remove(deTaisModel[i]);
                                i--;
                            }
                        }
                        else
                        {
                            deTaisModel.Remove(deTaisModel[i]);
                            i--;
                        }
                    }
                    else
                    {
                        deTaisModel.Remove(deTaisModel[i]);
                        i--;
                    }
                }
                else
                {
                    deTaisModel.Remove(deTaisModel[i]);
                    i--;
                }
            }
            return deTaisModel;
        }
    }
}
