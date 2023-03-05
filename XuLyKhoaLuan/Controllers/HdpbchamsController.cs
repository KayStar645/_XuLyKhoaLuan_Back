using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HdpbchamsController : ControllerBase
    {
        private readonly IHdpbchamRepository _HdpbchamRepo;

        public HdpbchamsController(IHdpbchamRepository repo)
        {
            _HdpbchamRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHdpbchams()
        {
            try
            {
                return Ok(await _HdpbchamRepo.GetAllHdpbchamsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaGV, MaHD, MaDT, MaSV, NamHoc, Dot")]
        public async Task<IActionResult> GetHdpbchamByMaCN(string MaGV, string MaHD, string MaDT, string MaSV, string NamHoc, int Dot)
        {
            HdpbchamModel hdpbCham = new()
            {
                MaGv = MaGV,
                MaHd = MaHD,
                MaDt = MaDT,
                MaSv = MaSV,
                NamHoc = NamHoc,
                Dot = Dot
            };
            var Hdpbcham = await _HdpbchamRepo.GetHdpbchamByIDAsync(hdpbCham);
            return Hdpbcham == null ? BadRequest() : Ok(Hdpbcham);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewHdpbcham(HdpbchamModel model)
        {
            try
            {
                var newHdpbcham = await _HdpbchamRepo.AddHdpbchamsAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaGV, MaHD, MaDT, MaSV, NamHoc, Dot")]
        public async Task<IActionResult> UpdateHdpbcham(string MaGV, string MaHD, string MaDT, string MaSV, string NamHoc, int Dot, HdpbchamModel model)
        {

            try
            {
                HdpbchamModel hdpbCham = new()
                {
                    MaGv = MaGV,
                    MaHd = MaHD,
                    MaDt = MaDT,
                    MaSv = MaSV,
                    NamHoc = NamHoc,
                    Dot = Dot
                };
                await _HdpbchamRepo.UpdateHdpbchamsAsync(hdpbCham, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaGV, MaHD, MaDT, MaSV, NamHoc, Dot")]
        public async Task<IActionResult> DeleteHdpbcham(string MaGV, string MaHD, string MaDT, string MaSV, string NamHoc, int Dot)
        {
            HdpbchamModel hdpbCham = new()
            {
                MaGv = MaGV,
                MaHd = MaHD,
                MaDt = MaDT,
                MaSv = MaSV,
                NamHoc = NamHoc,
                Dot = Dot
            };
            await _HdpbchamRepo.DeleteHdpbchamsAsync(hdpbCham);
            return Ok();
        }
    }
}
