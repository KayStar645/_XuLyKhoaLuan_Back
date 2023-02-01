﻿using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IPbchamRepository
    {
        public Task<List<PbchamModel>> GetAllPbchamsAsync();
        public Task<PbchamModel> GetPbchamByIDAsync(PbchamModel pbCham);
        public Task<string> AddPbchamsAsync(PbchamModel model);
        public Task UpdatePbchamsAsync(PbchamModel pbCham, PbchamModel model);
        public Task DeletePbchamsAsync(PbchamModel pbCham);
    }
}
