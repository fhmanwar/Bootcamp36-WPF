namespace CRUDWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMyContext : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Tb_M_Supplier", "Email", c => c.String());
            AddColumn("dbo.Tb_M_Supplier", "Pass", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_M_TransactionItem", "Transaction_Id", "dbo.Tb_M_Transaction");
            DropForeignKey("dbo.Tb_M_TransactionItem", "Item_Id", "dbo.Tb_M_Item");
            DropIndex("dbo.Tb_M_TransactionItem", new[] { "Transaction_Id" });
            DropIndex("dbo.Tb_M_TransactionItem", new[] { "Item_Id" });
            DropColumn("dbo.Tb_M_Supplier", "Pass");
            DropColumn("dbo.Tb_M_Supplier", "Email");
            DropTable("dbo.Tb_M_Transaction");
            DropTable("dbo.Tb_M_TransactionItem");
        }
    }
}
