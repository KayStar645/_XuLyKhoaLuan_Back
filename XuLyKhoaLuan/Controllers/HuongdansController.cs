﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HuongdansController : ControllerBase
    {
        private readonly IHuongdanRepository _HuongdanRepo;

        public HuongdansController(IHuongdanRepository repo)
        {
            _HuongdanRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHuongdans()
        {
            try
            {
                return Ok(await _HuongdanRepo.GetAllHuongdansAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaGV, MaDT")]
        public async Task<IActionResult> GetHuongdanByMaCN(string MaGV, string MaDT)
        {
            HuongdanModel huongDan = new()
            {
                MaGv = MaGV,
                MaDt = MaDT
            };
            var Huongdan = await _HuongdanRepo.GetHuongdanByIDAsync(huongDan);
            return Huongdan == null ? BadRequest() : Ok(Huongdan);
        }

        [HttpGet("MaDT")]
        public async Task<IActionResult> GetGiangvienByDetaiAsync(string maDT)
        {
            try
            {
                return Ok(await _HuongdanRepo.GetGiangvienByDetaiAsync(maDT));
            }
            catch
            {
                return BadRequest();
            }
        }    

        [HttpPost]
        public async Task<IActionResult> AddNewHuongdan(HuongdanModel model)
        {
            try
            {
                var newHuongdan = await _HuongdanRepo.AddHuongdansAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaGV, MaDT")]
        public async Task<IActionResult> UpdateHuongdan(string MaGV, string MaDT, HuongdanModel model)
        {

            try
            {
                HuongdanModel huongDan = new()
                {
                    MaGv = MaGV,
                    MaDt = MaDT
                };
                await _HuongdanRepo.UpdateHuongdansAsync(huongDan, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaGV, MaDT")]
        public async Task<IActionResult> DeleteHuongdan(string MaGV, string MaDT)
        {
            try
            {
                HuongdanModel huongDan = new()
                {
                    MaGv = MaGV,
                    MaDt = MaDT
                };
                await _HuongdanRepo.DeleteHuongdansAsync(huongDan);
                return Ok();
            }
            catch 
            {
                return BadRequest(); 
            }
        }


        [HttpGet("maGV, namHoc, dot")]
        public async Task<IActionResult> GetDetaiByGVHDDotdkAsync(string maGV, string namHoc, int dot)
        {
            try
            {
                return Ok(await _HuongdanRepo.GetDetaiByGVHDDotdkAsync(maGV, namHoc , dot));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maGv")]
        public async Task<IActionResult> CountDetaiHuongDanByGiangVienAsync(string maGv)
        {
            try
            {
                return Ok(await _HuongdanRepo.CountDetaiHuongDanByGiangVienAsync(maGv));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maGv,start,end")]
        public async Task<IActionResult> CheckThoiGianUpdateLich(string maGv, DateTime? start, DateTime? end)
        {
            try
            {
                return Ok(await _HuongdanRepo.CheckThoiGianUpdateLich(maGv, start, end));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
