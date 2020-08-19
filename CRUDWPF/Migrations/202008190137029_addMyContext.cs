namespace CRUDWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMyContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_M_Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        Supplier_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tb_M_Supplier", t => t.Supplier_Id, cascadeDelete: true)
                .Index(t => t.Supplier_Id);
            
            CreateTable(
                "dbo.Tb_M_Supplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Pass = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tb_M_TransactionItem",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                        Transaction_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tb_M_Item", t => t.Item_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tb_M_Transaction", t => t.Transaction_Id, cascadeDelete: true)
                .Index(t => t.Item_Id)
                .Index(t => t.Transaction_Id);
            
            CreateTable(
                "dbo.Tb_M_Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_M_TransactionItem", "Transaction_Id", "dbo.Tb_M_Transaction");
            DropForeignKey("dbo.Tb_M_TransactionItem", "Item_Id", "dbo.Tb_M_Item");
            DropForeignKey("dbo.Tb_M_Item", "Supplier_Id", "dbo.Tb_M_Supplier");
            DropIndex("dbo.Tb_M_TransactionItem", new[] { "Transaction_Id" });
            DropIndex("dbo.Tb_M_TransactionItem", new[] { "Item_Id" });
            DropIndex("dbo.Tb_M_Item", new[] { "Supplier_Id" });
            DropTable("dbo.Tb_M_Transaction");
            DropTable("dbo.Tb_M_TransactionItem");
            DropTable("dbo.Tb_M_Supplier");
            DropTable("dbo.Tb_M_Item");
        }
    }
}
