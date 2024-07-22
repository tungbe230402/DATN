namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTbSizeAndColor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Color",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.tb_Size",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SizeName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Size", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_Color", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_Size", new[] { "ProductId" });
            DropIndex("dbo.tb_Color", new[] { "ProductId" });
            DropTable("dbo.tb_Size");
            DropTable("dbo.tb_Color");
        }
    }
}
