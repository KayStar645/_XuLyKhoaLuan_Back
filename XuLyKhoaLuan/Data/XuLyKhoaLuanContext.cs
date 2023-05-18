using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace XuLyKhoaLuan.Data
{
    public partial class XuLyKhoaLuanContext : IdentityDbContext<ApplicationUser>
    {
        public XuLyKhoaLuanContext()
        {
        }

        public XuLyKhoaLuanContext(DbContextOptions<XuLyKhoaLuanContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<Baocao> Baocaos { get; set; } = null!;
        public virtual DbSet<Binhluan> Binhluans { get; set; } = null!;
        public virtual DbSet<Bomon> Bomons { get; set; } = null!;
        public virtual DbSet<Chuyennganh> Chuyennganhs { get; set; } = null!;
        public virtual DbSet<Congviec> Congviecs { get; set; } = null!;
        public virtual DbSet<Dangky> Dangkies { get; set; } = null!;
        public virtual DbSet<Detai> Detais { get; set; } = null!;
        public virtual DbSet<DetaiChuyennganh> DetaiChuyennganhs { get; set; } = null!;
        public virtual DbSet<Dotdk> Dotdks { get; set; } = null!;
        public virtual DbSet<Duyetdt> Duyetdts { get; set; } = null!;
        public virtual DbSet<Giangvien> Giangviens { get; set; } = null!;
        public virtual DbSet<Giaovu> Giaovus { get; set; } = null!;
        public virtual DbSet<Hdcham> Hdchams { get; set; } = null!;
        public virtual DbSet<Hdgopy> Hdgopies { get; set; } = null!;
        public virtual DbSet<Hdpbcham> Hdpbchams { get; set; } = null!;
        public virtual DbSet<Hdpbnhanxet> Hdpbnhanxets { get; set; } = null!;
        public virtual DbSet<Hdphanbien> Hdphanbiens { get; set; } = null!;
        public virtual DbSet<Hoidong> Hoidongs { get; set; } = null!;
        public virtual DbSet<Huongdan> Huongdans { get; set; } = null!;
        public virtual DbSet<Kehoach> Kehoaches { get; set; } = null!;
        public virtual DbSet<Khoa> Khoas { get; set; } = null!;
        public virtual DbSet<Loimoi> Loimois { get; set; } = null!;
        public virtual DbSet<Nhiemvu> Nhiemvus { get; set; } = null!;
        public virtual DbSet<Nhom> Nhoms { get; set; } = null!;
        public virtual DbSet<Pbcham> Pbchams { get; set; } = null!;
        public virtual DbSet<Pbnhanxet> Pbnhanxets { get; set; } = null!;
        public virtual DbSet<Phanbien> Phanbiens { get; set; } = null!;
        public virtual DbSet<Rade> Rades { get; set; } = null!;
        public virtual DbSet<Sinhvien> Sinhviens { get; set; } = null!;
        public virtual DbSet<Thamgiahd> Thamgiahds { get; set; } = null!;
        public virtual DbSet<Thamgium> Thamgia { get; set; } = null!;
        public virtual DbSet<Thongbao> Thongbaos { get; set; } = null!;
        public virtual DbSet<Truongbm> Truongbms { get; set; } = null!;
        public virtual DbSet<Truongkhoa> Truongkhoas { get; set; } = null!;
        public virtual DbSet<Vaitro> Vaitros { get; set; } = null!;
        public virtual DbSet<Xacnhan> Xacnhans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-9JV0A8U\\TANTHUAN;Initial Catalog=XuLyKhoaLuan;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Baocao>(entity =>
            {
                entity.HasKey(e => new { e.MaCv, e.MaSv, e.NamHoc, e.Dot, e.LanNop });

                entity.ToTable("BAOCAO");

                entity.HasIndex(e => new { e.MaSv, e.NamHoc, e.Dot }, "IX_BAOCAO_MaSV_NamHoc_Dot");

                entity.Property(e => e.MaCv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaCV");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaSV");

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FileBc).HasColumnName("File_BC");

                entity.Property(e => e.ThoiGianNop).HasColumnType("datetime");

                entity.HasOne(d => d.MaCvNavigation)
                    .WithMany(p => p.Baocaos)
                    .HasForeignKey(d => d.MaCv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BAOCAO_CONGVIEC");

                entity.HasOne(d => d.Thamgium)
                    .WithMany(p => p.Baocaos)
                    .HasForeignKey(d => new { d.MaSv, d.NamHoc, d.Dot })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BAOCAO_THAMGIA");
            });

            modelBuilder.Entity<Binhluan>(entity =>
            {
                entity.ToTable("BINHLUAN");

                entity.HasIndex(e => e.MaCv, "IX_BINHLUAN_MaCV");

                entity.HasIndex(e => new { e.MaSv, e.NamHoc, e.Dot }, "IX_BINHLUAN_MaSV_NamHoc_Dot");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaCv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaCV");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaSV");

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ThoiGian).HasColumnType("datetime");

                entity.HasOne(d => d.MaCvNavigation)
                    .WithMany(p => p.Binhluans)
                    .HasForeignKey(d => d.MaCv)
                    .HasConstraintName("FK_BINHLUAN_CONGVIEC");

                entity.HasOne(d => d.Thamgium)
                    .WithMany(p => p.Binhluans)
                    .HasForeignKey(d => new { d.MaSv, d.NamHoc, d.Dot })
                    .HasConstraintName("FK_BINHLUAN_THAMGIA");
            });

            modelBuilder.Entity<Bomon>(entity =>
            {
                entity.HasKey(e => e.MaBm);

                entity.ToTable("BOMON");

                entity.HasIndex(e => e.MaKhoa, "IX_BOMON_MaKhoa");

                entity.Property(e => e.MaBm)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaBM");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenBm).HasColumnName("TenBM");

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.Bomons)
                    .HasForeignKey(d => d.MaKhoa)
                    .HasConstraintName("FK_BOMON_KHOA");
            });

            modelBuilder.Entity<Chuyennganh>(entity =>
            {
                entity.HasKey(e => e.MaCn);

                entity.ToTable("CHUYENNGANH");

                entity.HasIndex(e => e.MaKhoa, "IX_CHUYENNGANH_MaKhoa");

                entity.Property(e => e.MaCn)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaCN");

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TenCn).HasColumnName("TenCN");

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.Chuyennganhs)
                    .HasForeignKey(d => d.MaKhoa)
                    .HasConstraintName("FK_CHUYENNGANH_KHOA");
            });

            modelBuilder.Entity<Congviec>(entity =>
            {
                entity.HasKey(e => e.MaCv);

                entity.ToTable("CONGVIEC");

                entity.HasIndex(e => new { e.MaGv, e.MaDt }, "IX_CONGVIEC_MaGV_MaDT");

                entity.HasIndex(e => e.MaNhom, "IX_CONGVIEC_MaNhom");

                entity.Property(e => e.MaCv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaCV");

                entity.Property(e => e.HanChot).HasColumnType("datetime");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaNhom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenCv).HasColumnName("TenCV");

                entity.HasOne(d => d.MaNhomNavigation)
                    .WithMany(p => p.Congviecs)
                    .HasForeignKey(d => d.MaNhom)
                    .HasConstraintName("FK_CONGVIEC_NHOM");

                entity.HasOne(d => d.Ma)
                    .WithMany(p => p.Congviecs)
                    .HasForeignKey(d => new { d.MaGv, d.MaDt })
                    .HasConstraintName("FK_CONGVIEC_HUONGDAN");
            });

            modelBuilder.Entity<Dangky>(entity =>
            {
                entity.HasKey(e => new { e.MaNhom, e.MaDt });

                entity.ToTable("DANGKY");

                entity.HasIndex(e => e.MaDt, "IX_DANGKY_MaDT");

                entity.Property(e => e.MaNhom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.Property(e => e.NgayBd)
                    .HasColumnType("date")
                    .HasColumnName("NgayBD");

                entity.Property(e => e.NgayDk)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayDK");

                entity.Property(e => e.NgayGiao).HasColumnType("date");

                entity.Property(e => e.NgayKt)
                    .HasColumnType("date")
                    .HasColumnName("NgayKT");

                entity.HasOne(d => d.MaDtNavigation)
                    .WithMany(p => p.Dangkies)
                    .HasForeignKey(d => d.MaDt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DANGKY_DETAI");

                entity.HasOne(d => d.MaNhomNavigation)
                    .WithMany(p => p.Dangkies)
                    .HasForeignKey(d => d.MaNhom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DANGKY_NHOM");
            });

            modelBuilder.Entity<Detai>(entity =>
            {
                entity.HasKey(e => e.MaDt);

                entity.ToTable("DETAI");

                entity.HasIndex(e => new { e.NamHoc, e.Dot }, "IX_DETAI_NamHoc_Dot");

                entity.HasIndex(e => e.TenDt, "UQ__DETAI__4CF96562B36CF50C")
                    .IsUnique();

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Slmax).HasColumnName("SLMax");

                entity.Property(e => e.Slmin).HasColumnName("SLMin");

                entity.Property(e => e.TenDt)
                    .HasMaxLength(2048)
                    .HasColumnName("TenDT");

                entity.HasOne(d => d.Dotdk)
                    .WithMany(p => p.Detais)
                    .HasForeignKey(d => new { d.NamHoc, d.Dot })
                    .HasConstraintName("FK_DETAI_DOTDK");
            });

            modelBuilder.Entity<DetaiChuyennganh>(entity =>
            {
                entity.HasKey(e => new { e.MaCn, e.MaDt });

                entity.ToTable("DETAI_CHUYENNGANH");

                entity.HasIndex(e => e.MaDt, "IX_DETAI_CHUYENNGANH_MaDT");

                entity.Property(e => e.MaCn)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaCN");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.HasOne(d => d.MaCnNavigation)
                    .WithMany(p => p.DetaiChuyennganhs)
                    .HasForeignKey(d => d.MaCn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DT_CN_CHUYENNGANH");

                entity.HasOne(d => d.MaDtNavigation)
                    .WithMany(p => p.DetaiChuyennganhs)
                    .HasForeignKey(d => d.MaDt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DT_CN_DETAI");
            });

            modelBuilder.Entity<Dotdk>(entity =>
            {
                entity.HasKey(e => new { e.NamHoc, e.Dot });

                entity.ToTable("DOTDK");

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NgayBd)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayBD");

                entity.Property(e => e.NgayKt)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayKT");

                entity.Property(e => e.Tgbddk)
                    .HasColumnType("datetime")
                    .HasColumnName("TGBDDK");

                entity.Property(e => e.Tgktdk)
                    .HasColumnType("datetime")
                    .HasColumnName("TGKTDK");
            });

            modelBuilder.Entity<Duyetdt>(entity =>
            {
                entity.HasKey(e => new { e.MaGv, e.MaDt, e.LanDuyet });

                entity.ToTable("DUYETDT");

                entity.HasIndex(e => e.MaDt, "IX_DUYETDT_MaDT");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.Property(e => e.NgayDuyet).HasColumnType("datetime");

                entity.HasOne(d => d.MaDtNavigation)
                    .WithMany(p => p.Duyetdts)
                    .HasForeignKey(d => d.MaDt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DUYETDT_DETAI");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.Duyetdts)
                    .HasForeignKey(d => d.MaGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DUYETDT_GIANGVIEN");
            });

            modelBuilder.Entity<Giangvien>(entity =>
            {
                entity.HasKey(e => e.MaGv);

                entity.ToTable("GIANGVIEN");

                entity.HasIndex(e => e.MaBm, "IX_GIANGVIEN_MaBM");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh).HasMaxLength(5);

                entity.Property(e => e.HocHam).HasMaxLength(20);

                entity.Property(e => e.HocVi).HasMaxLength(20);

                entity.Property(e => e.MaBm)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaBM");

                entity.Property(e => e.NgayNghi).HasColumnType("date");

                entity.Property(e => e.NgayNhanViec).HasColumnType("date");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenGv).HasColumnName("TenGV");

                entity.HasOne(d => d.MaBmNavigation)
                    .WithMany(p => p.Giangviens)
                    .HasForeignKey(d => d.MaBm)
                    .HasConstraintName("FK_GIANGVIEN_BOMON");
            });

            modelBuilder.Entity<Giaovu>(entity =>
            {
                entity.HasKey(e => e.MaGv);

                entity.ToTable("GIAOVU");

                entity.HasIndex(e => e.MaKhoa, "IX_GIAOVU_MaKhoa");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh).HasMaxLength(5);

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NgayNghi).HasColumnType("date");

                entity.Property(e => e.NgayNhanViec).HasColumnType("date");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenGv).HasColumnName("TenGV");

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.Giaovus)
                    .HasForeignKey(d => d.MaKhoa)
                    .HasConstraintName("FK_GIAOVU_KHOA");
            });

            modelBuilder.Entity<Hdcham>(entity =>
            {
                entity.HasKey(e => new { e.MaGv, e.MaDt, e.MaSv, e.NamHoc, e.Dot });

                entity.ToTable("HDCHAM");

                entity.HasIndex(e => new { e.MaSv, e.NamHoc, e.Dot }, "IX_HDCHAM_MaSV_NamHoc_Dot");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaSV");

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ma)
                    .WithMany(p => p.Hdchams)
                    .HasForeignKey(d => new { d.MaGv, d.MaDt })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HDCHAM_HUONGDAN");

                entity.HasOne(d => d.Thamgium)
                    .WithMany(p => p.Hdchams)
                    .HasForeignKey(d => new { d.MaSv, d.NamHoc, d.Dot })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HDCHAM_THAMGIA");
            });

            modelBuilder.Entity<Hdgopy>(entity =>
            {
                entity.ToTable("HDGOPY");

                entity.HasIndex(e => e.MaCv, "IX_HDGOPY_MaCV");

                entity.HasIndex(e => new { e.MaGv, e.MaDt }, "IX_HDGOPY_MaGV_MaDT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaCv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaCV");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.ThoiGian).HasColumnType("datetime");

                entity.HasOne(d => d.MaCvNavigation)
                    .WithMany(p => p.Hdgopies)
                    .HasForeignKey(d => d.MaCv)
                    .HasConstraintName("FK_HDGOPY_CONGVIEC");

                entity.HasOne(d => d.Ma)
                    .WithMany(p => p.Hdgopies)
                    .HasForeignKey(d => new { d.MaGv, d.MaDt })
                    .HasConstraintName("FK_HDGOPY_HUONGDAN");
            });

            modelBuilder.Entity<Hdpbcham>(entity =>
            {
                entity.HasKey(e => new { e.MaGv, e.MaHd, e.MaDt, e.MaSv, e.NamHoc, e.Dot });

                entity.ToTable("HDPBCHAM");

                entity.HasIndex(e => new { e.MaSv, e.NamHoc, e.Dot }, "IX_HDPBCHAM_MaSV_NamHoc_Dot");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MaHD");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaSV");

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ma)
                    .WithMany(p => p.Hdpbchams)
                    .HasForeignKey(d => new { d.MaGv, d.MaHd, d.MaDt })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HDPBCHAM_HDPHANBIEN");

                entity.HasOne(d => d.Thamgium)
                    .WithMany(p => p.Hdpbchams)
                    .HasForeignKey(d => new { d.MaSv, d.NamHoc, d.Dot })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HDPBCHAM_THAMGIA");
            });

            modelBuilder.Entity<Hdpbnhanxet>(entity =>
            {
                entity.ToTable("HDPBNHANXET");

                entity.HasIndex(e => new { e.MaGv, e.MaHd, e.MaDt }, "IX_HDPBNHANXET_MaGV_MaHD_MaDT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MaHD");

                entity.Property(e => e.ThoiGian).HasColumnType("datetime");

                entity.HasOne(d => d.Ma)
                    .WithMany(p => p.Hdpbnhanxets)
                    .HasForeignKey(d => new { d.MaGv, d.MaHd, d.MaDt })
                    .HasConstraintName("FK_HDPBNHANXET_HDPHANBIEN");
            });

            modelBuilder.Entity<Hdphanbien>(entity =>
            {
                entity.HasKey(e => new { e.MaGv, e.MaHd, e.MaDt })
                    .HasName("PK_CHAMDIEM");

                entity.ToTable("HDPHANBIEN");

                entity.HasIndex(e => e.MaDt, "IX_HDPHANBIEN_MaDT");

                entity.HasIndex(e => new { e.MaHd, e.MaGv }, "IX_HDPHANBIEN_MaHD_MaGV");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MaHD");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.HasOne(d => d.MaDtNavigation)
                    .WithMany(p => p.Hdphanbiens)
                    .HasForeignKey(d => d.MaDt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HDPHANBIEN_DETAI");

                entity.HasOne(d => d.Ma)
                    .WithMany(p => p.Hdphanbiens)
                    .HasForeignKey(d => new { d.MaHd, d.MaGv })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HDPHANBIEN_THAMGIAHD");
            });

            modelBuilder.Entity<Hoidong>(entity =>
            {
                entity.HasKey(e => e.MaHd);

                entity.ToTable("HOIDONG");

                entity.HasIndex(e => e.MaBm, "IX_HOIDONG_MaBM");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MaHD");

                entity.Property(e => e.DiaDiem).HasMaxLength(50);

                entity.Property(e => e.MaBm)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaBM");

                entity.Property(e => e.NgayLap).HasColumnType("date");

                entity.Property(e => e.TenHd).HasColumnName("TenHD");

                entity.Property(e => e.ThoiGianBd).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianKt).HasColumnType("datetime");

                entity.HasOne(d => d.MaBmNavigation)
                    .WithMany(p => p.Hoidongs)
                    .HasForeignKey(d => d.MaBm)
                    .HasConstraintName("FK_HOIDONG_BOMON");
            });

            modelBuilder.Entity<Huongdan>(entity =>
            {
                entity.HasKey(e => new { e.MaGv, e.MaDt });

                entity.ToTable("HUONGDAN");

                entity.HasIndex(e => e.MaDt, "IX_HUONGDAN_MaDT");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.Property(e => e.DiaDiem).HasMaxLength(500);

                entity.Property(e => e.DuaRaHd).HasColumnName("DuaRaHD");

                entity.Property(e => e.ThoiGianBd).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianKt).HasColumnType("datetime");

                entity.HasOne(d => d.MaDtNavigation)
                    .WithMany(p => p.Huongdans)
                    .HasForeignKey(d => d.MaDt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HUONGDAN_DETAI");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.Huongdans)
                    .HasForeignKey(d => d.MaGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HUONGDAN_GIANGVIEN");
            });

            modelBuilder.Entity<Kehoach>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.ToTable("KEHOACH");

                entity.HasIndex(e => e.MaBm, "IX_KEHOACH_MaBM");

                entity.HasIndex(e => e.MaKhoa, "IX_KEHOACH_MaKhoa");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.FileKh)
                    .HasMaxLength(100)
                    .HasColumnName("FileKH");

                entity.Property(e => e.HinhAnh)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MaBm)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaBM");

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SoLuongDt).HasColumnName("SoLuongDT");

                entity.Property(e => e.TenKh).HasColumnName("TenKH");

                entity.Property(e => e.ThoiGianBd)
                    .HasColumnType("datetime")
                    .HasColumnName("ThoiGianBD");

                entity.Property(e => e.ThoiGianKt)
                    .HasColumnType("datetime")
                    .HasColumnName("ThoiGianKT");

                entity.HasOne(d => d.MaBmNavigation)
                    .WithMany(p => p.Kehoaches)
                    .HasForeignKey(d => d.MaBm)
                    .HasConstraintName("FK_KEHOACH_BOMON");

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.Kehoaches)
                    .HasForeignKey(d => d.MaKhoa)
                    .HasConstraintName("FK_KEHOACH_KHOA");
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.MaKhoa);

                entity.ToTable("KHOA");

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phong)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SDT");
            });

            modelBuilder.Entity<Loimoi>(entity =>
            {
                entity.HasKey(e => new { e.MaSv, e.NamHoc, e.Dot, e.MaNhom });

                entity.ToTable("LOIMOI");

                entity.HasIndex(e => e.MaNhom, "IX_LOIMOI_MaNhom");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaSV");

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaNhom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoiNhan).HasMaxLength(1024);

                entity.Property(e => e.ThoiGian).HasColumnType("datetime");

                entity.HasOne(d => d.MaNhomNavigation)
                    .WithMany(p => p.Loimois)
                    .HasForeignKey(d => d.MaNhom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOIMOI_NHOM");

                entity.HasOne(d => d.Thamgium)
                    .WithMany(p => p.Loimois)
                    .HasForeignKey(d => new { d.MaSv, d.NamHoc, d.Dot })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOIMOI_THAMGIA");
            });

            modelBuilder.Entity<Nhiemvu>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.ToTable("NHIEMVU");

                entity.HasIndex(e => e.MaBm, "IX_NHIEMVU_MaBM");

                entity.HasIndex(e => e.MaGv, "IX_NHIEMVU_MaGV");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.FileNv)
                    .HasMaxLength(100)
                    .HasColumnName("FileNV");

                entity.Property(e => e.HinhAnh)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MaBm)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaBM");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.SoLuongDt).HasColumnName("SoLuongDT");

                entity.Property(e => e.TenNv).HasColumnName("TenNV");

                entity.Property(e => e.ThoiGianBd)
                    .HasColumnType("datetime")
                    .HasColumnName("ThoiGianBD");

                entity.Property(e => e.ThoiGianKt)
                    .HasColumnType("datetime")
                    .HasColumnName("ThoiGianKT");

                entity.HasOne(d => d.MaBmNavigation)
                    .WithMany(p => p.Nhiemvus)
                    .HasForeignKey(d => d.MaBm)
                    .HasConstraintName("FK_NHIEMVU_BOMON");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.Nhiemvus)
                    .HasForeignKey(d => d.MaGv)
                    .HasConstraintName("FK_NHIEMVU_GIANGVIEN");
            });

            modelBuilder.Entity<Nhom>(entity =>
            {
                entity.HasKey(e => e.MaNhom);

                entity.ToTable("NHOM");

                entity.Property(e => e.MaNhom)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pbcham>(entity =>
            {
                entity.HasKey(e => new { e.MaGv, e.MaDt, e.MaSv, e.NamHoc, e.Dot });

                entity.ToTable("PBCHAM");

                entity.HasIndex(e => new { e.MaSv, e.NamHoc, e.Dot }, "IX_PBCHAM_MaSV_NamHoc_Dot");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaSV");

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ma)
                    .WithMany(p => p.Pbchams)
                    .HasForeignKey(d => new { d.MaGv, d.MaDt })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PBCHAM_PHANBIEN");

                entity.HasOne(d => d.Thamgium)
                    .WithMany(p => p.Pbchams)
                    .HasForeignKey(d => new { d.MaSv, d.NamHoc, d.Dot })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PBCHAM_THAMGIA");
            });

            modelBuilder.Entity<Pbnhanxet>(entity =>
            {
                entity.ToTable("PBNHANXET");

                entity.HasIndex(e => new { e.MaGv, e.MaDt }, "IX_PBNHANXET_MaGV_MaDT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.ThoiGian).HasColumnType("datetime");

                entity.HasOne(d => d.Ma)
                    .WithMany(p => p.Pbnhanxets)
                    .HasForeignKey(d => new { d.MaGv, d.MaDt })
                    .HasConstraintName("FK_PBNHANXET_PHANBIEN");
            });

            modelBuilder.Entity<Phanbien>(entity =>
            {
                entity.HasKey(e => new { e.MaGv, e.MaDt });

                entity.ToTable("PHANBIEN");

                entity.HasIndex(e => e.MaDt, "IX_PHANBIEN_MaDT");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.Property(e => e.DiaDiem).HasMaxLength(500);

                entity.Property(e => e.DuaRaHd).HasColumnName("DuaRaHD");

                entity.Property(e => e.ThoiGianBd).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianKt).HasColumnType("datetime");

                entity.HasOne(d => d.MaDtNavigation)
                    .WithMany(p => p.Phanbiens)
                    .HasForeignKey(d => d.MaDt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHANBIEN_DETAI");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.Phanbiens)
                    .HasForeignKey(d => d.MaGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHANBIEN_GIANGVIEN");
            });

            modelBuilder.Entity<Rade>(entity =>
            {
                entity.HasKey(e => new { e.MaGv, e.MaDt });

                entity.ToTable("RADE");

                entity.HasIndex(e => e.MaDt, "IX_RADE_MaDT");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.Property(e => e.ThoiGian).HasColumnType("datetime");

                entity.HasOne(d => d.MaDtNavigation)
                    .WithMany(p => p.Rades)
                    .HasForeignKey(d => d.MaDt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RADE_DETAI");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.Rades)
                    .HasForeignKey(d => d.MaGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RADE_GIANGVIEN");
            });

            modelBuilder.Entity<Sinhvien>(entity =>
            {
                entity.HasKey(e => e.MaSv);

                entity.ToTable("SINHVIEN");

                entity.HasIndex(e => e.MaCn, "IX_SINHVIEN_MaCN");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaSV");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh).HasMaxLength(5);

                entity.Property(e => e.Lop)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaCn)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaCN");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenSv).HasColumnName("TenSV");

                entity.HasOne(d => d.MaCnNavigation)
                    .WithMany(p => p.Sinhviens)
                    .HasForeignKey(d => d.MaCn)
                    .HasConstraintName("FK_SINHVIEN_CHUYENNGANH");
            });

            modelBuilder.Entity<Thamgiahd>(entity =>
            {
                entity.HasKey(e => new { e.MaHd, e.MaGv });

                entity.ToTable("THAMGIAHD");

                entity.HasIndex(e => e.MaGv, "IX_THAMGIAHD_MaGV");

                entity.HasIndex(e => e.MaVt, "IX_THAMGIAHD_MaVT");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MaHD");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaVt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaVT");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.Thamgiahds)
                    .HasForeignKey(d => d.MaGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THAMGIAHD_GIANGVIEN");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.Thamgiahds)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THAMGIAHD_HOIDONG");

                entity.HasOne(d => d.MaVtNavigation)
                    .WithMany(p => p.Thamgiahds)
                    .HasForeignKey(d => d.MaVt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THAMGIAHD_VAITRO");
            });

            modelBuilder.Entity<Thamgium>(entity =>
            {
                entity.HasKey(e => new { e.MaSv, e.NamHoc, e.Dot });

                entity.ToTable("THAMGIA");

                entity.HasIndex(e => new { e.NamHoc, e.Dot }, "IX_THAMGIA_NamHoc_Dot");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaSV");

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DiemTb).HasColumnName("DiemTB");

                entity.Property(e => e.MaNhom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaSvNavigation)
                    .WithMany(p => p.Thamgia)
                    .HasForeignKey(d => d.MaSv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THAMGIA_SINHVIEN");

                entity.HasOne(d => d.Dotdk)
                    .WithMany(p => p.Thamgia)
                    .HasForeignKey(d => new { d.NamHoc, d.Dot })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THAMGIA_DOTDK");
            });

            modelBuilder.Entity<Thongbao>(entity =>
            {
                entity.HasKey(e => e.MaTb);

                entity.ToTable("THONGBAO");

                entity.HasIndex(e => e.MaKhoa, "IX_THONGBAO_MaKhoa");

                entity.Property(e => e.MaTb).HasColumnName("MaTB");

                entity.Property(e => e.FileTb)
                    .HasMaxLength(100)
                    .HasColumnName("FileTB");

                entity.Property(e => e.HinhAnh).HasMaxLength(100);

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTb)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayTB");

                entity.Property(e => e.TenTb).HasColumnName("TenTB");

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.Thongbaos)
                    .HasForeignKey(d => d.MaKhoa)
                    .HasConstraintName("FK_THONGBAO_KHOA");
            });

            modelBuilder.Entity<Truongbm>(entity =>
            {
                entity.HasKey(e => e.MaTbm);

                entity.ToTable("TRUONGBM");

                entity.HasIndex(e => e.MaBm, "IX_TRUONGBM_MaBM");

                entity.HasIndex(e => e.MaGv, "IX_TRUONGBM_MaGV");

                entity.Property(e => e.MaTbm).HasColumnName("MaTBM");

                entity.Property(e => e.MaBm)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaBM");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.NgayNghi).HasColumnType("date");

                entity.Property(e => e.NgayNhanChuc).HasColumnType("date");

                entity.HasOne(d => d.MaBmNavigation)
                    .WithMany(p => p.Truongbms)
                    .HasForeignKey(d => d.MaBm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRUONGBM_BOMON");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.Truongbms)
                    .HasForeignKey(d => d.MaGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRUONGBM_GIANGVIEN");
            });

            modelBuilder.Entity<Truongkhoa>(entity =>
            {
                entity.HasKey(e => e.MaTk);

                entity.ToTable("TRUONGKHOA");

                entity.HasIndex(e => e.MaGv, "IX_TRUONGKHOA_MaGV");

                entity.HasIndex(e => e.MaKhoa, "IX_TRUONGKHOA_MaKhoa");

                entity.Property(e => e.MaTk).HasColumnName("MaTK");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NgayNghi).HasColumnType("date");

                entity.Property(e => e.NgayNhanChuc).HasColumnType("date");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.Truongkhoas)
                    .HasForeignKey(d => d.MaGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRUONGKHOA_GIANGVIEN");

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.Truongkhoas)
                    .HasForeignKey(d => d.MaKhoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRUONGKHOA_KHOA");
            });

            modelBuilder.Entity<Vaitro>(entity =>
            {
                entity.HasKey(e => e.MaVt);

                entity.ToTable("VAITRO");

                entity.Property(e => e.MaVt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaVT");

                entity.Property(e => e.TenVaiTro).HasMaxLength(100);
            });

            modelBuilder.Entity<Xacnhan>(entity =>
            {
                entity.HasKey(e => new { e.MaGv, e.MaDt });

                entity.ToTable("XACNHAN");

                entity.HasIndex(e => e.MaDt, "IX_XACNHAN_MaDT");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaDT");

                entity.Property(e => e.DuaRaHd).HasColumnName("DuaRaHD");

                entity.HasOne(d => d.MaDtNavigation)
                    .WithMany(p => p.Xacnhans)
                    .HasForeignKey(d => d.MaDt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XACNHAN_DETAI");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.Xacnhans)
                    .HasForeignKey(d => d.MaGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XACNHAN_GIANGVIEN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
