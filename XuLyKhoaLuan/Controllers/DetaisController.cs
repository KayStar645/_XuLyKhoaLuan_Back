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

        [HttpPost]
        public async Task<IActionResult> AddNewDetai(DetaiModel model)
        {
            try
            {
                var newDetai = await _detaiRepo.AddDeTaisAsync(model);
                return Ok(model);
                //return CreatedAtAction(nameof(GetDetaiByMaDT), new { Controller = "Detais", newDetai }, newDetai);
                //var detai = await _detaiRepo.GetDeTaiByMaDTsAsync(newDetai);
                //return detai == null ? BadRequest() : Ok(detai);
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
