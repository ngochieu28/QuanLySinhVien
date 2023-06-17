using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Models;
using QuanLySinhVien.Services;

namespace QuanLySinhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private readonly ISinhVienRepository _sinhvienRepo;

        public SinhVienController(ISinhVienRepository repo) 
        {
            _sinhvienRepo = repo;
        }

      

        [HttpGet]
        public async Task<IActionResult> GetAllSinhVienSearch(string search = "all")
        {
            try
            {
                return Ok(await _sinhvienRepo.GetSinhViens(search));
            }
            catch
            {
                return BadRequest("We can't get the SinhVien");
            }
        }

        [HttpGet("{MaSV}")]
        public async Task<IActionResult> GetSinhVienByMaSV(string MaSV)
        {
            var sinhVien = await _sinhvienRepo.GetSinhVienByMaSV(MaSV);
            return sinhVien == null ? NotFound() : Ok(sinhVien);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewSinhVien(SinhVienModel model)
        {
            try
            {
                var newSinhVienMaSV = await _sinhvienRepo.AddSinhVien(model);
               // return Ok(newSinhVienMaSV);

                var sinhVien = await _sinhvienRepo.GetSinhVienByMaSV(newSinhVienMaSV);
                return sinhVien == null ? NotFound() : Ok(sinhVien);
            }
            catch 
            { 
                return BadRequest(); 
            }
        }

        [HttpPut("{MaSV}")]
        public async Task<IActionResult> UpdateSinhVien(string MaSV, SinhVienModel model) 
        {
            if(MaSV != model.MaSV)
            {
                return NotFound();
            }
            await _sinhvienRepo.UpdateSinhVien(MaSV, model);
            return Ok();
        }

        [HttpDelete("{MaSV}")]
        public async Task<IActionResult> DeleteSinhVienByMaSV(string MaSV)
        {
            await _sinhvienRepo.DeleteSinhVien(MaSV);
            return Ok();
        }


    }
}
