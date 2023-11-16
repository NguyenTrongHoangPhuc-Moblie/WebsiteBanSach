namespace StoreBookOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyMaLoaiSach : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Saches", "MaLoaiSach", c => c.Int(nullable: false));
            AddColumn("dbo.Saches", "TheLoaiSach_MaLoai", c => c.Int());
            CreateIndex("dbo.Saches", "TheLoaiSach_MaLoai");
            AddForeignKey("dbo.Saches", "TheLoaiSach_MaLoai", "dbo.TheLoaiSaches", "MaLoai");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Saches", "TheLoaiSach_MaLoai", "dbo.TheLoaiSaches");
            DropIndex("dbo.Saches", new[] { "TheLoaiSach_MaLoai" });
            DropColumn("dbo.Saches", "TheLoaiSach_MaLoai");
            DropColumn("dbo.Saches", "MaLoaiSach");
        }
    }
}
