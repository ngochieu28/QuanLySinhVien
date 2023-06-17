using QuanLySinhVien.Data;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Services
{
    public interface ISinhVienRepository
    {

        public Task<List<SinhVienModel>> GetSinhViens(string TenSV);

        public Task<SinhVienModel> GetSinhVienByMaSV(string MaSV);

        public Task<string> AddSinhVien(SinhVienModel model);

        public Task UpdateSinhVien(string MaSV, SinhVienModel model);

        public Task DeleteSinhVien(string MaSV);
    }
}
