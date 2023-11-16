namespace StoreBookOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTheLoaiSachTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TheLoaiSaches",
                c => new
                    {
                        MaLoai = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(),
                    })
                .PrimaryKey(t => t.MaLoai);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TheLoaiSaches");
        }
    }
}
