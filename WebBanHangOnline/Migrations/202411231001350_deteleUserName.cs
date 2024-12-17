namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deteleUserName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Order", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Order", "UserName", c => c.String());
        }
    }
}
