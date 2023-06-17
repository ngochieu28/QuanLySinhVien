using AutoMapper;
using QuanLySinhVien.Data;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<SinhVien, SinhVienModel>().ReverseMap();
        }
    }
}
