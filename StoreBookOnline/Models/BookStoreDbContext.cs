using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StoreBookOnline.Models
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext() : base("BookStoreEntities1") { }

        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<Sach> Saches { get; set; }
        public DbSet<DonDatHang> DonDatHangs { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<NCC_Sach> NCC_Saches { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<TheLoaiSach> TheLoaiSaches { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<DonDatHang>()
        //    //    .HasRequired(kh => kh.KhachHang)
        //    //    .WithMany(k => k.DonDatHangs)
        //    //    .HasForeignKey(kh => kh.MaKH);

        //    //modelBuilder.Entity<DonDatHang>()
        //    //    .HasRequired(sa => sa.Sach)
        //    //    .WithMany(s => s.DonDatHangs)
        //    //    .HasForeignKey(sa => sa.MaSach);

        //    //modelBuilder.Entity<GioHang>()
        //    //    .HasRequired(sa => sa.Sach)
        //    //    .WithMany(g => g.GioHangs)
        //    //    .HasForeignKey(sa => sa.MaSach);

        //    //modelBuilder.Entity<NCC_Sach>()
        //    //    .HasRequired(sa => sa.Sach)
        //    //    .WithMany(s => s.NCC_Saches)
        //    //    .HasForeignKey(sa => sa.MaSach);

        //    //modelBuilder.Entity<NCC_Sach>()
        //    //    .HasRequired(ncc => ncc.NhaCungCap)
        //    //    .WithMany(s => s.NCC_Saches)
        //    //    .HasForeignKey(ncc => ncc.MaNCC);

        //    //modelBuilder.Entity<HoaDon>()
        //    //    .HasRequired(ad => ad.Admin)
        //    //    .WithMany(hd => hd.HoaDons)
        //    //    .HasForeignKey(ad => ad.MaAdmin);

        //    //modelBuilder.Entity<Sach>()
        //    //    .HasRequired(tl => tl.TheLoaiSach)
        //    //    .WithMany(sa => sa.Saches)
        //    //    .HasForeignKey(tl => tl.MaLoaiSach);
        //}
    }
    
}