using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;
        private readonly ISinhvienRepository sinhVienRepo;
        private readonly IGiangvienRepository giangVienRepo;
        private readonly IGiaovuRepository giaoVuRepo;

        public AccountsController(IAccountRepository repo, ISinhvienRepository svRepo
            , IGiangvienRepository gvRepo, IGiaovuRepository gvuRepo)
        {
            accountRepo = repo;
            sinhVienRepo = svRepo;
            giangVienRepo = gvRepo;
            giaoVuRepo = gvuRepo;
        }

        [HttpPost("SigUp")]
        public async Task<IActionResult> SigUp(SigUpModel sigUpModel)
        {
            var result = await accountRepo.SigUpAsync(sigUpModel);
            if(result.Succeeded)
            {
                return Ok(result);
            }
            return Unauthorized();
        }

        [HttpPost("SigIn")]
        public async Task<IActionResult> SigIn(SigInModel sigInModel)
        {
            var result = await accountRepo.SigInAsync(sigInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        // Ministry
        [HttpPost("SigUpMinistry")]
        public async Task<IActionResult> SigUpMinistry(SigUpModel sigUpModel)
        {
            if (await giaoVuRepo.GetGiaovuByIDAsync(sigUpModel.Id) != null)
            {
                var result = await accountRepo.SigUpAsync(sigUpModel);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
            }
            return Unauthorized();
        }

        [HttpPost("SigInMinistry")]
        public async Task<IActionResult> SigInMinistry(SigInModel sigInModel)
        {
            if (await giaoVuRepo.GetGiaovuByIDAsync(sigInModel.Id) != null)
            {
                var result = await accountRepo.SigInAsync(sigInModel);
                if (!string.IsNullOrEmpty(result))
                {
                    return Ok(result);
                }
            }
            return Unauthorized();
        }

        // Teacher
        [HttpPost("SigUpTeacher")]
        public async Task<IActionResult> SigUpTeacher(SigUpModel sigUpModel)
        {
            if (await giangVienRepo.GetGiangvienByIDAsync(sigUpModel.Id) != null)
            {
                var result = await accountRepo.SigUpAsync(sigUpModel);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
            }
            return Unauthorized();
        }

        [HttpPost("SigInTeacher")]
        public async Task<IActionResult> SigInTeacher(SigInModel sigInModel)
        {
            if (await giangVienRepo.GetGiangvienByIDAsync(sigInModel.Id) != null)
            {
                var result = await accountRepo.SigInAsync(sigInModel);
                if (!string.IsNullOrEmpty(result))
                {
                    return Ok(result);
                }
            }
            return Unauthorized();
        }

        //Student
        [HttpPost("SigUpStudent")]
        public async Task<IActionResult> SigUpStudent(SigUpModel sigUpModel)
        {
            if (await sinhVienRepo.GetSinhVienByIDAsync(sigUpModel.Id) != null)
            {
                var result = await accountRepo.SigUpAsync(sigUpModel);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
            }
            return Unauthorized();
        }

        [HttpPost("SigInStudent")]
        public async Task<IActionResult> SigInStudent(SigInModel sigInModel)
        {
            if (await sinhVienRepo.GetSinhVienByIDAsync(sigInModel.Id) != null)
            {
                var result = await accountRepo.SigInAsync(sigInModel);
                if (!string.IsNullOrEmpty(result))
                {
                    return Ok(result);
                }
            }
            return Unauthorized();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            // xóa tài khoản với ID tương ứng
            var account = await accountRepo.DeleteAsync(id);

            // kiểm tra nếu tài khoản không tồn tại
            if (account == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
