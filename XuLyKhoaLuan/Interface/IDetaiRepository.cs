using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Interface
{
    public interface IDetaiRepository
    {
        public Task<List<DetaiModel>> GetAllDeTaisAsync();
        public Task<DetaiModel> GetDeTaiByIDAsync(string maDT);
        public Task<List<DetaiModel>> GetDetaiByChuyenNganhAsync(string maCN);
        public Task<List<ChuyennganhModel>> GetChuyennganhOfDetaiAsync(string maDT);
        public Task<List<DetaiModel>> SearchDetaiByNameAsync(string name);
        public Task<string> AddDeTaisAsync(DetaiModel model);
        public Task UpdateDeTaisAsync(string maDT, DetaiModel model);
        public Task DeleteDeTaisAsync(string maDT);
        public Task<List<DetaiModel>> GetAllDeTaisByMakhoaAsync(string maKhoa, int trangThaiDT);
        public Task<List<DetaiModel>> GetAllDeTaisByMaBomonAsync(string maBm, bool flag);
        public Task<List<DetaiModel>> GetAllDeTaisByGiangvienAsync(string maGv);
        public Task<bool> CheckisDetaiOfGiangvienAsync(string maDt, string maGv);
        public Task<List<DetaiModel>> GetDeTaisByChuyennganhGiangvienAsync(string maCn, string maGv);
        public Task<string> createMaDT(string maKhoa);
        public Task<DetaiModel> GetDetaiByTendt(string tenDT);
        public Task<List<DetaiModel>> GetDetaiByDotdk(string namHoc, int dot);
        public Task<List<DetaiModel>> GetDetaiByBomonDotdk(string maBM, string namHoc, int dot, bool flag);
        public Task<List<DetaiModel>> GetDetaiByHuongdanOfGiangvienDotdkAsync(string maGv, string namHoc, int dot);
        public Task<List<DetaiModel>> GetDetaiByPhanbienOfGiangvienDotdkAsync(string maGv, string namHoc, int dot);
        public Task<List<DetaiModel>> GetDetaiByChuyenNganhBomonAsync(string maCN, string maBM);
        public Task<List<DetaiVTModel>> GetDetaiByRequestAsync(string maDt, string tenDt, string maCn, string maBm,
            string gvrd, string gvhd, string gvpb, bool trangThai, string namHoc, int dot, string maNhom, bool isThamkhao);
        public Task<List<DetaiModel>> search(string? maCn, string? tenDt, string? namHoc, int? dot, string? key, string? maGv, int? chucVu = 0);
    }
}
