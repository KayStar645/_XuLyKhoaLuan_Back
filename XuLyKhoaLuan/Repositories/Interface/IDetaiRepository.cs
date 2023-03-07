﻿using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
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
    }
}
