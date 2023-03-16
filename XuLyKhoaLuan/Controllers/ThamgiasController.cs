﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThamgiasController : ControllerBase
    {
        private readonly IThamgiaRepository _ThamgiaRepo;

        public ThamgiasController(IThamgiaRepository repo)
        {
            _ThamgiaRepo = repo;
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

        [HttpGet("MaSV, NamHoc, Dot")]
        public async Task<IActionResult> GetThamgiaByMaCN(string MaSV, string NamHoc, int Dot)
        {
            ThamgiaModel thamGia = new()
            {
                MaSv = MaSV,
                NamHoc = NamHoc,
                Dot = Dot
            };
            var Thamgia = await _ThamgiaRepo.GetThamgiaByIDAsync(thamGia);
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

        [HttpDelete("MaSV, NamHoc, Dot")]
        public async Task<IActionResult> DeleteThamgia(string MaSV, string NamHoc, int Dot)
        {
            ThamgiaModel thamGia = new()
            {
                MaSv = MaSV,
                NamHoc = NamHoc,
                Dot = Dot
            };
            await _ThamgiaRepo.DeleteThamgiasAsync(thamGia);
            return Ok();
        }
    }
}
