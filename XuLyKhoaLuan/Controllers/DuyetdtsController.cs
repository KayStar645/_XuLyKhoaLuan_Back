using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuyetdtsController : ControllerBase
    {
        private readonly IDuyetdtRepository _DuyetdtRepo;
        // GET: api/<DuyetdtsController>
        public DuyetdtsController(IDuyetdtRepository repo)
        {
            _DuyetdtRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDuyetdts()
        {
            try
            {
                return Ok(await _DuyetdtRepo.GetAllDuyetdtsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<DuyetdtsController>/5
        [HttpGet("MaGV, MaDT, LanDuyet")]
        public async Task<IActionResult> GetDuyetdtById(string MaGV, string MaDT, int LanDuyet)
        {
            try
            {
                DuyetdtModel model = new()
                {
                    MaGv = MaGV,
                    MaDt = MaDT,
                    LanDuyet = LanDuyet
                };
                var Duyetdt = await _DuyetdtRepo.GetDuyetdtByIDAsync(model);
                return Duyetdt == null ? NotFound() : Ok(Duyetdt);
            }
            catch
            {

                return BadRequest();
            }
        }

        // POST api/<DuyetdtsController>
        [HttpPost]
        public async Task<IActionResult> AddNewDuyetdt(DuyetdtModel model)
        {
            try
            {
                var newDuyetdt = await _DuyetdtRepo.AddDuyetdtsAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<DuyetdtsController>/5
        [HttpPut("MaGV, MaDT, LanDuyet")]
        public async Task<IActionResult> UpdateDuyetdt(string MaGV, string MaDT, int LanDuyet, DuyetdtModel model)
        {
            try
            {
                DuyetdtModel Duyetdt = new()
                {
                    MaGv = MaGV,
                    MaDt = MaDT,
                    LanDuyet = LanDuyet
                };
                await _DuyetdtRepo.UpdateDuyetdtsAsync(Duyetdt, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<DuyetdtsController>/5
        [HttpDelete("MaGV, MaDT, LanDuyet")]
        public async Task<IActionResult> Delete(string MaGV, string MaDT, int LanDuyet)
        {
            DuyetdtModel model = new()
            {
                MaGv = MaGV,
                MaDt = MaDT,
                LanDuyet = LanDuyet
            };
            await _DuyetdtRepo.DeleteDuyetdtsAsync(model);
            return Ok();
        }
    }
}
