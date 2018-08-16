namespace JoesECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Quantity", c => c.Short(nullable: false));
            AddColumn("dbo.Products", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Products", "Quantity");
        }
    }
}
