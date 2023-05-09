using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HdchamsController : ControllerBase
    {
        private readonly IHdchamRepository _HdchamRepo;
        // GET: api/<HdchamsController>
        public HdchamsController(IHdchamRepository repo)
        {
            _HdchamRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHdchams()
        {
            try
            {
                return Ok(await _HdchamRepo.GetAllHdchamsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<HdchamsController>/5
        [HttpGet("MaGV, MaDT")]
        public async Task<IActionResult> GetHdchamById(string MaGV, string MaDT)
        {
            try
            {
                HdchamModel model = new()
                {
                    MaGv = MaGV,
                    MaDt = MaDT
                };
                var dotDK = await _HdchamRepo.GetHdchamByIDAsync(model);
                return dotDK == null ? NotFound() : Ok(dotDK);
            }
            catch
            {

                return BadRequest();
            }
        }

        // POST api/<HdchamsController>
        [HttpPost]
        public async Task<IActionResult> AddNewHdcham(HdchamModel model)
        {
            try
            {
                var newHdcham = await _HdchamRepo.AddHdchamsAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<HdchamsController>/5
        [HttpPut("MaGV, MaDT")]
        public async Task<IActionResult> UpdateHdcham(string MaGV, string MaDT, HdchamModel model)
        {
            try
            {
                HdchamModel Hdcham = new()
                {
                    MaGv = MaGV,
                    MaDt = MaDT
                };
                await _HdchamRepo.UpdateHdchamsAsync(Hdcham, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<HdchamsController>/5
        [HttpDelete("MaGV, MaDT, maSv, namHoc, dot")]
        public async Task<IActionResult> Delete(string MaGV, string MaDT, string maSv, string namHoc, int dot)
        {
            HdchamModel model = new()
            {
                MaGv = MaGV,
                MaDt = MaDT,
                MaSv = maSv,
                NamHoc = namHoc,
                Dot = dot
            };
            await _HdchamRepo.DeleteHdchamsAsync(model);
            return Ok();
        }

        [HttpDelete("MaGV, MaDT, namHoc, dot")]
        public async Task<IActionResult> DeleteHdchamsByGvDtAsync(string maGv, string maDt, string namHoc, int dot)
        {
            try
            {
                return Ok(await _HdchamRepo.DeleteHdchamsByGvDtAsync(maGv, maDt, namHoc, dot));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
