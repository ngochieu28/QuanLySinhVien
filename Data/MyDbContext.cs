using Microsoft.EntityFrameworkCore;

namespace QuanLySinhVien.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Khoa> Khoas { get; set; }

        public DbSet<SinhVien> SinhViens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.ToTable(nameof(Khoa));
                entity.HasKey(k => k.MaKhoa);
                entity.HasMany(k => k.SinhViens)
                    .WithOne(sv => sv.Khoa)
                    .HasForeignKey(sv => sv.MaKhoa);
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.ToTable(nameof(SinhVien));
                entity.HasKey(sv => sv.MaSV);
                entity.Property(sv => sv.TenSV).IsRequired().HasMaxLength(50);
            });
        }
    }
}
