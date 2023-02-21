using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;

        public AccountsController(IAccountRepository repo) 
        {
            accountRepo = repo;
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
    }
}
