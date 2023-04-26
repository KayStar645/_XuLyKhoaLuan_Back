using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface.TraoDoi;
using XuLyKhoaLuan.Models.VirtualModel;

namespace XuLyKhoaLuan.Controllers.TraoDoi
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraodoiController : ControllerBase
    {
        private readonly ITraodoiRepo _TraodoiRepo;

        public TraodoiController(ITraodoiRepo repo)
        {
            this._TraodoiRepo = repo;
        }


        [HttpGet("maCv")]
        public async Task<IActionResult> GetAllTraoDoiMotCongViec(string maCv)
        {
            try
            {
                return Ok(await _TraodoiRepo.GetAllTraoDoiMotCongViec(maCv));
            }
            catch
            {
                return BadRequest();            
            }
        }

    }
}
