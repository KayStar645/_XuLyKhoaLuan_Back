﻿using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Interface.NghiepVu
{
    public interface IDeTaiDiemRepo
    {
        public Task<List<DeTaiDiemVTModel>> GetDanhSachDiemByGv(string maGv);
        public Task<bool> ChamDiemSvAsync(string maGv, string maDt, string maSv, string namHoc, int dot, int vaiTro, double diem);
    }
}
