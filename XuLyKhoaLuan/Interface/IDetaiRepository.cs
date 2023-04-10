using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;

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
        public Task<List<DetaiModel>> GetAllDeTaisByMakhoaAsync(string maKhoa);
        public Task<List<DetaiModel>> GetAllDeTaisByMaBomonAsync(string maBm);
        public Task<List<DetaiModel>> GetAllDeTaisByGiangvienAsync(string maGv);
        public Task<bool> CheckisDetaiOfGiangvienAsync(string maDt, string maGv);
        public Task<List<DetaiModel>> GetDeTaisByChuyennganhGiangvienAsync(string maCn, string maGv);
        public Task<string> createMaDT(string maKhoa);
        public Task<DetaiModel> GetDetaiByTendt(string tenDT);
        public Task<List<DetaiModel>> GetDetaiByDotdk(string namHoc, int dot);
    }
}
