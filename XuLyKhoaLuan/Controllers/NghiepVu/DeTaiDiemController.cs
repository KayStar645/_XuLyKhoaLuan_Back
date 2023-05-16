using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface.NghiepVu;
using XuLyKhoaLuan.Interface.TraoDoi;
using XuLyKhoaLuan.Models.VirtualModel;
using XuLyKhoaLuan.Repositories.BinhLuan;

namespace XuLyKhoaLuan.Controllers.NghiepVu
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeTaiDiemController : ControllerBase
    {
        private readonly IDeTaiDiemRepo _DetaidiemRepo;

        public DeTaiDiemController(IDeTaiDiemRepo repo)
        {
            this._DetaidiemRepo = repo;
        }

        [HttpGet("maGv")]
        public async Task<IActionResult> GetLichPhanBienByGvAsync(string maGv)
        {
            try
            {
                return Ok(await _DetaidiemRepo.GetDanhSachDiemByGv(maGv));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("maGv,maDt,maSv,namHoc,dot,vaiTro,diem")]
        public async Task<IActionResult> ChamDiemSvAsync(string maGv, string maDt, string maSv, string namHoc, int dot, int vaiTro, double diem)
        {
            try
            {
                return Ok(await _DetaidiemRepo.ChamDiemSvAsync(maGv, maDt, maSv, namHoc, dot, vaiTro, diem));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("keyword,maCn,namHoc,dot")]
        public async Task<IActionResult> GetDanhSachDiem(string? keyword, string? maCn, string? namHoc, int? dot = 0)
        {
            try
            {
                return Ok(await _DetaidiemRepo.GetDanhSachDiem(keyword, maCn, namHoc, dot));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
