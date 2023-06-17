using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Services
{
    public class SinhVienRepository : ISinhVienRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public SinhVienRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddSinhVien(SinhVienModel model)
        {
            var newSinhVien = _mapper.Map<SinhVien>(model);
            _context.SinhViens.Add(newSinhVien);
            await _context.SaveChangesAsync();

            return newSinhVien.MaSV;
        }

        public async Task DeleteSinhVien(string MaSV)
        {
            var deleteSinhVien = _context.SinhViens.SingleOrDefault(sv => sv.MaSV == MaSV);
            if (deleteSinhVien != null)
            {
                _context.SinhViens.Remove(deleteSinhVien);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<SinhVienModel> GetSinhVienByMaSV(string MaSV)
        {
            var sinhvien = await _context.SinhViens.FindAsync(MaSV);
            return _mapper.Map<SinhVienModel>(sinhvien);
        }

        public async Task<List<SinhVienModel>> GetSinhViens(string search)
        {
            var sinhviens = _context.SinhViens.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                sinhviens = sinhviens.Where(sv => sv.TenSV.Contains(search));
            }

            if (search == "all")
            {
                var allSinhViens = await _context.SinhViens.ToListAsync();
                return _mapper.Map<List<SinhVienModel>>(allSinhViens);
            }

            var ressult = sinhviens.Select(sv => new SinhVienModel
            {
                MaSV = sv.MaSV,
                TenSV = sv.TenSV,
                NgaySinh = sv.NgaySinh,
                GioiTinh = sv.GioiTinh,
                MaKhoa = sv.MaKhoa,
            });

            return _mapper.Map<List<SinhVienModel>>(ressult.ToList());
        }

        public async Task UpdateSinhVien(string MaSV, SinhVienModel model)
        {
            if(MaSV == model.MaSV)
            {
                var updateSinhVien = _mapper.Map<SinhVien>(model);
                _context.SinhViens.Update(updateSinhVien);
                await _context.SaveChangesAsync();
            }
        }
    }
}
