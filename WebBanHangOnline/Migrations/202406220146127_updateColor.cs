namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateColor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Size", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_Size", new[] { "ProductId" });
            AddColumn("dbo.tb_Color", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_Color", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Color", "ModifierDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Color", "ModifierBy", c => c.String());
            AddColumn("dbo.tb_Size", "SizeId", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Size", "Color_Id", c => c.Int());
            CreateIndex("dbo.tb_Size", "Color_Id");
            AddForeignKey("dbo.tb_Size", "Color_Id", "dbo.tb_Color", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Size", "Color_Id", "dbo.tb_Color");
            DropIndex("dbo.tb_Size", new[] { "Color_Id" });
            DropColumn("dbo.tb_Size", "Color_Id");
            DropColumn("dbo.tb_Size", "SizeId");
            DropColumn("dbo.tb_Color", "ModifierBy");
            DropColumn("dbo.tb_Color", "ModifierDate");
            DropColumn("dbo.tb_Color", "CreatedDate");
            DropColumn("dbo.tb_Color", "CreatedBy");
            CreateIndex("dbo.tb_Size", "ProductId");
            AddForeignKey("dbo.tb_Size", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
        }
    }
}
