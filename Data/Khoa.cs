namespace QuanLySinhVien.Data
{
    public enum NameKhoa
    {
        Toán , Lý, Hóa, Anh, Văn, Sử, Địa, Sinh
    }
    public class Khoa
    {
        public int MaKhoa { get; set; }

        public NameKhoa NameKhoa { get; set; }

        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
