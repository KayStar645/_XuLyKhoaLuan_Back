﻿using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IGiangvienRepository
    {
        public Task<List<GiangvienModel>> GetAllGiangviensAsync();
        public Task<GiangvienModel> GetGiangvienByIDAsync(string ma);

        public Task<List<GiangvienModel>> GetGiangvienByBoMonAsync(string maBM);
        public Task<List<GiangvienModel>> SearchGiangvienByNameAsync(string name);
        public Task<string> AddGiangviensAsync(GiangvienModel model);
        public Task UpdateGiangviensAsync(string ma, GiangvienModel model);
        public Task DeleteGiangviensAsync(string ma);
    }
}
