using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Helpers;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetaiChuyennganhController : ControllerBase
    {
        private readonly IDetaichuyennganhRepository _DetaiChuyennganhRepo;
        private readonly IDetaiRepository _DetaiRepo;
        private readonly IChuyennganhRepository _ChuyennganhRepo;

        // GET: api/<BaocaosController>
        public DetaiChuyennganhController(IDetaichuyennganhRepository repo, 
            IDetaiRepository detaiRepo, IChuyennganhRepository chuyennganhRepo)
        {
            _DetaiChuyennganhRepo = repo;
            _DetaiRepo = detaiRepo;
            _ChuyennganhRepo = chuyennganhRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDetaiChuyennganhsAsync()
        {
            try
            {
                return Ok(await _DetaiChuyennganhRepo.GetAllDetaiChuyennganhsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maDT, maCN")]
        public async Task<IActionResult> GetDetaiChuyennganhByMaDTMaCN(string? maDT, string? maCN)
        {
            try
            {
                var result = await _DetaiChuyennganhRepo.GetDetaiChuyennganhByMaDTMaCNAsync(maDT, maCN);
                return result == null ? BadRequest() : Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBaocao(DetaiChuyennganhModel model)
        {
            try
            {
                var result = await _DetaiChuyennganhRepo.AddDetaiChuyennganhsAsync(model);
                return Ok(result);
            }
            catch(Exception ex)
            {
                switch (ex)
                {
                    case errorMessage:
                        return StatusCode(409, ex.Message);
                    default:
                        return StatusCode(500, ex.Message);
                }
            }
        }

        [HttpDelete("maDT, maCN")]
        public async Task<IActionResult> DeleteDetaiChuyennganhs(string maDT, string maCN)
        {
            DetaiChuyennganhModel delete = new DetaiChuyennganhModel()
            {
                MaCn = maCN,
                MaDt = maDT
            };
            await _DetaiChuyennganhRepo.DeleteDetaiChuyennganhsAsync(delete);
            return Ok();
        }


    }
}
