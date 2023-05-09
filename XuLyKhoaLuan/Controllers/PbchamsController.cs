using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PbchamsController : ControllerBase
    {
        private readonly IPbchamRepository _PbchamRepo;

        public PbchamsController(IPbchamRepository repo)
        {
            _PbchamRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPbchams()
        {
            try
            {
                return Ok(await _PbchamRepo.GetAllPbchamsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaGV, MaDT")]
        public async Task<IActionResult> GetPbchamByMaCN(string MaGV, string MaDT)
        {
            PbchamModel pbCham = new()
            {
                MaGv = MaGV,
                MaDt = MaDT
            };
            var Pbcham = await _PbchamRepo.GetPbchamByIDAsync(pbCham);
            return Pbcham == null ? BadRequest() : Ok(Pbcham);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewPbcham(PbchamModel model)
        {
            try
            {
                var newPbcham = await _PbchamRepo.AddPbchamsAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaGV, MaDT")]
        public async Task<IActionResult> UpdatePbcham(string MaGV, string MaDT, PbchamModel model)
        {

            try
            {
                PbchamModel pbCham = new()
                {
                    MaGv = MaGV,
                    MaDt = MaDT
                };
                await _PbchamRepo.UpdatePbchamsAsync(pbCham, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaGV, MaDT, maSv, namHoc, dot")]
        public async Task<IActionResult> DeletePbcham(string MaGV, string MaDT, string maSv, string namHoc, int dot)
        {
            PbchamModel pbCham = new()
            {
                MaGv = MaGV,
                MaDt = MaDT,
                MaSv = maSv,
                NamHoc = namHoc,
                Dot = dot
            };
            await _PbchamRepo.DeletePbchamsAsync(pbCham);
            return Ok();
        }

        [HttpDelete("MaGV, MaDT, namHoc, dot")]
        public async Task<IActionResult> DeletePbchamsByGvDtAsync(string maGv, string maDt, string namHoc, int dot)
        {
            try
            {
                return Ok(await _PbchamRepo.DeletePbchamsByGvDtAsync(maGv, maDt, namHoc, dot));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
