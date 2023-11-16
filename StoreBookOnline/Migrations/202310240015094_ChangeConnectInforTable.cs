namespace StoreBookOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeConnectInforTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HoaDons", "MaAdmin", "dbo.Admins");
            DropForeignKey("dbo.DonDatHangs", "MaKH", "dbo.KhachHangs");
            DropForeignKey("dbo.Saches", "MaLoaiSach", "dbo.TheLoaiSaches");
            DropIndex("dbo.HoaDons", new[] { "MaAdmin" });
            DropIndex("dbo.DonDatHangs", new[] { "MaKH" });
            DropIndex("dbo.Saches", new[] { "MaLoaiSach" });
            AddColumn("dbo.HoaDons", "Admin_Id", c => c.Int());
            AddColumn("dbo.DonDatHangs", "KhachHang_MaKhach", c => c.Int());
            AddColumn("dbo.Saches", "TheLoaiSach_MaLoai", c => c.Int());
            CreateIndex("dbo.HoaDons", "Admin_Id");
            CreateIndex("dbo.DonDatHangs", "KhachHang_MaKhach");
            CreateIndex("dbo.Saches", "TheLoaiSach_MaLoai");
            AddForeignKey("dbo.HoaDons", "Admin_Id", "dbo.Admins", "Id");
            AddForeignKey("dbo.DonDatHangs", "KhachHang_MaKhach", "dbo.KhachHangs", "MaKhach");
            AddForeignKey("dbo.Saches", "TheLoaiSach_MaLoai", "dbo.TheLoaiSaches", "MaLoai");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Saches", "TheLoaiSach_MaLoai", "dbo.TheLoaiSaches");
            DropForeignKey("dbo.DonDatHangs", "KhachHang_MaKhach", "dbo.KhachHangs");
            DropForeignKey("dbo.HoaDons", "Admin_Id", "dbo.Admins");
            DropIndex("dbo.Saches", new[] { "TheLoaiSach_MaLoai" });
            DropIndex("dbo.DonDatHangs", new[] { "KhachHang_MaKhach" });
            DropIndex("dbo.HoaDons", new[] { "Admin_Id" });
            DropColumn("dbo.Saches", "TheLoaiSach_MaLoai");
            DropColumn("dbo.DonDatHangs", "KhachHang_MaKhach");
            DropColumn("dbo.HoaDons", "Admin_Id");
            CreateIndex("dbo.Saches", "MaLoaiSach");
            CreateIndex("dbo.DonDatHangs", "MaKH");
            CreateIndex("dbo.HoaDons", "MaAdmin");
            AddForeignKey("dbo.Saches", "MaLoaiSach", "dbo.TheLoaiSaches", "MaLoai", cascadeDelete: true);
            AddForeignKey("dbo.DonDatHangs", "MaKH", "dbo.KhachHangs", "MaKhach", cascadeDelete: true);
            AddForeignKey("dbo.HoaDons", "MaAdmin", "dbo.Admins", "Id", cascadeDelete: true);
        }
    }
}
