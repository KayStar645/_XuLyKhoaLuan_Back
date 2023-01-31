﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuLyKhoaLuan.Models;
using XuLyKhoaLuan.Repositories.Interface;

namespace XuLyKhoaLuan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BomonsController : ControllerBase
    {
        private readonly IBomonRepository _BomonRepo;

        public BomonsController(IBomonRepository repo)
        {
            _BomonRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBomons()
        {
            try
            {
                return Ok(await _BomonRepo.GetAllBomonsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("maBM")]
        public async Task<IActionResult> GetBomonByMaBM(string maBM)
        {
            var Bomon = await _BomonRepo.GetBomonByIDAsync(maBM);
            return Bomon == null ? BadRequest() : Ok(Bomon);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBomon(BomonModel model)
        {
            try
            {
                var newBomon = await _BomonRepo.AddBomonsAsync(model);
                return CreatedAtAction(nameof(GetBomonByMaBM), new { Controller = "Bomons", newBomon }, newBomon);
                //var Bomon = await _detaiRepo.GetBomonByMaDTsAsync(newBomon);
                //return Bomon == null ? BadRequest() : Ok(Bomon);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("maBM")]
        public async Task<IActionResult> UpdateBomon(string maBM, BomonModel model)
        {

            try
            {
                await _BomonRepo.UpdateBomonsAsync(maBM, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("maBM")]
        public async Task<IActionResult> DeleteBomon(string maBM)
        {
            await _BomonRepo.DeleteBomonsAsync(maBM);
            return Ok();
        }
    }
}
