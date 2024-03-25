using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace WPFBO
{
    public partial class QLSVContext : DbContext
    {
        public QLSVContext()
        {
        }

        public QLSVContext(DbContextOptions<QLSVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Diemsv> Diemsvs { get; set; } = null!;
        public virtual DbSet<Lop> Lops { get; set; } = null!;
        public virtual DbSet<Monhoc> Monhocs { get; set; } = null!;
        public virtual DbSet<Sinhvien> Sinhviens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config.GetConnectionString("DBDefault");
            return strConn;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNT");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender).HasMaxLength(255);

                entity.Property(e => e.Masv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MASV");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.MasvNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.Masv)
                    .HasConstraintName("FK__ACCOUNT__MASV__412EB0B6");
            });

            modelBuilder.Entity<Diemsv>(entity =>
            {
                entity.HasKey(e => new { e.Masv, e.Mamh })
                    .HasName("PK__DIEMSV__C6217CB6D37EA4FE");

                entity.ToTable("DIEMSV");

                entity.Property(e => e.Masv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MASV");

                entity.Property(e => e.Mamh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MAMH");

                entity.Property(e => e.Diem).HasColumnName("DIEM");

                entity.HasOne(d => d.MamhNavigation)
                    .WithMany(p => p.Diemsvs)
                    .HasForeignKey(d => d.Mamh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIEMSV__MAMH__44FF419A");

                entity.HasOne(d => d.MasvNavigation)
                    .WithMany(p => p.Diemsvs)
                    .HasForeignKey(d => d.Masv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIEMSV__MASV__440B1D61");
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.Malp)
                    .HasName("PK__LOP__603F41557480F5C5");

                entity.ToTable("LOP");

                entity.HasIndex(e => e.Malp, "UQ__LOP__603F41548A24CA6B")
                    .IsUnique();

                entity.Property(e => e.Malp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MALP");

                entity.Property(e => e.Nk).HasColumnName("NK");

                entity.Property(e => e.Tenlp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TENLP");
            });

            modelBuilder.Entity<Monhoc>(entity =>
            {
                entity.HasKey(e => e.Mamh)
                    .HasName("PK__MONHOC__603F69EBBB501415");

                entity.ToTable("MONHOC");

                entity.HasIndex(e => e.Mamh, "UQ__MONHOC__603F69EAE74B6882")
                    .IsUnique();

                entity.Property(e => e.Mamh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MAMH");

                entity.Property(e => e.Sotc).HasColumnName("SOTC");

                entity.Property(e => e.Tenmh)
                    .HasMaxLength(255)
                    .HasColumnName("TENMH");
            });

            modelBuilder.Entity<Sinhvien>(entity =>
            {
                entity.HasKey(e => e.Masv)
                    .HasName("PK__SINHVIEN__60228A288AD884E7");

                entity.ToTable("SINHVIEN");

                entity.HasIndex(e => e.Masv, "UQ__SINHVIEN__60228A294173AD6F")
                    .IsUnique();

                entity.HasIndex(e => e.Malp, "UQ__SINHVIEN__603F4154E50B6738")
                    .IsUnique();

                entity.Property(e => e.Masv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MASV");

                entity.Property(e => e.Dcsv)
                    .HasMaxLength(255)
                    .HasColumnName("DCSV");

                entity.Property(e => e.Malp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MALP");

                entity.Property(e => e.Tensv)
                    .HasMaxLength(255)
                    .HasColumnName("TENSV");

                entity.HasOne(d => d.MalpNavigation)
                    .WithOne(p => p.Sinhvien)
                    .HasForeignKey<Sinhvien>(d => d.Malp)
                    .HasConstraintName("FK__SINHVIEN__MALP__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
