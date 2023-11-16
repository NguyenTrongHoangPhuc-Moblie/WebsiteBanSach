namespace StoreBookOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTheLoaiRowInSach : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Saches", "TheLoai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Saches", "TheLoai", c => c.String());
        }
    }
}
