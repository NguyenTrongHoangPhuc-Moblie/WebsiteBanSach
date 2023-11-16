namespace StoreBookOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        MaHD = c.Int(nullable: false, identity: true),
                        MaAdmin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.Admins", t => t.MaAdmin, cascadeDelete: true)
                .Index(t => t.MaAdmin);
            
            CreateTable(
                "dbo.DonDatHangs",
                c => new
                    {
                        MaDDH = c.Int(nullable: false, identity: true),
                        MaKH = c.Int(nullable: false),
                        MaSach = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaDDH)
                .ForeignKey("dbo.KhachHangs", t => t.MaKH, cascadeDelete: true)
                .ForeignKey("dbo.Saches", t => t.MaSach, cascadeDelete: true)
                .Index(t => t.MaKH)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKhach = c.Int(nullable: false, identity: true),
                        HoTen = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        SDT = c.String(),
                        Email = c.String(),
                        DiaChi = c.String(),
                    })
                .PrimaryKey(t => t.MaKhach);
            
            CreateTable(
                "dbo.Saches",
                c => new
                    {
                        MaSach = c.Int(nullable: false, identity: true),
                        TenSach = c.String(),
                        TheLoai = c.String(),
                        Anh = c.String(),
                        TacGia = c.String(),
                        SoLuongTon = c.Int(nullable: false),
                        DonGia = c.Single(nullable: false),
                        ChiTiet = c.String(),
                    })
                .PrimaryKey(t => t.MaSach);
            
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        MaGH = c.Int(nullable: false, identity: true),
                        SoLuong = c.Int(nullable: false),
                        ThanhTien = c.Int(nullable: false),
                        MaSach = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaGH)
                .ForeignKey("dbo.Saches", t => t.MaSach, cascadeDelete: true)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.NCC_Sach",
                c => new
                    {
                        MaNCCSach = c.Int(nullable: false, identity: true),
                        MaSach = c.Int(nullable: false),
                        MaNCC = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaNCCSach)
                .ForeignKey("dbo.NhaCungCaps", t => t.MaNCC, cascadeDelete: true)
                .ForeignKey("dbo.Saches", t => t.MaSach, cascadeDelete: true)
                .Index(t => t.MaSach)
                .Index(t => t.MaNCC);
            
            CreateTable(
                "dbo.NhaCungCaps",
                c => new
                    {
                        MaNCC = c.Int(nullable: false, identity: true),
                        TenNCC = c.String(),
                        DiaChi = c.String(),
                    })
                .PrimaryKey(t => t.MaNCC);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonDatHangs", "MaSach", "dbo.Saches");
            DropForeignKey("dbo.NCC_Sach", "MaSach", "dbo.Saches");
            DropForeignKey("dbo.NCC_Sach", "MaNCC", "dbo.NhaCungCaps");
            DropForeignKey("dbo.GioHangs", "MaSach", "dbo.Saches");
            DropForeignKey("dbo.DonDatHangs", "MaKH", "dbo.KhachHangs");
            DropForeignKey("dbo.HoaDons", "MaAdmin", "dbo.Admins");
            DropIndex("dbo.NCC_Sach", new[] { "MaNCC" });
            DropIndex("dbo.NCC_Sach", new[] { "MaSach" });
            DropIndex("dbo.GioHangs", new[] { "MaSach" });
            DropIndex("dbo.DonDatHangs", new[] { "MaSach" });
            DropIndex("dbo.DonDatHangs", new[] { "MaKH" });
            DropIndex("dbo.HoaDons", new[] { "MaAdmin" });
            DropTable("dbo.NhaCungCaps");
            DropTable("dbo.NCC_Sach");
            DropTable("dbo.GioHangs");
            DropTable("dbo.Saches");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.DonDatHangs");
            DropTable("dbo.HoaDons");
            DropTable("dbo.Admins");
        }
    }
}
