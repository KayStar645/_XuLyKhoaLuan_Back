using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XuLyKhoaLuan.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BaocaosController : ControllerBase
    {
        private readonly IBaocaoRepository _BaocaoRepo;
        // GET: api/<BaocaosController>
        public BaocaosController(IBaocaoRepository repo)
        {
            _BaocaoRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBaocaos()
        {
            try
            {
                return Ok(await _BaocaoRepo.GetAllBaoCaosAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<BaocaosController>/5
        [HttpGet("MaCv, MaSv, NamHoc, Dot, LanNop")]
        public async Task<IActionResult> GetBaocaoById(string MaCv, string MaSv, string NamHoc, int Dot, int LanNop)
        {
            try
            {
                BaocaoModel model = new()
                {
                    MaCv = MaCv,
                    MaSv = MaSv,
                    NamHoc = NamHoc,
                    Dot = Dot,
                    LanNop = LanNop
                };
                var baoCao = await _BaocaoRepo.GetBaoCaoByIDAsync(model);
                return baoCao == null ? NotFound() : Ok(baoCao);
            }
            catch
            {

                return BadRequest();
            }
        }

        // POST api/<BaocaosController>
        [HttpPost]
        public async Task<IActionResult> AddNewBaocao(BaocaoModel model)
        {
            try
            {
                model.LanNop = await _BaocaoRepo.createLanNop(model.MaCv, model.MaSv, model.NamHoc, model.Dot);
                var newBaocao = await _BaocaoRepo.AddBaoCaosAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<BaocaosController>/5
        [HttpPut("MaCv, MaSv, NamHoc, Dot, LanNop")]
        public async Task<IActionResult> UpdateBaocao(string MaCv, string MaSv, string NamHoc, int Dot, int LanNop, BaocaoModel model)
        {
            try
            {
                BaocaoModel baocao = new()
                {
                    MaCv = MaCv,
                    MaSv = MaSv,
                    NamHoc = NamHoc,
                    Dot = Dot,
                    LanNop = LanNop
                };
                await _BaocaoRepo.UpdateBaoCaosAsync(baocao, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<BaocaosController>/5
        [HttpDelete("MaCv, MaSv, NamHoc, Dot, LanNop")]
        public async Task<IActionResult> Delete(string MaCv, string MaSv, string NamHoc, int Dot, int LanNop)
        {
            BaocaoModel model = new()
            {
                MaCv = MaCv,
                MaSv = MaSv,
                NamHoc = NamHoc,
                Dot = Dot,
                LanNop = LanNop
            };
            await _BaocaoRepo.DeleteBaoCaosAsync(model);
            return Ok();
        }

        [HttpGet("maCv,maSv")]
        public async Task<IActionResult> GetBaocaoByMacv(string maCv, string? maSv)
        {
            try
            {
                return Ok(await _BaocaoRepo.GetBaocaoByMacv(maCv, maSv));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
