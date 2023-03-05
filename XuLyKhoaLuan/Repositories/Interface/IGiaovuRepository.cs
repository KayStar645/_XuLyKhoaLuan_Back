﻿using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IGiaovuRepository
    {
        public Task<List<GiaovuModel>> GetAllGiaovusAsync();
        public Task<GiaovuModel> GetGiaovuByIDAsync(string ma);
        public Task<string> AddGiaovusAsync(GiaovuModel model);
        public Task UpdateGiaovusAsync(string ma, GiaovuModel model);
        public Task DeleteGiaovusAsync(string ma);
    }
}