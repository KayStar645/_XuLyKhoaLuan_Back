﻿using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories.Interface
{
    public interface IDetaichuyennganhRepository
    {
        public Task<List<DetaiChuyennganhModel>> GetAllDetaiChuyennganhsAsync();
        public Task<List<DetaiChuyennganhModel>> GetDetaiChuyennganhByMaDTMaCNAsync(string? maDT, string? maCN);
        public Task<string> AddDetaiChuyennganhsAsync(DetaiChuyennganhModel model);
        public Task DeleteDetaiChuyennganhsAsync(DetaiChuyennganhModel model);
    }
}