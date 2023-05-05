﻿using System;
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

        [HttpGet("maCn, tenDt, namHoc, dot, key, maGv, chucVu")]
        public async Task<IActionResult> search(string? maCn, string? tenDt, string? namHoc, int? dot, string? key, string? maGv, int? chucVu)
        {
            try
            {
                return Ok(await _detaiRepo.search(maCn, tenDt, namHoc, dot, key, maGv, chucVu));
            }
            catch
            {
                return BadRequest();
            }
        }

        //[HttpGet("maDt, tenDt, maCn, maBm, gvrd, gvhd, gvpb, trangThai, namHoc, dot, maNhom, isThamKhao")]
        //public async Task<IActionResult> GetDetaiByRequestAsync(string maDt, string tenDt, string maCn, string maBm,
        //    string gvrd, string gvhd, string gvpb, bool trangThai, string namHoc, int dot, string maNhom, bool isThamkhao)
        //{
        //    try
        //    {
        //        return Ok(await _detaiRepo.GetDetaiByRequestAsync(maDt, tenDt, maCn, maBm,
        //    gvrd, gvhd, gvpb, trangThai, namHoc, dot, maNhom, isThamkhao));
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}


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

        [HttpGet("maCN, maBM")]
        public async Task<IActionResult> GetDetaiByChuyenNganhBomonAsync(string maCN, string maBM)
        {
            var Detais = await _detaiRepo.GetDetaiByChuyenNganhBomonAsync(maCN, maBM);
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

        [HttpGet("maKhoa, trangThaiDT")]
        public async Task<IActionResult> GetAllDeTaisByMakhoaAsync(string maKhoa, int trangThaiDT)
        {
            try
            {
                return Ok(await _detaiRepo.GetAllDeTaisByMakhoaAsync(maKhoa, trangThaiDT));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maBm, flag")]
        public async Task<IActionResult> GetAllDeTaisByMaBomonAsync(string maBm, bool flag)
        {
            try
            {
                return Ok(await _detaiRepo.GetAllDeTaisByMaBomonAsync(maBm, flag));
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

        [HttpGet("namHoc, dot")]
        public async Task<IActionResult> GetDetaiByDotdk(string namHoc, int dot)
        {
            try
            {
                return Ok(await _detaiRepo.GetDetaiByDotdk(namHoc, dot));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maBM, namHoc, dot, flag")]
        public async Task<IActionResult> GetDetaiByBomonDotdk(string maBM, string namHoc, int dot, bool flag)
        {
            try
            {
                return Ok(await _detaiRepo.GetDetaiByBomonDotdk(maBM, namHoc, dot, flag));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maGVHD, namHoc, dot")]
        public async Task<IActionResult> GetDetaiByHuongdanOfGiangvienDotdkAsync(string maGVHD, string namHoc, int dot)
        {
            try
            {
                return Ok(await _detaiRepo.GetDetaiByHuongdanOfGiangvienDotdkAsync(maGVHD, namHoc, dot));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maGVPB, namHoc, dot")]
        public async Task<IActionResult> GetDetaiByPhanbienOfGiangvienDotdkAsync(string maGVPB, string namHoc, int dot)
        {
            try
            {
                return Ok(await _detaiRepo.GetDetaiByPhanbienOfGiangvienDotdkAsync(maGVPB, namHoc, dot));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
