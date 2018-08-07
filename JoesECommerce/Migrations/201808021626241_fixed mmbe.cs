namespace JoesECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedmmbe : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Members");
            AddColumn("dbo.Members", "MemberId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Members", "Username", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Members", "MemberId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Members");
            AlterColumn("dbo.Members", "Username", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Members", "MemberId");
            AddPrimaryKey("dbo.Members", "Username");
        }
    }
}
