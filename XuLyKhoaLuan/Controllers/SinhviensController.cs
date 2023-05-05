using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Helpers;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhviensController : ControllerBase
    {
        private readonly ISinhvienRepository _sinhvienRepo;
        private readonly IAccountRepository accountRepo;

        public SinhviensController(ISinhvienRepository repo, IAccountRepository repoAccount)
        {
            _sinhvienRepo = repo;
            accountRepo = repoAccount;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSinhviens()
        {
            try
            {
                return Ok(await _sinhvienRepo.GetAllSinhViensAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("namHoc, dot")]
        public async Task<IActionResult> GetAllClassAsync(string? namHoc, int? dot)
        {
            try
            {
                return Ok(await _sinhvienRepo.GetAllClassAsync(namHoc, dot));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maSV")]
        public async Task<IActionResult> GetSinhvienByMaSV(string maSV)
        {
            var SinhVien = await _sinhvienRepo.GetSinhVienByIDAsync(maSV);
            return SinhVien == null ? BadRequest() : Ok(SinhVien);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewSinhvien(SinhvienModel model)
        {
            try
            {
                var newSinhvien = await _sinhvienRepo.AddSinhViensAsync(model);
                var user = new SigUpModel
                {
                    Id = model.MaSv,
                    Password = model.MaSv

                };
                await accountRepo.SigUpAsync(user);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("maSV")]
        public async Task<IActionResult> UpdateSinhvien(string maSV, SinhvienModel model)
        {

            try
            {
                await _sinhvienRepo.UpdateSinhViensAsync(maSV, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("maSV")]
        public async Task<IActionResult> DeleteSinhvien(string maSV)
        {
            await _sinhvienRepo.DeleteSinhViensAsync(maSV);
            await accountRepo.DeleteAsync(maSV);
            return Ok();
        }

        [HttpGet("maCN")]
        public async Task<IActionResult> GetSinhByChuyenNganh(string maCN)
        {
            var sinhVien = await _sinhvienRepo.GetSinhvienByChuyenNganhAsync(maCN);
            return sinhVien == null ? BadRequest() : Ok(sinhVien);
        }

        [HttpGet("maKhoa")]
        public async Task<IActionResult> GetSinhByKhoa(string maKhoa)
        {
            var sinhVien = await _sinhvienRepo.GetSinhvienByKhoaAsync(maKhoa);
            return sinhVien == null ? BadRequest() : Ok(sinhVien);
        }

        [HttpGet("namHoc, dot, flag")]
        public async Task<IActionResult> GetSinhByDotdk(string namHoc, int dot, bool flag)
        {
            var sinhVien = await _sinhvienRepo.GetSinhvienByDotDkAsync(namHoc, dot, flag);
            return sinhVien == null ? BadRequest() : Ok(sinhVien);
        }

        [HttpGet("tenSV")]
        public async Task<IActionResult> SearchSinhvienByName(string tenSV)
        {
            var sinhVien = await _sinhvienRepo.SearchSinhvienByNameAsync(tenSV);
            return sinhVien == null ? BadRequest() : Ok(sinhVien);
        }

        [HttpGet("maDT")]
        public async Task<IActionResult> GetSinhvienByDetaiAsync(string maDT)
        {
            try
            {
                return Ok(await _sinhvienRepo.GetSinhvienByDetaiAsync(maDT));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maCn, lop, tenSv")]
        public async Task<IActionResult> Search(string? maCn, string? lop, string? tenSv)
        {
            try
            {
                return Ok(await _sinhvienRepo.Search(maCn, lop, tenSv));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
