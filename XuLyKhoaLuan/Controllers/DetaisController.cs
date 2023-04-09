using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetaisController : ControllerBase
    {
        private readonly IDetaiRepository _detaiRepo;

        public DetaisController(IDetaiRepository repo)
        {
            _detaiRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDetais()
        {
            try
            {
                return Ok(await _detaiRepo.GetAllDeTaisAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maDT")]
        public async Task<IActionResult> GetDetaiByMaDT(string maDT)
        {
            var detai = await _detaiRepo.GetDeTaiByIDAsync(maDT);
            return detai == null ? BadRequest() : Ok(detai);
        }

        [HttpGet("maK")]
        public async Task<IActionResult> GetMaxMaDtByKhoa(string maK)
        {
            try
            {
                var maDT = await _detaiRepo.createMaDT(maK);
                return Ok(maDT);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("nameDT")]
        public async Task<IActionResult> GetDetaiByTendt(string nameDT)
        {
            try
            {
                return Ok(await _detaiRepo.GetDetaiByTendt(nameDT));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewDetai(DetaiModel model)
        {
            try
            {
                if(model.MaDT == "")
                {
                   model.MaDT = await _detaiRepo.createMaDT("CNTT");
                }    
                var newDetai = await _detaiRepo.AddDeTaisAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("maDT")]
        public async Task<IActionResult> UpdateDetai(string maDT, DetaiModel model)
        {
            
            try
            {
                await _detaiRepo.UpdateDeTaisAsync(maDT, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("maDT")]
        public async Task<IActionResult> DeleteDetai(string maDT)
        {
            await _detaiRepo.DeleteDeTaisAsync(maDT);
            return Ok();
        }

        [HttpGet("MaCN")]
        public async Task<IActionResult> GetDetaiByChuyenNganh(string MaCN)
        {
            var Detais = await _detaiRepo.GetDetaiByChuyenNganhAsync(MaCN);
            return Detais == null ? BadRequest() : Ok(Detais);
        }

        [HttpGet("MaDeTai")]
        public async Task<IActionResult> GetChuyennganhOfDetai(string MaDeTai)
        {
            var Detais = await _detaiRepo.GetChuyennganhOfDetaiAsync(MaDeTai);
            return Detais == null ? BadRequest() : Ok(Detais);
        }

        [HttpGet("tenDT")]
        public async Task<IActionResult> SearchGiangvienByName(string tenDT)
        {
            var Detais = await _detaiRepo.SearchDetaiByNameAsync(tenDT);
            return Detais == null ? BadRequest() : Ok(Detais);
        }

        [HttpGet("maKhoa")]
        public async Task<IActionResult> GetAllDeTaisByMakhoaAsync(string maKhoa)
        {
            try
            {
                return Ok(await _detaiRepo.GetAllDeTaisByMakhoaAsync(maKhoa));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maBm")]
        public async Task<IActionResult> GetAllDeTaisByMaBomonAsync(string maBm)
        {
            try
            {
                return Ok(await _detaiRepo.GetAllDeTaisByMaBomonAsync(maBm));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maGv")]
        public async Task<IActionResult> GetAllDeTaisByGiangvienAsync(string maGv)
        {
            try
            {
                return Ok(await _detaiRepo.GetAllDeTaisByGiangvienAsync(maGv));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maCn, maGv")]
        public async Task<IActionResult> GetDeTaisByChuyennganhGiangvienAsync(string maCn, string maGv)
        {
            try
            {
                return Ok(await _detaiRepo.GetDeTaisByChuyennganhGiangvienAsync(maCn, maGv));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maDt, maGv")]
        public async Task<IActionResult> CheckisDetaiOfGiangvien(string maDt, string maGv)
        {
            try
            {
                return Ok(await _detaiRepo.CheckisDetaiOfGiangvienAsync(maDt, maGv));
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
