    namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReviewProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Review", "Color", c => c.String());
            AddColumn("dbo.tb_Review", "Size", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Review", "Size");
            DropColumn("dbo.tb_Review", "Color");
        }
    }
}
