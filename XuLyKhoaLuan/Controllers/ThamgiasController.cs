using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;
using static Sieve.Extensions.MethodInfoExtended;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThamgiasController : ControllerBase
    {
        private readonly IThamgiaRepository _ThamgiaRepo;
        private readonly INhomRepository _NhomRepo;

        public ThamgiasController(IThamgiaRepository repo, INhomRepository nhomRepo)
        {
            _ThamgiaRepo = repo;
            _NhomRepo = nhomRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllThamgias()
        {
            try
            {
                return Ok(await _ThamgiaRepo.GetAllThamgiasAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maSV")]
        public async Task<IActionResult> GetAllThamgiaNotmesAsync(string maSV)
        {
            try
            {
                return Ok(await _ThamgiaRepo.GetAllThamgiaNotmesAsync(maSV));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaSV, NamHoc, Dot")]
        public async Task<IActionResult> GetThamgiaByMaCN(string MaSV, string NamHoc, int Dot)
        {
            var Thamgia = await _ThamgiaRepo.GetThamgiaByIDAsync(MaSV, NamHoc, Dot);
            return Thamgia == null ? BadRequest() : Ok(Thamgia);
        }

        [HttpGet("maCN")]
        public async Task<IActionResult> GetThamgiasByMacn(string maCN)
        {
            try
            {
                return Ok(await _ThamgiaRepo.GetThamgiaByMacnAsync(maCN));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("name")]
        public async Task<IActionResult> SearchThamgiaByNameAsync(string name)
        {
            try
            {
                return Ok(await _ThamgiaRepo.SearchThamgiaByNameAsync(name));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewThamgia(ThamgiaModel model)
        {
            try
            {
                var newThamgia = await _ThamgiaRepo.AddThamgiasAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaSV, NamHoc, Dot")]
        public async Task<IActionResult> UpdateThamgia(string MaSV, string NamHoc, int Dot, ThamgiaModel model)
        {

            try
            {
                ThamgiaModel thamGia = new()
                {
                    MaSv = MaSV,
                    NamHoc = NamHoc,
                    Dot = Dot
                };
                await _ThamgiaRepo.UpdateThamgiasAsync(thamGia, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("namHoc, dot")]
        public async Task<IActionResult> GetThamgiaByDotdk(string namHoc, int dot)
        {
            try
            {
                return Ok(await _ThamgiaRepo.GetThamgiaByDotdk(namHoc, dot));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaSV, NamHoc, Dot")]
        public async Task<IActionResult> DeleteThamgia(string MaSV, string NamHoc, int Dot)
        {
            try
            {
                var thamGia = await _ThamgiaRepo.GetThamgiaByIDAsync(MaSV, NamHoc, Dot);
                var number = await _NhomRepo.CountThanhVienNhomAsync(thamGia.MaNhom);

                await _ThamgiaRepo.DeleteThamgiasAsync(MaSV, NamHoc, Dot);

                // Nếu tham gia này có nhóm 1 người thì xóa nhóm
                if (number < 2)
                {
                    await _NhomRepo.DeleteNhomsAsync(thamGia.MaNhom);
                }
                // Nếu sinh viên này có nhóm > 1 người thì chuyển quyền trưởng nhóm cho thành viên trong nhóm
                else
                {
                    var list = await _NhomRepo.GetThanhVienNhomAsync(thamGia.MaNhom);
                    list[0].TruongNhom = true;
                    await _ThamgiaRepo.UpdateThamgiasAsync(list[0], list[0]);
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        
        [HttpGet("maNhom, flag")]
        public async Task<IActionResult> GetSinhvienByNhomAsync(string maNhom, bool flag)
        {
            try
            {
                return Ok(await _ThamgiaRepo.GetSinhvienByNhomAsync(maNhom, flag));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maCn, namHoc, dot")]
        public async Task<IActionResult> GetThamgiaByChuyennganhDotdk(string maCn, string namHoc, int dot)
        {
            try
            {
                return Ok(await _ThamgiaRepo.GetThamgiaByChuyennganhDotdk(maCn, namHoc, dot));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
