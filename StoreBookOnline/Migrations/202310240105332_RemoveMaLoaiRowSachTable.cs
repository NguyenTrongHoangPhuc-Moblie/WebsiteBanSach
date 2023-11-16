namespace StoreBookOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMaLoaiRowSachTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Saches", "MaLoaiSach");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Saches", "MaLoaiSach", c => c.Int(nullable: false));
        }
    }
}
