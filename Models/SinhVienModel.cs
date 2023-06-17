using QuanLySinhVien.Data;

namespace QuanLySinhVien.Models
{
    public class SinhVienModel
    {
        public string MaSV { get; set; }

        public string TenSV { get; set; }

        public DateTime NgaySinh { get; set; }

        public Gender GioiTinh { get; set; }

        public int MaKhoa { get; set; }
    }
}
