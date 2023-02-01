﻿using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IThamgiaRepository
    {
        public Task<List<ThamgiaModel>> GetAllThamgiasAsync();
        public Task<ThamgiaModel> GetThamgiaByIDAsync(ThamgiaModel thamGia);
        public Task<string> AddThamgiasAsync(ThamgiaModel model);
        public Task UpdateThamgiasAsync(ThamgiaModel thamGia, ThamgiaModel model);
        public Task DeleteThamgiasAsync(ThamgiaModel thamGia);
    }
}
