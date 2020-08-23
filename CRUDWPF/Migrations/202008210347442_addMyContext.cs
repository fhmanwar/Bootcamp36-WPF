namespace CRUDWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMyContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_M_Supplier", "Guid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tb_M_Supplier", "Guid");
        }
    }
}
