namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSize : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Size", "Color_Id", "dbo.tb_Color");
            DropIndex("dbo.tb_Size", new[] { "Color_Id" });
            AddColumn("dbo.tb_Size", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_Size", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Size", "ModifierDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Size", "ModifierBy", c => c.String());
            CreateIndex("dbo.tb_Size", "ProductId");
            AddForeignKey("dbo.tb_Size", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
            DropColumn("dbo.tb_Size", "SizeId");
            DropColumn("dbo.tb_Size", "Color_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Size", "Color_Id", c => c.Int());
            AddColumn("dbo.tb_Size", "SizeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.tb_Size", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_Size", new[] { "ProductId" });
            DropColumn("dbo.tb_Size", "ModifierBy");
            DropColumn("dbo.tb_Size", "ModifierDate");
            DropColumn("dbo.tb_Size", "CreatedDate");
            DropColumn("dbo.tb_Size", "CreatedBy");
            CreateIndex("dbo.tb_Size", "Color_Id");
            AddForeignKey("dbo.tb_Size", "Color_Id", "dbo.tb_Color", "Id");
        }
    }
}
