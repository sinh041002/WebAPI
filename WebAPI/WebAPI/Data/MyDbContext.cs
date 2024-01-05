using Microsoft.EntityFrameworkCore;
using WebAPI.Data.EF;

namespace WebAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {
        
        }

        #region Dbset
        public DbSet<HangHoa>? HangHoas { get; set; }
        public DbSet<Loai>? Loais { get; set; }
        public DbSet<DonHang> donHangs { get; set; }
        public DbSet<DonHangChiTiet> donHangChiTiets { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(DH => DH.MaDonHang);
                e.Property(DH => DH.NgayDatHang).HasDefaultValueSql("getutcdate()");
            });
            modelBuilder.Entity<DonHangChiTiet>(e =>
            {
                e.ToTable("DonHangChiTiet");
                e.HasKey(dh => new { dh.MaDH, dh.MaHh });

                e.HasOne(dh => dh.donHang)
                .WithMany(dh => dh.DonHangChiTiets)
                .HasForeignKey(e => e.MaDH)
                .HasConstraintName("FK_DonHangChiTiet_DonHang");

                e.HasOne(dh => dh.hangHoa)
                .WithMany(dh => dh.DonHangChiTiets)
                .HasForeignKey(e => e.MaHh)
                .HasConstraintName("FK_DonHangChiTiet_HangHoa");
            });
        }
    }
}
