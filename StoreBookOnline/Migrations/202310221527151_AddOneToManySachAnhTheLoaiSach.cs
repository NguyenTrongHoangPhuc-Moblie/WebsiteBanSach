namespace StoreBookOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOneToManySachAnhTheLoaiSach : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Saches", "TheLoaiSach_MaLoai", "dbo.TheLoaiSaches");
            DropIndex("dbo.Saches", new[] { "TheLoaiSach_MaLoai" });
            DropColumn("dbo.Saches", "MaLoaiSach");
            RenameColumn(table: "dbo.Saches", name: "TheLoaiSach_MaLoai", newName: "MaLoaiSach");
            AlterColumn("dbo.Saches", "MaLoaiSach", c => c.Int(nullable: false));
            CreateIndex("dbo.Saches", "MaLoaiSach");
            AddForeignKey("dbo.Saches", "MaLoaiSach", "dbo.TheLoaiSaches", "MaLoai", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Saches", "MaLoaiSach", "dbo.TheLoaiSaches");
            DropIndex("dbo.Saches", new[] { "MaLoaiSach" });
            AlterColumn("dbo.Saches", "MaLoaiSach", c => c.Int());
            RenameColumn(table: "dbo.Saches", name: "MaLoaiSach", newName: "TheLoaiSach_MaLoai");
            AddColumn("dbo.Saches", "MaLoaiSach", c => c.Int(nullable: false));
            CreateIndex("dbo.Saches", "TheLoaiSach_MaLoai");
            AddForeignKey("dbo.Saches", "TheLoaiSach_MaLoai", "dbo.TheLoaiSaches", "MaLoai");
        }
    }
}
