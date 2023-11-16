namespace StoreBookOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOneToOneHoaDonDDH : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HoaDons", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.DonDatHangs", "KhachHang_MaKhach", "dbo.KhachHangs");
            DropForeignKey("dbo.Saches", "TheLoaiSach_MaLoai", "dbo.TheLoaiSaches");
            DropIndex("dbo.HoaDons", new[] { "Admin_Id" });
            DropIndex("dbo.DonDatHangs", new[] { "KhachHang_MaKhach" });
            DropIndex("dbo.Saches", new[] { "TheLoaiSach_MaLoai" });
            AddColumn("dbo.HoaDons", "DonDatHang_MaDDH", c => c.Int());
            AddColumn("dbo.HoaDons", "Admin_Id1", c => c.Int());
            AddColumn("dbo.DonDatHangs", "HoaDon_MaHD", c => c.Int());
            AddColumn("dbo.DonDatHangs", "KhachHang_MaKhach1", c => c.Int());
            AddColumn("dbo.Saches", "TheLoaiSach_MaLoai1", c => c.Int());
            CreateIndex("dbo.HoaDons", "Admin_Id1");
            CreateIndex("dbo.DonDatHangs", "KhachHang_MaKhach1");
            CreateIndex("dbo.Saches", "TheLoaiSach_MaLoai1");
            AddForeignKey("dbo.HoaDons", "Admin_Id1", "dbo.Admins", "Id");
            AddForeignKey("dbo.DonDatHangs", "KhachHang_MaKhach1", "dbo.KhachHangs", "MaKhach");
            AddForeignKey("dbo.Saches", "TheLoaiSach_MaLoai1", "dbo.TheLoaiSaches", "MaLoai");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Saches", "TheLoaiSach_MaLoai1", "dbo.TheLoaiSaches");
            DropForeignKey("dbo.DonDatHangs", "KhachHang_MaKhach1", "dbo.KhachHangs");
            DropForeignKey("dbo.HoaDons", "Admin_Id1", "dbo.Admins");
            DropIndex("dbo.Saches", new[] { "TheLoaiSach_MaLoai1" });
            DropIndex("dbo.DonDatHangs", new[] { "KhachHang_MaKhach1" });
            DropIndex("dbo.HoaDons", new[] { "Admin_Id1" });
            DropColumn("dbo.Saches", "TheLoaiSach_MaLoai1");
            DropColumn("dbo.DonDatHangs", "KhachHang_MaKhach1");
            DropColumn("dbo.DonDatHangs", "HoaDon_MaHD");
            DropColumn("dbo.HoaDons", "Admin_Id1");
            DropColumn("dbo.HoaDons", "DonDatHang_MaDDH");
            CreateIndex("dbo.Saches", "TheLoaiSach_MaLoai");
            CreateIndex("dbo.DonDatHangs", "KhachHang_MaKhach");
            CreateIndex("dbo.HoaDons", "Admin_Id");
            AddForeignKey("dbo.Saches", "TheLoaiSach_MaLoai", "dbo.TheLoaiSaches", "MaLoai");
            AddForeignKey("dbo.DonDatHangs", "KhachHang_MaKhach", "dbo.KhachHangs", "MaKhach");
            AddForeignKey("dbo.HoaDons", "Admin_Id", "dbo.Admins", "Id");
        }
    }
}
