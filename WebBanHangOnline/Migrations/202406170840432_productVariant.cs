namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productVariant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_ProductVariant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Size = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_ProductVariant", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_ProductVariant", new[] { "ProductId" });
            DropTable("dbo.tb_ProductVariant");
        }
    }
}
