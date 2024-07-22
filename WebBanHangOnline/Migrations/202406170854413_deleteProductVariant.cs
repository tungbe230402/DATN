namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteProductVariant : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_ProductVariant", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_ProductVariant", new[] { "ProductId" });
            DropTable("dbo.tb_ProductVariant");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.tb_ProductVariant", "ProductId");
            AddForeignKey("dbo.tb_ProductVariant", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
        }
    }
}
