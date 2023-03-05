using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XacnhansController : ControllerBase
    {
        private readonly IXacnhanRepository _XacnhanRepo;

        public XacnhansController(IXacnhanRepository repo)
        {
            _XacnhanRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllXacnhans()
        {
            try
            {
                return Ok(await _XacnhanRepo.GetAllXacnhansAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaGV, MaDT")]
        public async Task<IActionResult> GetXacnhanByMaCN(string MaGV, string MaDT)
        {
            XacnhanModel xacNhan = new()
            {
                MaGv = MaGV,
                MaDt = MaDT
            };
            var Xacnhan = await _XacnhanRepo.GetXacnhanByIDAsync(xacNhan);
            return Xacnhan == null ? BadRequest() : Ok(Xacnhan);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewXacnhan(XacnhanModel model)
        {
            try
            {
                var newXacnhan = await _XacnhanRepo.AddXacnhansAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaGV, MaDT")]
        public async Task<IActionResult> UpdateXacnhan(string MaGV, string MaDT, XacnhanModel model)
        {

            try
            {
                XacnhanModel xacNhan = new()
                {
                    MaGv = MaGV,
                    MaDt = MaDT
                };
                await _XacnhanRepo.UpdateXacnhansAsync(xacNhan, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaGV, MaDT")]
        public async Task<IActionResult> DeleteXacnhan(string MaGV, string MaDT)
        {
            XacnhanModel xacNhan = new()
            {
                MaGv = MaGV,
                MaDt = MaDT
            };
            await _XacnhanRepo.DeleteXacnhansAsync(xacNhan);
            return Ok();
        }
    }
}
