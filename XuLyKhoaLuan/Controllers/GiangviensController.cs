using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangviensController : ControllerBase
    {
        private readonly IGiangvienRepository _GiangvienRepo;
        private readonly IAccountRepository accountRepo;

        public GiangviensController(IGiangvienRepository repo, IAccountRepository repoAccount)
        {
            _GiangvienRepo = repo;
            accountRepo = repoAccount;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGiangviens()
        {
            try
            {
                return Ok(await _GiangvienRepo.GetAllGiangviensAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaGV")]
        public async Task<IActionResult> GetGiangvienByID(string MaGV)
        {
            var Giangvien = await _GiangvienRepo.GetGiangvienByIDAsync(MaGV);
            return Giangvien == null ? BadRequest() : Ok(Giangvien);
        }

        [HttpGet("MaBM")]
        public async Task<IActionResult> GetGiangvienByBoMon(string MaBM)
        {
            var Giangvien = await _GiangvienRepo.GetGiangvienByBoMonAsync(MaBM);
            return Giangvien == null ? BadRequest() : Ok(Giangvien);
        }

        [HttpGet("MaKhoa")]
        public async Task<IActionResult> GetGiangvienByKhoa(string MaKhoa)
        {
            var Giangvien = await _GiangvienRepo.GetGiangvienByKhoaAsync(MaKhoa);
            return Giangvien == null ? BadRequest() : Ok(Giangvien);
        }

        [HttpGet("tenGV")]
        public async Task<IActionResult> SearchGiangvienByName(string tenGV)
        {
            var Giangvien = await _GiangvienRepo.SearchGiangvienByNameAsync(tenGV);
            return Giangvien == null ? BadRequest() : Ok(Giangvien);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewGiangvien(GiangvienModel model)
        {
            try
            {
                var newGiangvien = await _GiangvienRepo.AddGiangviensAsync(model);
                // Nếu thêm giảng viên thành công thì thêm tài khoản cho giảng viên
                var user = new SigUpModel
                {
                    Id = model.MaGv,
                    Password = model.MaGv

                };
                await accountRepo.SigUpAsync(user);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaGV")]
        public async Task<IActionResult> UpdateGiangvien(string MaGV, GiangvienModel model)
        {

            try
            {
                await _GiangvienRepo.UpdateGiangviensAsync(MaGV, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaGV")]
        public async Task<IActionResult> DeleteGiangvien(string MaGV)
        {
            await _GiangvienRepo.DeleteGiangviensAsync(MaGV);
            await accountRepo.DeleteAsync(MaGV);
            return Ok();
        }
    }
}
