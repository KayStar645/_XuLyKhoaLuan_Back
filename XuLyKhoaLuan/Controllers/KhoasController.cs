﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoasController : ControllerBase
    {
        private readonly IKhoaRepository _KhoaRepo;

        public KhoasController(IKhoaRepository repo)
        {
            _KhoaRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKhoas()
        {
            try
            {
                return Ok(await _KhoaRepo.GetAllKhoasAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("MaKhoa")]
        public async Task<IActionResult> GetKhoaByMaKhoa(string MaKhoa)
        {
            var Khoa = await _KhoaRepo.GetKhoaByIDAsync(MaKhoa);
            return Khoa == null ? BadRequest() : Ok(Khoa);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewKhoa(KhoaModel model)
        {
            try
            {
                var newKhoa = await _KhoaRepo.AddKhoasAsync(model);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("MaKhoa")]
        public async Task<IActionResult> UpdateKhoa(string MaKhoa, KhoaModel model)
        {

            try
            {
                await _KhoaRepo.UpdateKhoasAsync(MaKhoa, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("MaKhoa")]
        public async Task<IActionResult> DeleteKhoa(string MaKhoa)
        {
            await _KhoaRepo.DeleteKhoasAsync(MaKhoa);
            return Ok();
        }
    }
}
