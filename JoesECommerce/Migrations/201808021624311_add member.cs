namespace JoesECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmember : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        EmailAddress = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        MobilePhone = c.String(),
                        CreditCard = c.String(),
                        Address = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
