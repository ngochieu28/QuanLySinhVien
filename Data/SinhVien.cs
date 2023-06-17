namespace QuanLySinhVien.Data
{
    public enum Gender
    {
        Nam = 0, Nữ = 1
    }
    public class SinhVien
    {
        public string MaSV { get; set; }

        public string TenSV { get; set; }

        public DateTime NgaySinh { get; set; }

        public Gender GioiTinh { get; set; }

        public int MaKhoa { get; set; }

        public Khoa Khoa { get; set; }

    }
}
