using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XuLyKhoaLuan.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BaocaosController : ControllerBase
    {
        private readonly IBaocaoRepository _baoCaoRepo;
        // GET: api/<BaocaosController>
        public BaocaosController(IBaocaoRepository repo)
        {
            _baoCaoRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBaocaos()
        {
            try
            {
                return Ok(await _baoCaoRepo.GetAllBaoCaosAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<BaocaosController>/5
        [HttpGet("{MaCv}, {MaSv}, {NamHoc}, {Dot}, {LanNop}")]
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
                var baoCao = await _baoCaoRepo.GetBaoCaoByIDAsync(model);
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
                var newBaocao = await _baoCaoRepo.AddBaoCaosAsync(model);
                return CreatedAtAction(nameof(GetBaocaoById), new { Controller = "Baocaos", newBaocao }, newBaocao);
                
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<BaocaosController>/5
        [HttpPut("{MaCv}, {MaSv}, {NamHoc}, {Dot}, {LanNop}")]
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
                await _baoCaoRepo.UpdateBaoCaosAsync(baocao, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<BaocaosController>/5
        [HttpDelete("{MaCv}, {MaSv}, {NamHoc}, {Dot}, {LanNop}")]
        public void Delete(string MaCv, string MaSv, string NamHoc, int Dot, int LanNop)
        {

        }
    }
}
